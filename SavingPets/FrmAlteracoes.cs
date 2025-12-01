using SavingPets.Controllers;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

// Alias para evitar conflitos de nomes
using iText = iTextSharp.text;
using iTextPdf = iTextSharp.text.pdf;

namespace SavingPets
{
    public partial class FrmAlteracoes : Form
    {
        private LogAlteracaoController controller = new LogAlteracaoController();
        private List<LogAlteracao> listaLogs = new List<LogAlteracao>();

        public FrmAlteracoes()
        {
            InitializeComponent();
            ConfigurarGrid();

            this.Load += FrmAlteracoes_Load;
            this.btnExportar.Click += btnExportar_Click;
            // Se o btnVoltar já tiver evento no designer, remova essa linha abaixo
            // this.btnVoltar.Click += btnVoltar_Click; 
        }

        private void ConfigurarGrid()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FrmAlteracoes_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {
                listaLogs = controller.Listar();

                var dadosFormatados = listaLogs.Select(l => new
                {
                    ID = l.IdLog,
                    Voluntário = l.NomeVoluntario,
                    Descrição = l.Descricao,
                    Data = l.DataHora.ToString("dd/MM/yyyy HH:mm:ss")
                }).ToList();

                dataGridView1.DataSource = dadosFormatados;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar logs: " + ex.Message);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar.", "Atenção");
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Arquivo PDF (.pdf)|.pdf";
            save.FileName = "Relatorio_Logs_" + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    GerarPDF(save.FileName);
                    MessageBox.Show("Relatório gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gerar PDF: " + ex.Message, "Erro");
                }
            }
        }

        private void GerarPDF(string caminhoArquivo)
        {
            // 1. Configuração do Documento
            iText.Document doc = new iText.Document(iText.PageSize.A4, 20, 20, 20, 20);
            iTextPdf.PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));

            doc.Open();

            // 2. Adicionar Logo (Resolvendo ambiguidade de Image)
            if (pictureBox5.Image != null)
            {
                // Pega a imagem do Windows Forms (System.Drawing.Image)
                System.Drawing.Image imagemWinForms = pictureBox5.Image;

                // Converte para iTextSharp.text.Image
                iText.Image logoPdf = iText.Image.GetInstance(imagemWinForms, System.Drawing.Imaging.ImageFormat.Png);

                logoPdf.ScaleToFit(100f, 80f);
                logoPdf.Alignment = iText.Element.ALIGN_CENTER;
                doc.Add(logoPdf);
            }

            // 3. Título / Cabeçalho (Resolvendo ambiguidade de Font)
            iText.Font fonteTitulo = new iText.Font(iText.Font.FontFamily.HELVETICA, 16, iText.Font.BOLD);
            iText.Paragraph titulo = new iText.Paragraph("SAVING PETS - RELATÓRIO DE ALTERÃÇÕES\n\n", fonteTitulo);
            titulo.Alignment = iText.Element.ALIGN_CENTER;
            doc.Add(titulo);

            iText.Paragraph info = new iText.Paragraph($"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n\n");
            info.Alignment = iText.Element.ALIGN_CENTER;
            doc.Add(info);

            // 4. Tabela de Dados
            iTextPdf.PdfPTable tabela = new iTextPdf.PdfPTable(4);
            tabela.WidthPercentage = 100;

            // CORREÇÃO: Passando array de float explicitamente (f no final)
            tabela.SetWidths(new float[] { 10f, 25f, 45f, 20f });

            // Cabeçalhos
            AdicionarCelulaCabecalho(tabela, "ID");
            AdicionarCelulaCabecalho(tabela, "Voluntário");
            AdicionarCelulaCabecalho(tabela, "Ação / Descrição");
            AdicionarCelulaCabecalho(tabela, "Data/Hora");

            // Linhas
            iText.Font fonteDados = new iText.Font(iText.Font.FontFamily.HELVETICA, 9);

            foreach (var log in listaLogs)
            {
                tabela.AddCell(new iText.Phrase(log.IdLog.ToString(), fonteDados));
                tabela.AddCell(new iText.Phrase(log.NomeVoluntario, fonteDados));
                tabela.AddCell(new iText.Phrase(log.Descricao, fonteDados));
                tabela.AddCell(new iText.Phrase(log.DataHora.ToString("dd/MM/yyyy HH:mm"), fonteDados));
            }

            doc.Add(tabela);
            doc.Close();
        }

        private void AdicionarCelulaCabecalho(iTextPdf.PdfPTable tabela, string texto)
        {
            iText.Font fonteCabecalho = new iText.Font(iText.Font.FontFamily.HELVETICA, 10, iText.Font.BOLD, iText.BaseColor.WHITE);
            iTextPdf.PdfPCell celula = new iTextPdf.PdfPCell(new iText.Phrase(texto, fonteCabecalho));

            celula.BackgroundColor = iText.BaseColor.DARK_GRAY;
            celula.HorizontalAlignment = iText.Element.ALIGN_CENTER;
            celula.Padding = 5;

            tabela.AddCell(celula);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            this.Hide();
            menu.ShowDialog();
            this.Show();
        }
    }
}