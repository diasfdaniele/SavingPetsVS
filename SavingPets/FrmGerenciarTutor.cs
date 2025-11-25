using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SavingPets.Controllers;
using SavingPets.Models;

namespace SavingPets
{
    public partial class FrmGerenciarTutor : Form
    {
        //para aparecer temporariamente os dados no grid view
        private List<Tutor> listaTutores;
        private string filtroAtual = "CPF";
        private Tutor tutorSelecionado;


        /* private TutorController controller = new TutorController();
         private List<Tutor> listaTutores = new List<Tutor>();
         private Tutor tutorSelecionado;
         private string filtroAtual = "CPF";*/

        //para carregar os dados dentro do grid view
        private void CarregarTutoresSimulados()
        {
            listaTutores = new List<Tutor>
    {
        new Tutor {
            IdTutor = 1, IdAnimal = 100, NomeTutor = "Isabella Costa", SexoTutor = "Feminino",
            CPF = "44859914562", Telefone = "(19) 99999-1111", Email = "isabella@gmail.com",
            CEP = "13888469", Rua = "Rua das Flores", Numero = "100", Complemento = "Apto 54",
            Bairro = "Centro", Cidade = "Campinas", Estado = "SP"
        },

        new Tutor {
            IdTutor = 2, IdAnimal = 2, NomeTutor = "Daniele Souza", SexoTutor = "Masculino",
            CPF = "10365424937", Telefone = "(19) 98888-2222", Email = "daniele@gmail.com",
            CEP = "13426027", Rua = "Av. Brasil", Numero = "250", Complemento = "Casa 2",
            Bairro = "Taquaral", Cidade = "Campinas", Estado = "SP"
        }
    };
        }


        public FrmGerenciarTutor()
        {
            InitializeComponent();



            //para usar o grid view
            CarregarTutoresSimulados();
            AtualizarGrid();
            dgvTutores.SelectionChanged += dgvTutores_SelectionChanged;

            //antes do grid view
            rbCodigo_Tutor.Checked = true;
            CarregarTutores();
            AtualizarGrid();


            btnPesquisar_Tutor.Click += btnPesquisar_Tutor_Click;
            btnEditar_Tutor.Click += btnEditar_Tutor_Click;
            //btnExcluir_Tutor.Click += btnExcluir_Tutor_Click;
        }


        private void CarregarTutores()
        {
            //listaTutores = controller.ListarTutores(); //feito antes de usar o datagrid com exemplos

        }

        // Atualiza DataGrid
        private void AtualizarGrid()
        {
            dgvTutores.DataSource = null;
            dgvTutores.DataSource = listaTutores;

            dgvTutores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTutores.MultiSelect = false;
            dgvTutores.ReadOnly = true;
        }

        private void btnPesquisar_Tutor_Click(object sender, EventArgs e)
        {
            string termo = textBox1.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(termo))
            {
                MessageBox.Show("Digite algo para pesquisar.");
                return;
            }

            List<Tutor> filtrados = new List<Tutor>();

            if (rbCodigo_Tutor.Checked) // CPF
            {
                filtroAtual = "CPF";
                filtrados = listaTutores.Where(t => t.CPF.ToLower().Contains(termo)).ToList();
            }
            else if (rbNome_Tutor.Checked)
            {
                filtroAtual = "NomeTutor";
                filtrados = listaTutores.Where(t => t.NomeTutor.ToLower().Contains(termo)).ToList();
            }

            dgvTutores.DataSource = null;
            dgvTutores.DataSource = filtrados;
        }

        private void dgvTutores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTutores.SelectedRows.Count > 0)
            {
                //feito para colocar dados no grid view
                if (dgvTutores.SelectedRows.Count > 0)
                {
                    tutorSelecionado = dgvTutores.SelectedRows[0].DataBoundItem as Tutor;

                    if (tutorSelecionado != null)
                        ExibirDetalhes(tutorSelecionado);
                }

                //feito antes de adicionar os dados temporarios no grid view
                /*var tutor = dgvTutores.SelectedRows[0].DataBoundItem as Tutor;

                if (tutor != null)
                {
                    tutorSelecionado = tutor;
                    ExibirDetalhes(tutor);
                }*/

            }
        }

        private void ExibirDetalhes(Tutor t)
        {
            txtIdTutor.Text = t.IdTutor.ToString();
            txtIdAnimal.Text = t.IdAnimal.ToString();
            txtNomeTutor.Text = t.NomeTutor;
            txtSexoTutor.Text = t.SexoTutor;
            txtCPF.Text = t.CPF;
            txtTelefone.Text = t.Telefone;
            txtEmail.Text = t.Email;

            txtCep.Text = t.CEP;
            txtRua.Text = t.Rua;
            txtNumero.Text = t.Numero;
            txtComplemento.Text = t.Complemento;
            txtBairro.Text = t.Bairro;
            txtCidade.Text = t.Cidade;
            txtEstado.Text = t.Estado;
        }

        private void btnEditar_Tutor_Click(object sender, EventArgs e)
        {
            if (tutorSelecionado == null)
            {
                MessageBox.Show("Selecione um tutor para editar.");
                return;
            }

            FrmTutor frm = new FrmTutor(tutorSelecionado);
            frm.ShowDialog();

            CarregarTutores();
            AtualizarGrid();
        }

        private void btnExcluir_Tutor_Click(object sender, EventArgs e)
        {
            if (tutorSelecionado == null)
            {
                MessageBox.Show("Selecione um tutor para excluir.");
                return;
            }

            var confirm = MessageBox.Show(
                $"Deseja excluir o tutor {tutorSelecionado.NomeTutor}?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                //controller.ListarTutores().Remove(tutorSelecionado); //antes de usar os tutores simulados
                listaTutores.Remove(tutorSelecionado); //usando por conta dos tutores simulados
                MessageBox.Show("Tutor excluído com sucesso!");

                CarregarTutores();
                AtualizarGrid();
            }
        }

        private void FrmGerenciarTutor_FormClosing(object sender, FormClosingEventArgs e)
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

