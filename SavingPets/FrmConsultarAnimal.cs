using SavingPets.Controllers; // Importante
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SavingPets
{
    public partial class FrmConsultarAnimal : Form
    {
        // 1. Instância do Controller existente (sem alterações nele)
        private AnimalController controller = new AnimalController();

        // 2. Lista que receberá os dados vindos do Controller
        private List<Animal> listaAnimal = new List<Animal>();

        // Filtros e Seleção
        private string filtroAtual = "Nome";
        private Animal animalSelecionado;

        public FrmConsultarAnimal()
        {
            InitializeComponent();

            // 3. Substituímos a simulação pela chamada ao banco
            CarregarDadosBanco();

            // Configura o grid
            AtualizarGrid();

            // Liga evento de seleção
            dgvAnimal.SelectionChanged += dgvAnimal_SelectionChanged;
        }

        // Método que busca os dados reais usando o seu Controller atual
        private void CarregarDadosBanco()
        {
            try
            {
                // Chama o método ListarAnimais() que você já tem no controller
                // (aquele que busca IDs e depois os objetos)
                listaAnimal = controller.ListarAnimais();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar animais: " + ex.Message);
            }
        }

        private void AtualizarGrid()
        {
            dgvAnimal.DataSource = null;
            dgvAnimal.DataSource = listaAnimal;

            dgvAnimal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimal.MultiSelect = false;
            dgvAnimal.ReadOnly = true;

            // Importante: Esconder a coluna de lista "Vacinas" para não quebrar o visual do Grid
            if (dgvAnimal.Columns["Vacinas"] != null)
                dgvAnimal.Columns["Vacinas"].Visible = false;
        }

        // Método auxiliar para exibir resultados filtrados
        private void AtualizarGridFiltrado(List<Animal> listaFiltrada)
        {
            dgvAnimal.DataSource = null;
            dgvAnimal.DataSource = listaFiltrada;

            if (dgvAnimal.Columns["Vacinas"] != null)
                dgvAnimal.Columns["Vacinas"].Visible = false;
        }

        private void rbNome_CheckedChanged(object sender, EventArgs e)
        {
            filtroAtual = "Nome";
        }

        private void rbId_CheckedChanged(object sender, EventArgs e)
        {
            filtroAtual = "ID";
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string termo = txtPesquisar.Text.ToLower();

            if (listaAnimal == null || listaAnimal.Count == 0) return;

            // Filtro LINQ usando a lista carregada do banco
            var filtrados = listaAnimal.Where(a =>
                (filtroAtual == "Nome" && a.NomeAnimal.ToLower().Contains(termo)) ||
                (filtroAtual == "ID" && a.IdAnimal.ToString().Contains(termo))
            ).ToList();

            AtualizarGridFiltrado(filtrados);
        }

        private void dgvAnimal_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAnimal.SelectedRows.Count > 0)
            {
                var animal = dgvAnimal.SelectedRows[0].DataBoundItem as Animal;

                if (animal != null)
                {
                    animalSelecionado = animal;
                    ExibirDetalhes(animalSelecionado);
                }
            }
        }

        // Exibe dados nos textboxes laterais/inferiores
        private void ExibirDetalhes(Animal animal)
        {
            txtId.Text = animal.IdAnimal.ToString();
            txtNome.Text = animal.NomeAnimal;
            txtEspecie.Text = animal.Especie;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (animalSelecionado != null)
            {
                // Passa o objeto selecionado para quem chamou a tela (ex: Cadastro de Processo)
                this.Tag = animalSelecionado;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione um animal antes de confirmar.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}