using SavingPets.Controllers;
using SavingPets.Models;
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
    public partial class FrmGerenciarAnimal : Form
    {
        private List<Animal> listaAnimais;          // lista principal (simulando banco)
        private string filtroAtual = "IdAnimal";    // filtro
        private Animal animalSelecionado;           // objeto que guarda o animal selecionado
        private AnimalController controller = new AnimalController();

        public FrmGerenciarAnimal()
        {
            InitializeComponent();
            CarregarAnimaisSimulados(); // enquanto não há banco
            AtualizarGrid();

            dgvAnimais.SelectionChanged += dgvAnimais_SelectionChanged;
        }

        private void CarregarAnimaisSimulados()
        {
            listaAnimais = new List<Animal>
            {
                new Animal { IdAnimal = 1, NomeAnimal = "Tobias", Especie = "Cachorro", SexoAnimal = "Macho", Vacinas = "Antirrábica;V8", Vermifugado = true, Castrado = true, HistoricoDoencas = "Nenhum"},
                new Animal { IdAnimal = 2, NomeAnimal = "Mia", Especie = "Gato", SexoAnimal = "Fêmea", Vacinas = "V4", Vermifugado = false, Castrado = true, HistoricoDoencas = "Dermatite" }
            };
        }

        //Atualiza o DataGridView
        private void AtualizarGrid()
        {
            dgvAnimais.DataSource = null;
            dgvAnimais.DataSource = listaAnimais;

            dgvAnimais.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimais.MultiSelect = false;
            dgvAnimais.ReadOnly = true;
        }

        private void rbNomeAnimal_CheckedChanged(object sender, EventArgs e)
        {
            filtroAtual = "NomeAnimal";
        }

        private void rbIDAnimal_CheckedChanged(object sender, EventArgs e)
        {
            filtroAtual = "IdAnimal";
        }

        private void txtPesquisarAnimal_TextChanged(object sender, EventArgs e)
        {

        }

        //Preenche os campos de detalhes
        private void ExibirDetalhes(Animal animal)
        {
            txtIdAnimal.Text = animal.IdAnimal.ToString();
            txtNomeAnimal.Text = animal.NomeAnimal;
            txtEspecie.Text = animal.Especie;
            txtSexoAnimal.Text = animal.SexoAnimal;
            txtVacinas.Text = animal.Vacinas;
            txtVermifugado.Text = animal.Vermifugado ? "Sim" : "Não";
            txtCastrado.Text = animal.Castrado ? "Sim" : "Não";
            txtHistoricoSaude.Text = animal.HistoricoDoencas;

        }

        private void btnEditar_Animal_Click(object sender, EventArgs e)
        {
            if (animalSelecionado == null)
            {
                MessageBox.Show("Selecione um animal antes de editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FrmAnimal frm = new FrmAnimal(animalSelecionado); // abrir tela de edição
            frm.ShowDialog();

            AtualizarGrid(); // atualiza após edição
        }

        private void btnExcluir_Animal_Click(object sender, EventArgs e)
        {
            if (animalSelecionado == null)
            {
                MessageBox.Show("Selecione um animal antes de excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resp = MessageBox.Show($"Tem certeza que deseja excluir o animal {animalSelecionado.NomeAnimal}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                listaAnimais.Remove(animalSelecionado);
                AtualizarGrid();
                MessageBox.Show("Animal excluído com sucesso!");
            }
        }

        private void dgvAnimais_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAnimais.SelectedRows.Count > 0)
            {
                var animal = dgvAnimais.SelectedRows[0].DataBoundItem as Animal;

                if (animal != null)
                {
                    // Atualiza o animal selecionado
                    animalSelecionado = animal;

                    // Exibe os dados nos campos de texto
                    txtIdAnimal.Text = animal.IdAnimal.ToString();
                    txtNomeAnimal.Text = animal.NomeAnimal;
                    txtEspecie.Text = animal.Especie;
                    txtSexoAnimal.Text = animal.SexoAnimal;
                    txtVacinas.Text = animal.Vacinas;
                    txtVermifugado.Text = animal.Vermifugado ? "Sim" : "Não";
                    txtCastrado.Text = animal.Castrado ? "Sim" : "Não";
                    txtHistoricoSaude.Text = animal.HistoricoDoencas;

                }
            }
        }

        private void btnPesquisar_Animal_Click(object sender, EventArgs e)
        {
            string termo = txtPesquisarAnimal.Text.ToLower();

            // Verifica se o campo está vazio
            if (string.IsNullOrWhiteSpace(termo))
            {
                MessageBox.Show("Digite algo para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var filtrados = listaAnimais.Where(a =>
                (filtroAtual == "NomeAnimal" && a.NomeAnimal.ToLower().Contains(termo)) ||
                (filtroAtual == "IdAnimal" && a.IdAnimal.ToString().Contains(termo))
            ).ToList();

            dgvAnimais.DataSource = null;
            dgvAnimais.DataSource = filtrados;
        }


        private void FrmGerenciarAnimal_FormClosing(object sender, FormClosingEventArgs e)
        {

            // Se o sistema está fechando porque Application.Exit() foi chamado,
            // não mostrar a mensagem novamente.
            if (e.CloseReason == CloseReason.ApplicationExitCall)
                return;

            //Exibe mensagem de confirmação
            var resultado = MessageBox.Show(
                "Deseja realmente sair do sistema?",
                "Confirmar saída",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            //se clica não, cancela o fechamento
            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            Application.Exit();

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }
    }
}
