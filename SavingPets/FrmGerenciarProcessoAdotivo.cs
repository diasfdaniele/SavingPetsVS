using SavingPets.Models;
using SavingPets.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavingPets
{
    public partial class FrmGerenciarProcessoAdotivo : Form
    {
        // Lista simulando o banco
        private List<ProcessoAdotivo> listaProcessos;

        // Processo selecionado no grid
        private ProcessoAdotivo processoSelecionado;

        public FrmGerenciarProcessoAdotivo()
        {
            InitializeComponent();
        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmGerenciarProcessoAdotivo_Load(object sender, EventArgs e)
        {
            CarregarProcessosSimulados();
            dgvProcessos.DataSource = listaProcessos.Select(p => new
            {
                p.IdProcesso,
                Tutor = p.Tutor.NomeTutor,
                Animal = p.Animal.NomeAnimal,
                Data = p.DataAdocao.ToShortDateString()
            }).ToList();
        }

        private void CarregarProcessosSimulados()
        {
            listaProcessos = new List<ProcessoAdotivo>
    {
        new ProcessoAdotivo
        {
            IdProcesso = 1,
            Tutor = new Tutor { IdTutor = 10, NomeTutor = "Ana Souza", Telefone = "9999-0001", Rua = "Rua A, 100" },
            Animal = new Animal { IdAnimal = 1, NomeAnimal = "Rex" },
            DataAdocao = new DateTime(2025, 10, 15)
        },
        new ProcessoAdotivo
        {
            IdProcesso = 2,
            Tutor = new Tutor { IdTutor = 11, NomeTutor = "João Lima", Telefone = "9999-0002", Rua = "Rua B, 200" },
            Animal = new Animal { IdAnimal = 2, NomeAnimal = "Luna" },
            DataAdocao = new DateTime(2025, 09, 05)
        },
        new ProcessoAdotivo
        {
            IdProcesso = 3,
            Tutor = new Tutor { IdTutor = 12, NomeTutor = "Marcos Oliveira", Telefone = "9999-0003", Rua = "Rua C, 300" },
            Animal = new Animal { IdAnimal = 3, NomeAnimal = "Mia" },
            DataAdocao = new DateTime(2025, 08, 20)
        }
    };
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
           
            IEnumerable<ProcessoAdotivo> filtrado = listaProcessos;

            string termo = txtPesquisar.Text.ToLower();

            if (rbNomeTutor.Checked)
                filtrado = listaProcessos.Where(p => p.Tutor.NomeTutor.ToLower().Contains(termo));

            else if (rbIdTutor.Checked)
                filtrado = listaProcessos.Where(p => p.Tutor.IdTutor.ToString() == termo);

            else if (rbNomeAnimal.Checked)
                filtrado = listaProcessos.Where(p => p.Animal.NomeAnimal.ToLower().Contains(termo));

            else if (rbIdAnimal.Checked)
                filtrado = listaProcessos.Where(p => p.Animal.IdAnimal.ToString() == termo);

            else if (rbIdProcesso.Checked)
                filtrado = listaProcessos.Where(p => p.IdProcesso.ToString() == termo);

            dgvProcessos.DataSource = filtrado.Select(p => new
            {
                p.IdProcesso,
                Tutor = p.Tutor.NomeTutor,
                Animal = p.Animal.NomeAnimal,
                Data = p.DataAdocao.ToShortDateString()
            }).ToList();
        }

        private void dgvProcessos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvProcessos.Rows[e.RowIndex].Cells["IdProcesso"].Value);

            processoSelecionado = listaProcessos.FirstOrDefault(p => p.IdProcesso == id);

            if (processoSelecionado == null) return;

            // Preenche os campos
            txtIdProcesso.Text = processoSelecionado.IdProcesso.ToString();
            txtNomeTutor.Text = processoSelecionado.Tutor.NomeTutor;
            txtNomeAnimal.Text = processoSelecionado.Animal.NomeAnimal;
            txtTelefone.Text = processoSelecionado.Tutor.Telefone;
            txtEndereco.Text = processoSelecionado.Tutor.Rua;
            dataAdocao.Value = processoSelecionado.DataAdocao;

            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNomeTutor.Enabled = true;
            txtTelefone.Enabled = true;
            txtEndereco.Enabled = true;
            dataAdocao.Enabled = true;

            btnSalvar.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (processoSelecionado == null) return;

            processoSelecionado.Tutor.NomeTutor = txtNomeTutor.Text;
            processoSelecionado.Tutor.Telefone = txtTelefone.Text;
            processoSelecionado.Tutor.Rua = txtEndereco.Text;
            processoSelecionado.DataAdocao = dataAdocao.Value;

            MessageBox.Show("Processo atualizado com sucesso!");

            AtualizarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (processoSelecionado == null) return;

            DialogResult resp = MessageBox.Show(
                "Tem certeza que deseja excluir este processo?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resp == DialogResult.Yes)
            {
                listaProcessos.Remove(processoSelecionado);
                processoSelecionado = null;
                MessageBox.Show("Processo removido com sucesso!");
                AtualizarGrid();
                LimparCampos();
            }
        }

        private void AtualizarGrid()
        {
            dgvProcessos.DataSource = listaProcessos.Select(p => new
            {
                p.IdProcesso,
                Tutor = p.Tutor.NomeTutor,
                Animal = p.Animal.NomeAnimal,
                Data = p.DataAdocao.ToShortDateString()
            }).ToList();
        }

        private void LimparCampos()
        {
            txtIdProcesso.Clear();
            txtNomeTutor.Clear();
            txtNomeAnimal.Clear();
            txtTelefone.Clear();
            txtEndereco.Clear();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

