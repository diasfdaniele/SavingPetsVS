using SavingPets.Controllers;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
// Resolvendo a ambiguidade de nomes para o PDF
using iTextSharp.text;
using iTextSharp.text.pdf;
// Alias para evitar conflito com System.Drawing.Image e System.Drawing.Font
using PDFImage = iTextSharp.text.Image;
using PDFFont = iTextSharp.text.Font;

namespace SavingPets
{
    public partial class FrmRelatorioGerencial : Form
    {
        private RelatorioController controller = new RelatorioController();
        private DataTable dadosRelatorio; // Armazena o resultado atual para exportação

        public FrmRelatorioGerencial()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Estado inicial do Grid
            dgvRelatorios.DataSource = null;
            // Configurar DataGridView para exibir mensagem quando vazio não é nativo, 
            // mas podemos controlar via MessageBox ou Label se a contagem for 0.

            // Popula combos se necessário (embora já tenham itens no designer)
            if (cmbOrdenarPor.Items.Count == 0)
            {
                cmbOrdenarPor.Items.Add("Nome");
                cmbOrdenarPor.Items.Add("Data");
                cmbOrdenarPor.SelectedIndex = 0;
            }
            if (cmbTipoRelatorio.Items.Count > 0)
                cmbTipoRelatorio.SelectedIndex = 0;

            // Datas padrão
            dtInicialPadrao.Value = DateTime.Now.AddMonths(-1);
            dtFimPadrao.Value = DateTime.Now;
            dtInicialPers.Value = DateTime.Now.AddMonths(-6);
            dtFimPers.Value = DateTime.Now;

            // Liga eventos dos botões manualmente
            this.btnPesquisarPadrao.Click += new EventHandler(this.btnPesquisarPadrao_Click);
            this.btnPesquisarPers.Click += new EventHandler(this.btnPesquisarPers_Click);
            this.btnPesquisarProcesso.Click += new EventHandler(this.btnPesquisarProcesso_Click);
            this.btnExportar.Click += new EventHandler(this.btnExportar_Click);
            this.btnVoltar.Click += new EventHandler(this.btnVoltar_Click);
        }

        // =======================================================
        // 1. PESQUISA PADRÃO
        // =======================================================
        private void btnPesquisarPadrao_Click(object sender, EventArgs e)
        {
            try
            {
                dadosRelatorio = controller.ConsultarPadrao(
                    cmbTipoRelatorio.SelectedIndex,
                    dtInicialPadrao.Value,
                    dtFimPadrao.Value
                );
                AtualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na consulta padrão: " + ex.Message);
            }
        }

        // =======================================================
        // 2. PESQUISA PERSONALIZADA (ANIMAL)
        // =======================================================
        private void btnPesquisarPers_Click(object sender, EventArgs e)
        {
            try
            {
                string ordenacao = cmbOrdenarPor.SelectedItem?.ToString() ?? "Nome";

                dadosRelatorio = controller.ConsultarPersonalizado(
                    cbxEspecie.Checked,
                    cbxVacina.Checked,
                    cbxCastracao.Checked,
                    ordenacao
                );
                AtualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na consulta personalizada: " + ex.Message);
            }
        }

        // =======================================================
        // 3. PESQUISA PROCESSO / OCORRÊNCIA
        // =======================================================
        private void btnPesquisarProcesso_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica qual RadioButton de gravidade está marcado
                string gravidade = "Todas";
                if (rbAlta.Checked) gravidade = "Alta";
                else if (rbMedia.Checked) gravidade = "Media";
                else if (rbBaixa.Checked) gravidade = "Baixa";

                dadosRelatorio = controller.ConsultarProcessos(
                    txtPesquisar.Text.Trim(),
                    cbxFisico.Checked,
                    cbxAdaptacao.Checked,
                    cbxStatus.Checked,
                    cbxMausTratos.Checked,
                    cbxVisitas.Checked,
                    cbxTutorProcesso.Checked,
                    cbxTutorOcorrencia.Checked,
                    gravidade
                );
                AtualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na consulta de processos: " + ex.Message);
            }
        }

        private void AtualizarGrid()
        {
            dgvRelatorios.DataSource = dadosRelatorio;
            dgvRelatorios.AutoResizeColumns();

            if (dadosRelatorio == null || dadosRelatorio.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum registro encontrado com os filtros selecionados.", "Informação");
            }
        }

        // =======================================================
        // EXPORTAÇÃO PDF (Com correção de ambiguidade)
        // =======================================================
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvRelatorios.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar.", "Atenção");
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF (.pdf)|.pdf";
            save.FileName = "Relatorio_SavingPets_" + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Criação do Documento PDF (iTextSharp)
                    Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));

                    doc.Open();

                    // --- Cabeçalho com Logo ---
                    PdfPTable tabelaCabecalho = new PdfPTable(2);
                    tabelaCabecalho.WidthPercentage = 100;

                    // Célula da Imagem
                    PdfPCell cellImg = new PdfPCell();
                    cellImg.Border = Rectangle.NO_BORDER;

                    // Tenta pegar a imagem do PictureBox do form, se não, ignora
                    if (pictureBox5.Image != null)
                    {
                        // Converte System.Drawing.Image para iTextSharp Image
                        using (var ms = new MemoryStream())
                        {
                            pictureBox5.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            PDFImage imgPDF = PDFImage.GetInstance(ms.ToArray());
                            imgPDF.ScaleToFit(100f, 60f); // Ajusta tamanho
                            cellImg.AddElement(imgPDF);
                        }
                    }
                    tabelaCabecalho.AddCell(cellImg);

                    // Célula do Texto
                    PDFFont fonteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                    Paragraph titulo = new Paragraph("ONG Saving Pets - Relatório Gerencial", fonteTitulo);
                    titulo.Alignment = Element.ALIGN_RIGHT;

                    PdfPCell cellTexto = new PdfPCell();
                    cellTexto.Border = Rectangle.NO_BORDER;
                    cellTexto.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cellTexto.AddElement(titulo);
                    cellTexto.AddElement(new Paragraph("Gerado em: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm")));

                    tabelaCabecalho.AddCell(cellTexto);
                    doc.Add(tabelaCabecalho);
                    doc.Add(new Paragraph(" ")); // Espaço
                    doc.Add(new Paragraph("----------------------------------------------------------------------------------------------------------------------------------"));
                    doc.Add(new Paragraph(" "));

                    // --- Tabela de Dados ---
                    PdfPTable pdfTable = new PdfPTable(dgvRelatorios.Columns.Count);
                    pdfTable.WidthPercentage = 100;

                    // Cabeçalhos
                    PDFFont fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                    foreach (DataGridViewColumn column in dgvRelatorios.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, fontHeader));
                        cell.BackgroundColor = new BaseColor(240, 240, 240);
                        pdfTable.AddCell(cell);
                    }

                    // Dados
                    PDFFont fontData = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                    foreach (DataGridViewRow row in dgvRelatorios.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                string valor = cell.Value?.ToString() ?? "";
                                pdfTable.AddCell(new Phrase(valor, fontData));
                            }
                        }
                    }

                    doc.Add(pdfTable);
                    doc.Close();

                    MessageBox.Show("Relatório exportado com sucesso!", "Sucesso");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao exportar PDF: " + ex.Message);
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}