using SavingPets.Controllers;
using SavingPets.Models;
using System;
using System.Windows.Forms;

namespace SavingPets
{
    public partial class FrmCadastrarProcesso : Form
    {
        // Controllers usados pela tela
        private ProcessoAdotivoController processoController = new ProcessoAdotivoController();

        // Guardam os objetos selecionados na busca
        private Tutor tutorSelecionado;
        private Animal animalSelecionado;

        public FrmCadastrarProcesso()
        {
            InitializeComponent();

            // Define data mínima como hoje
            dataAdocao.MinDate = DateTime.Today.AddYears(-5);
            dataAgendamento.MinDate = DateTime.Today;
        }

        private void btnCadastrarProcesso_Click(object sender, EventArgs e)
        {
            try
            {
                // Validações de Tela
                if (tutorSelecionado == null)
                    throw new Exception("Por favor, selecione um tutor.");

                if (animalSelecionado == null)
                    throw new Exception("Por favor, selecione um animal.");

                if (dataAdocao.Value.Date > DateTime.Today)
                    throw new Exception("A data de adoção não pode ser futura.");

                // Cria Objeto
                ProcessoAdotivo novo = new ProcessoAdotivo()
                {
                    Tutor = tutorSelecionado,
                    Animal = animalSelecionado,
                    DataAdocao = dataAdocao.Value,
                    AgendamentoVisita = dataAgendamento.Value, // Campo novo do banco
                    Observacoes = txtObservacoes.Text
                };

                // Chama Controller -> DAL -> Banco
                processoController.Cadastrar(novo);

                MessageBox.Show("Processo adotivo cadastrado com sucesso!",
                                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparFormulario()
        {
            txtIdTutor.Clear();
            txtNomeTutor.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();

            txtIdAnimal.Clear();
            txtNomeAnimal.Clear();
            txtEspecie.Clear();
            txtCastrado.Clear();
            txtVermifugado.Clear();

            dataAdocao.Value = DateTime.Today;
            dataAgendamento.Value = DateTime.Today;
            txtObservacoes.Clear();

            tutorSelecionado = null;
            animalSelecionado = null;
        }

        private void btnPesquisarTutor_Click(object sender, EventArgs e)
        {
            FrmConsultarTutor frm = new FrmConsultarTutor();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                tutorSelecionado = (Tutor)frm.Tag;
                if (tutorSelecionado != null)
                {
                    txtIdTutor.Text = tutorSelecionado.IdTutor.ToString();
                    txtNomeTutor.Text = tutorSelecionado.NomeTutor;
                    txtCpf.Text = tutorSelecionado.CPF;
                    txtTelefone.Text = tutorSelecionado.Telefone;
                    txtEmail.Text = tutorSelecionado.Email;
                }
            }
        }

        private void btnPesquisarAnimal_Click(object sender, EventArgs e)
        {
            FrmConsultarAnimal frm = new FrmConsultarAnimal();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                animalSelecionado = (Animal)frm.Tag;
                if (animalSelecionado != null)
                {
                    txtIdAnimal.Text = animalSelecionado.IdAnimal.ToString();
                    txtNomeAnimal.Text = animalSelecionado.NomeAnimal;
                    txtEspecie.Text = animalSelecionado.Especie;
                    txtSexo.Text = animalSelecionado.SexoAnimal;
                    txtCastrado.Text = animalSelecionado.Castrado;
                    txtVermifugado.Text = animalSelecionado.Vermifugado;
                    // txtVacinado.Text = animalSelecionado.Vacinas.ToString(); // Ajustar se tiver lista
                }
            }
        }

        // Navegação e Fechamento
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void FrmCadastrarProcesso_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall) return;

            var resultado = MessageBox.Show("Deseja realmente sair do sistema?", "Confirmar saída",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            Application.Exit();
        }
    }
}