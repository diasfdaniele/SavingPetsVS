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
        //LISTA DE SIMULAÇÃO DOS DADOS
        //SUBSTITUIR POR SELECT DO BANCO APÓS INTEGRAÇÃO
        private List<Tutor> listaTutor;

        //Comando para guardar tipo de filtro escolhido pelo usuário
        private string filtroAtual = "Nome";

        //Objeto que guarda o tutor selecionado no DataGrid
        private Tutor tutorSelecionado;
        public FrmConsultarTutor()
        {
            InitializeComponent();

            //Carrega tutor simulados (EM MEMÓRIA)
            //EM BANCO → CARREGAR DADOS VIA SELECT
            CarregarTutorSimulados();

            //Atualiza o DataGrid com os dados da lista
            AtualizarGrid();

            //Evento disparado quando o usuário seleciona uma linha do DataGrid
            dgvTutor.SelectionChanged += dgvTutor_SelectionChanged;
        }

        //CLASSE QUE SIMULA O BANCO DE DADOS
        //ESTE TRECHO SERÁ REMOVIDO APÓS INTEGRAÇÃO COM BANCO
        private void CarregarTutorSimulados()
        {
            listaTutor = new List<Tutor>
            {
                new Tutor { IdTutor = 1, NomeTutor = "Ana Souza", CPF = "41233652466", Email = "ana@email", Telefone = "19998512233"},
            };
        }

        //Exibição dos tutores no DataGridView
        //EM BANCO → A LISTA VIRÁ DE UMA CONSULTA SQL (SELECT)
        private void AtualizarGrid()
        {
            dgvTutor.DataSource = null;
            dgvTutor.DataSource = listaTutor;

            //Configurações do DataGrid
            dgvTutor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTutor.MultiSelect = false;
            dgvTutor.ReadOnly = true;
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

            //Filtra lista conforme tipo de filtro selecionado
            var filtrados = listaTutor.Where(p =>
                (filtroAtual == "Nome" && tutorSelecionado.NomeTutor.ToLower().Contains(termo)) ||
                (filtroAtual == "CPF" && tutorSelecionado.CPF.ToLower().Contains(termo)) ||
                (filtroAtual == "Id" && tutorSelecionado.IdTutor.ToString().Contains(termo))
            ).ToList();

            //Exibe resultados filtrados
            dgvTutor.DataSource = null;
            dgvTutor.DataSource = filtrados;
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

