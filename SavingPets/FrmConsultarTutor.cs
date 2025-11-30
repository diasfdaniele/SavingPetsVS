using SavingPets.Controllers; // <--- 1. Importante: Adicionado namespace do Controller
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
    public partial class FrmConsultarTutor : Form
    {
        // <--- 2. Instância do Controller para conectar com o banco
        private TutorController controller = new TutorController();

        // Lista que receberá os dados do banco
        private List<Tutor> listaTutores = new List<Tutor>();

        //Comando para guardar tipo de filtro escolhido pelo usuário
        private string filtroAtual = "Nome";

        //Objeto que guarda o tutor selecionado no DataGrid
        private Tutor tutorSelecionado;

        public FrmConsultarTutor()
        {
            InitializeComponent();

            // <--- 3. Substituída a simulação pela carga real do banco
            CarregarDadosBanco();

            //Atualiza o DataGrid com os dados da lista
            AtualizarGrid();

            //Evento disparado quando o usuário seleciona uma linha do DataGrid
            dgvTutor.SelectionChanged += dgvTutor_SelectionChanged;
        }

        // <--- 4. Método Novo: Busca dados reais no MySQL via Controller
        private void CarregarDadosBanco()
        {
            try
            {
                listaTutores = controller.ListarTutores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar tutores: " + ex.Message);
            }
        }

        //Exibição dos tutores no DataGridView
        private void AtualizarGrid()
        {
            dgvTutor.DataSource = null;
            dgvTutor.DataSource = listaTutores;

            //Configurações do DataGrid
            dgvTutor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTutor.MultiSelect = false;
            dgvTutor.ReadOnly = true;

            // Opcional: Esconder coluna de lista de animais se ela existir e atrapalhar o grid
            if (dgvTutor.Columns["Animais"] != null)
                dgvTutor.Columns["Animais"].Visible = false;
        }

        // Método auxiliar para atualizar o grid com resultados de pesquisa
        private void AtualizarGridFiltrado(List<Tutor> listaFiltrada)
        {
            dgvTutor.DataSource = null;
            dgvTutor.DataSource = listaFiltrada;
            if (dgvTutor.Columns["Animais"] != null) dgvTutor.Columns["Animais"].Visible = false;
        }

        private void rbNome_CheckedChanged(object sender, EventArgs e)
        {
            filtroAtual = "Nome";
        }

        private void rbCpf_CheckedChanged(object sender, EventArgs e)
        {
            filtroAtual = "CPF";
        }

        private void rbId_CheckedChanged(object sender, EventArgs e)
        {
            filtroAtual = "ID";
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string termo = txtPesquisar.Text.ToLower(); //converte texto para minusculo

            if (listaTutores == null) return;

            // <--- 5. CORREÇÃO IMPORTANTE DE BUG --->
            // Antes estava 'tutorSelecionado.Nome...', o que causava erro se nada estivesse selecionado.
            // Agora usamos 't' (o item da lista sendo verificado).
            var filtrados = listaTutores.Where(t =>
                (filtroAtual == "Nome" && t.NomeTutor.ToLower().Contains(termo)) ||
                (filtroAtual == "CPF" && t.CPF.ToLower().Contains(termo)) ||
                (filtroAtual == "ID" && t.IdTutor.ToString().Contains(termo))
            ).ToList();

            //Exibe resultados filtrados
            AtualizarGridFiltrado(filtrados);
        }

        private void dgvTutor_SelectionChanged(object sender, EventArgs e)
        {
            //Verifica se há pelo menos uma linha selecionada
            if (dgvTutor.SelectedRows.Count > 0)
            {
                //Recupera o objeto associado à linha selecionada
                var tutor = dgvTutor.SelectedRows[0].DataBoundItem as Tutor;

                //Se for válido, armazena como processo selecionado
                if (tutor != null)
                {
                    tutorSelecionado = tutor;
                    ExibirDetalhes(tutorSelecionado);
                }
            }
        }

        //Exibe dados do processo nos TextBox
        private void ExibirDetalhes(Tutor tutor)
        {
            txtId.Text = tutor.IdTutor.ToString();
            txtNome.Text = tutor.NomeTutor;
            txtCpf.Text = tutor.CPF;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (tutorSelecionado != null)
            {
                //Envia o tutor por meio da propriedade Tag
                this.Tag = tutorSelecionado;
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