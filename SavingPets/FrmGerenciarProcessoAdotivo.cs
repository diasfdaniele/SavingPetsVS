using SavingPets.Models;
using SavingPets.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SavingPets
{
    public partial class FrmGerenciarProcessoAdotivo : Form
    {
        private ProcessoAdotivoController controller = new ProcessoAdotivoController();
        private List<ProcessoAdotivo> listaProcessos = new List<ProcessoAdotivo>();
        private ProcessoAdotivo processoSelecionado;

        public FrmGerenciarProcessoAdotivo()
        {
            InitializeComponent();
            ConfigurarGrid();

            // Ligações de eventos
            this.btnPesquisar.Click += (s, e) => AtualizarListagem();
            this.btnEditar.Click += new EventHandler(this.btnEditar_Click);
            this.btnSalvar.Click += new EventHandler(this.btnSalvar_Click);
            this.btnExcluir.Click += new EventHandler(this.btnExcluir_Click);
            this.btnVoltar.Click += new EventHandler(this.btnVoltar_Click);
            this.dgvProcessos.SelectionChanged += new EventHandler(this.dgvProcessos_SelectionChanged);
            this.Load += new EventHandler(this.FrmGerenciarProcessoAdotivo_Load);

            // RadioButtons
            rbNomeTutor.CheckedChanged += (s, e) => AtualizarListagem();
            rbIdTutor.CheckedChanged += (s, e) => AtualizarListagem();
            rbNomeAnimal.CheckedChanged += (s, e) => AtualizarListagem();
            rbIdAnimal.CheckedChanged += (s, e) => AtualizarListagem();
            rbIdProcesso.CheckedChanged += (s, e) => AtualizarListagem();
        }

        private void ConfigurarGrid()
        {
            dgvProcessos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProcessos.MultiSelect = false;
            dgvProcessos.ReadOnly = true;
            dgvProcessos.AutoGenerateColumns = true;
            dgvProcessos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void FrmGerenciarProcessoAdotivo_Load(object sender, EventArgs e)
        {
            CarregarProcessosDoBanco();
        }

        private void CarregarProcessosDoBanco()
        {
            try
            {
                listaProcessos = controller.Listar();
                AtualizarListagem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        // --- LÓGICA DE LISTAGEM E FILTRO ---
        private void AtualizarListagem()
        {
            if (listaProcessos == null) return;

            string termo = txtPesquisar.Text.ToLower().Trim();
            IEnumerable<ProcessoAdotivo> query = listaProcessos;

            if (rbNomeTutor.Checked)
            {
                if (!string.IsNullOrEmpty(termo)) query = query.Where(p => p.Tutor != null && p.Tutor.NomeTutor.ToLower().Contains(termo));
                query = query.OrderBy(p => p.Tutor?.NomeTutor);
            }
            else if (rbIdTutor.Checked)
            {
                if (!string.IsNullOrEmpty(termo)) query = query.Where(p => p.Tutor != null && p.Tutor.IdTutor.ToString() == termo);
                query = query.OrderBy(p => p.Tutor?.IdTutor);
            }
            else if (rbNomeAnimal.Checked)
            {
                if (!string.IsNullOrEmpty(termo)) query = query.Where(p => p.Animal != null && p.Animal.NomeAnimal.ToLower().Contains(termo));
                query = query.OrderBy(p => p.Animal?.NomeAnimal);
            }
            else if (rbIdAnimal.Checked)
            {
                if (!string.IsNullOrEmpty(termo)) query = query.Where(p => p.Animal != null && p.Animal.IdAnimal.ToString() == termo);
                query = query.OrderBy(p => p.Animal?.IdAnimal);
            }
            else
            {
                if (!string.IsNullOrEmpty(termo)) query = query.Where(p => p.IdProcesso.ToString() == termo);
                query = query.OrderBy(p => p.IdProcesso);
            }

            var dadosFormatados = query.Select(p => new
            {
                ID = p.IdProcesso,
                Tutor = p.Tutor?.NomeTutor,
                Endereço = FormatarEndereco(p.Tutor),
                Telefone = p.Tutor?.Telefone,
                Animal = p.Animal?.NomeAnimal,
                Data = p.DataAdocao.ToShortDateString()
            }).ToList();

            dgvProcessos.DataSource = null;
            dgvProcessos.DataSource = dadosFormatados;
            dgvProcessos.ClearSelection();
            processoSelecionado = null;
            DesabilitarEdicao();
        }

        // --- SELEÇÃO ---
        private void dgvProcessos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProcessos.SelectedRows.Count == 0) return;
            try
            {
                object valorId = null;
                if (dgvProcessos.Columns.Contains("ID")) valorId = dgvProcessos.SelectedRows[0].Cells["ID"].Value;
                else valorId = dgvProcessos.SelectedRows[0].Cells[0].Value;

                if (valorId != null)
                {
                    int id = Convert.ToInt32(valorId);
                    processoSelecionado = listaProcessos.FirstOrDefault(p => p.IdProcesso == id);
                    if (processoSelecionado != null) PreencherCampos(processoSelecionado);
                }
            }
            catch { processoSelecionado = null; }
        }

        private void PreencherCampos(ProcessoAdotivo p)
        {
            txtIdProcesso.Text = p.IdProcesso.ToString();
            txtNomeTutor.Text = p.Tutor?.NomeTutor;
            txtNomeAnimal.Text = p.Animal?.NomeAnimal;
            txtTelefone.Text = p.Tutor?.Telefone;

            // Mostra o endereço formatado.
            // O usuário terá que editar isso com cuidado para salvar corretamente.
            txtEndereco.Text = FormatarEndereco(p.Tutor);

            dataAdocao.Value = p.DataAdocao;

            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            DesabilitarEdicao();
        }

        // --- BOTÃO SALVAR (Com lógica de quebra de endereço) ---
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (processoSelecionado == null) return;

            try
            {
                processoSelecionado.DataAdocao = dataAdocao.Value;

                if (processoSelecionado.Tutor != null)
                {
                    processoSelecionado.Tutor.Telefone = txtTelefone.Text;

                    // 🔥 LÓGICA INTELIGENTE DE ENDEREÇO 🔥
                    // Tenta separar o texto digitado em partes.
                    // Espera formato: "Rua, Numero, Bairro, Cidade, Estado, CEP"
                    string[] partes = txtEndereco.Text.Split(',');

                    if (partes.Length >= 2)
                    {
                        // Se tiver vírgulas, tentamos separar
                        processoSelecionado.Tutor.Rua = partes[0].Trim();
                        processoSelecionado.Tutor.Numero = partes[1].Trim(); // Pega número (pode ter letras, o DAL filtra)

                        if (partes.Length > 2) processoSelecionado.Tutor.Bairro = partes[2].Trim();
                        if (partes.Length > 3) processoSelecionado.Tutor.Cidade = partes[3].Trim();
                        if (partes.Length > 4) processoSelecionado.Tutor.Estado = partes[4].Trim();
                        if (partes.Length > 5) processoSelecionado.Tutor.CEP = partes[5].Trim();
                    }
                    else
                    {
                        // Se não tiver vírgula, salva tudo na Rua pra não perder dados
                        processoSelecionado.Tutor.Rua = txtEndereco.Text;
                    }
                }

                // Salva no Banco (Agora o DAL atualiza tudo!)
                controller.Editar(processoSelecionado);

                MessageBox.Show("Processo e dados do tutor atualizados com sucesso!");
                CarregarProcessosDoBanco();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }

        // --- OUTROS MÉTODOS ---
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (processoSelecionado == null) return;
            txtTelefone.Enabled = true;
            txtEndereco.Enabled = true;
            dataAdocao.Enabled = true;
            btnSalvar.Enabled = true;

            MessageBox.Show("Para editar o endereço completo, use vírgulas:\nRua, Numero, Bairro, Cidade, Estado, CEP");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (processoSelecionado == null) return;
            if (MessageBox.Show("Deseja excluir?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    controller.Excluir(processoSelecionado.IdProcesso);
                    MessageBox.Show("Excluído!");
                    CarregarProcessosDoBanco();
                    LimparCampos();
                }
                catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
            }
        }

        private string FormatarEndereco(Tutor t)
        {
            if (t == null) return "";
            // Formato que facilita a edição depois (separado por vírgulas)
            return $"{t.Rua}, {t.Numero}, {t.Bairro}, {t.Cidade}, {t.Estado}, {t.CEP}";
        }

        private void LimparCampos()
        {
            txtIdProcesso.Clear();
            txtNomeTutor.Clear();
            txtNomeAnimal.Clear();
            txtTelefone.Clear();
            txtEndereco.Clear();
            processoSelecionado = null;
            DesabilitarEdicao();
        }

        private void DesabilitarEdicao()
        {
            txtNomeTutor.Enabled = false;
            txtTelefone.Enabled = false;
            txtEndereco.Enabled = false;
            dataAdocao.Enabled = false;
            btnSalvar.Enabled = false;
        }

        // Auxiliares
        private void btnPesquisar_Click(object sender, EventArgs e) { AtualizarListagem(); }
        private void btnVoltar_Click(object sender, EventArgs e) { FrmMenu m = new FrmMenu(); Hide(); m.ShowDialog(); Show(); }
        private void FrmGerenciarProcessoAdotivo_FormClosing(object sender, FormClosingEventArgs e) { if (e.CloseReason != CloseReason.ApplicationExitCall) { if (MessageBox.Show("Sair?", "Confirma", MessageBoxButtons.YesNo) == DialogResult.No) e.Cancel = true; else Application.Exit(); } }
        private void dgvProcessos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtTelefone_TextChanged(object sender, EventArgs e) { }
    }
}