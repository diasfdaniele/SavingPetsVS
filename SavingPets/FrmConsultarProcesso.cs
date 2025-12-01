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
            dgvProcessos.DataSource = listaProcessos;

            dgvProcessos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProcessos.MultiSelect = false;
            dgvProcessos.ReadOnly = true;

            // Ajusta nomes das colunas
            dgvProcessos.Columns["IdProcesso"].HeaderText = "ID";
            dgvProcessos.Columns["DataAdocao"].HeaderText = "Data da Adoção";
            dgvProcessos.Columns["Tutor"].Visible = false;
            dgvProcessos.Columns["Animal"].Visible = false;
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
                var processo = dgvProcessos.SelectedRows[0].DataBoundItem as ProcessoAdotivo;

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
                MessageBox.Show($"Selecionado processo ID={processoSelecionado.IdProcesso}", "DEBUG");

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