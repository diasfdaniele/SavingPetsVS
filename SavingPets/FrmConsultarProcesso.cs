using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SavingPets.DAL;
using SavingPets.Models;

namespace SavingPets
{
    public partial class FrmConsultarProcesso : Form
    {
        private List<ProcessoAdotivo> listaProcessos;
        private string filtroAtual = "NomeTutor";
        private ProcessoAdotivo processoSelecionado;

        public FrmConsultarProcesso()
        {
            InitializeComponent();

            CarregarProcessosDoBanco();

            AtualizarGrid();

            dgvProcessos.SelectionChanged += dgvProcessos_SelectionChanged;
        }

        private void CarregarProcessosDoBanco()
        {
            BancoDadosProcessoAdotivo db = new BancoDadosProcessoAdotivo();
            listaProcessos = db.ListarProcessos();
        }

        private void AtualizarGrid()
        {
            dgvProcessos.DataSource = null;

            // Cria uma lista anônima com apenas os campos que queremos mostrar
            var listaParaGrid = listaProcessos.Select(p => new
            {
                ProcessoObj = p, // referência ao objeto real
                p.IdProcesso,
                NomeTutor = p.Tutor?.NomeTutor ?? "",
                NomeAnimal = p.Animal?.NomeAnimal ?? "",
                DataAdocao = p.DataAdocao.ToString("dd/MM/yyyy"),
                DataAgendamento = p.DataAgendamentoVisita.ToString("dd/MM/yyyy") ?? ""
            }).ToList();

            dgvProcessos.DataSource = listaParaGrid;

            if (dgvProcessos.Columns.Contains("ProcessoObj"))
                dgvProcessos.Columns["ProcessoObj"].Visible = false;

            // Configurações do DataGridView
            dgvProcessos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProcessos.MultiSelect = false;
            dgvProcessos.ReadOnly = true;
            dgvProcessos.AutoGenerateColumns = true;

            // Ajusta os nomes das colunas
            if (dgvProcessos.Columns.Contains("IdProcesso"))
                dgvProcessos.Columns["IdProcesso"].HeaderText = "ID";

            if (dgvProcessos.Columns.Contains("NomeTutor"))
                dgvProcessos.Columns["NomeTutor"].HeaderText = "Nome do Tutor";

            if (dgvProcessos.Columns.Contains("NomeAnimal"))
                dgvProcessos.Columns["NomeAnimal"].HeaderText = "Nome do Animal";

            if (dgvProcessos.Columns.Contains("DataAdocao"))
                dgvProcessos.Columns["DataAdocao"].HeaderText = "Data da Adoção";

            if (dgvProcessos.Columns.Contains("agendamentoVisita"))
                dgvProcessos.Columns["DataAgendamento"].HeaderText = "Visita Agendada:";
        }


        private void rbNomeTutor_CheckedChanged(object sender, EventArgs e)
        {
            filtroAtual = "NomeTutor";
        }

        private void rbNomeAnimal_CheckedChanged(object sender, EventArgs e)
        {
            filtroAtual = "NomeAnimal";
        }

        private void rbIdProcesso_CheckedChanged(object sender, EventArgs e)
        {
            filtroAtual = "IdProcesso";
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string termo = txtPesquisar.Text.ToLower();

            var filtrados = listaProcessos.Where(p =>
                (filtroAtual == "NomeTutor" && p.Tutor.NomeTutor.ToLower().Contains(termo)) ||
                (filtroAtual == "NomeAnimal" && p.Animal.NomeAnimal.ToLower().Contains(termo)) ||
                (filtroAtual == "IdProcesso" && p.IdProcesso.ToString().Contains(termo))
            ).ToList();

            dgvProcessos.DataSource = null;
            dgvProcessos.DataSource = filtrados;
        }

        private void dgvProcessos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProcessos.SelectedRows.Count > 0)
            {
                // Pega o objeto anônimo da linha selecionada
                var linha = dgvProcessos.SelectedRows[0].DataBoundItem;

                // Recupera a propriedade ProcessoObj
                var processo = (ProcessoAdotivo)linha.GetType()
                                .GetProperty("ProcessoObj")
                                .GetValue(linha);

                if (processo != null)
                {
                    processoSelecionado = processo;
                    ExibirDetalhes(processoSelecionado);
                }
            }
        }

        private void ExibirDetalhes(ProcessoAdotivo p)
        {
            txtId.Text = p.IdProcesso.ToString();
            txtNomeTutor.Text = p.Tutor.NomeTutor;
            txtNomeAnimal.Text = p.Animal.NomeAnimal;
            dataAdocao.Value = p.DataAdocao;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (processoSelecionado != null)
            {
                MessageBox.Show($"Selecionado processo ID={processoSelecionado.IdProcesso}", "Confirmação");

                this.Tag = processoSelecionado;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione um processo antes de confirmar.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvProcessos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelecionarProcessoDaLinha(e.RowIndex);
            }
        }

        private void SelecionarProcessoDaLinha(int rowIndex)
        {
            var processo = dgvProcessos.Rows[rowIndex].DataBoundItem as ProcessoAdotivo;
            if (processo != null)
            {
                processoSelecionado = processo;
                ExibirDetalhes(processoSelecionado);
            }
        }
    }
}