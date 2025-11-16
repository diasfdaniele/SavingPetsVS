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
    public partial class FrmConsultarAnimal : Form
    {
        //LISTA DE SIMULAÇÃO DOS DADOS
        //SUBSTITUIR POR SELECT DO BANCO APÓS INTEGRAÇÃO
        private List<Animal> listaAnimal;

        //Comando para guardar tipo de filtro escolhido pelo usuário
        private string filtroAtual = "Nome";

        //Objeto que guarda o tutor selecionado no DataGrid
        private Animal animalSelecionado;
        public FrmConsultarAnimal()
        {
            InitializeComponent();

            //Carrega animais simulados (EM MEMÓRIA)
            //EM BANCO → CARREGAR DADOS VIA SELECT
            CarregarAnimalSimulados();

            //Atualiza o DataGrid com os dados da lista
            AtualizarGrid();

            //Evento disparado quando o usuário seleciona uma linha do DataGrid
            dgvAnimal.SelectionChanged += dgvAnimal_SelectionChanged;
        }

        //CLASSE QUE SIMULA O BANCO DE DADOS
        //ESTE TRECHO SERÁ REMOVIDO APÓS INTEGRAÇÃO COM BANCO
        private void CarregarAnimalSimulados()
        {
            listaAnimal = new List<Animal>
            {
                new Animal { IdAnimal = 2, NomeAnimal = "Thor", Especie = "cachorro"},
            };
        }

        //Exibição dos animais no DataGridView
        //EM BANCO → A LISTA VIRÁ DE UMA CONSULTA SQL (SELECT)
        private void AtualizarGrid()
        {
            dgvAnimal.DataSource = null;
            dgvAnimal.DataSource = listaAnimal;

            //Configurações do DataGrid
            dgvAnimal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimal.MultiSelect = false;
            dgvAnimal.ReadOnly = true;
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
            string termo = txtPesquisar.Text.ToLower(); //converte texto para minusculo

            //Filtra lista conforme tipo de filtro selecionado
            var filtrados = listaAnimal.Where(p =>
             (filtroAtual == "Nome" && p.NomeAnimal.ToLower().Contains(termo)) ||
             (filtroAtual == "ID" && p.IdAnimal.ToString().Contains(termo))
             ).ToList();

            //Exibe resultados filtrados
            dgvAnimal.DataSource = null;
            dgvAnimal.DataSource = filtrados;
        }

        private void dgvAnimal_SelectionChanged(object sender, EventArgs e)
        {
            //Verifica se há pelo menos uma linha selecionada
            if (dgvAnimal.SelectedRows.Count > 0)
            {
                //Recupera o objeto associado à linha selecionada
                var animal = dgvAnimal.SelectedRows[0].DataBoundItem as Animal;

                //Se for válido, armazena como processo selecionado
                if (animal != null)
                {
                    animalSelecionado = animal;
                    ExibirDetalhes(animalSelecionado);
                }
            }
        }

        //Exibe dados do processo nos TextBox
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
                //Envia o tutor por meio da propriedade Tag
                this.Tag = animalSelecionado;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                //Mensagem caso usuário tente confirmar sem selecionar nada
                MessageBox.Show("Selecione um tutor antes de confirmar.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
