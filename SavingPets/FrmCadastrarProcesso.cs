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

            // Configurações de Data
            dataAdocao.MaxDate = DateTime.Today; // Adoção não pode ser futura
            dataAgendamento.MinDate = DateTime.Today; // Visita deve ser futura ou hoje
        }

        private void btnCadastrarProcesso_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validações Prévias
                if (tutorSelecionado == null)
                    throw new Exception("Por favor, pesquise e selecione um tutor.");

                if (animalSelecionado == null)
                    throw new Exception("Por favor, pesquise e selecione um animal.");

                if (dataAdocao.Value.Date > DateTime.Today)
                    throw new Exception("A data de adoção não pode ser maior que hoje.");

                // 2. Criação do Objeto
                ProcessoAdotivo novo = new ProcessoAdotivo()
                {
                    IdProcesso = 0, // Novo cadastro
                    Tutor = tutorSelecionado,
                    Animal = animalSelecionado,
                    DataAdocao = dataAdocao.Value,
                    DataAgendamentoVisita = dataAgendamento.Value,
                    Observacoes = txtObservacoes.Text
                };

                // 3. Chamada ao Controller
                processoController.Cadastrar(novo);

                MessageBox.Show("Processo adotivo cadastrado com sucesso!",
                                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Limpeza
                LimparFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparFormulario()
        {
            // Limpa Tutor
            txtIdTutor.Clear();
            txtNomeTutor.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();

            // Limpa Animal
            txtIdAnimal.Clear();
            txtNomeAnimal.Clear();
            txtEspecie.Clear();
            txtCastrado.Clear();
            txtVermifugado.Clear();
            txtSexo.Clear();
            // txtVacinado.Clear();

            // Limpa Processo
            dataAdocao.Value = DateTime.Today;
            dataAgendamento.Value = DateTime.Today;
            txtObservacoes.Clear();

            // Reseta variáveis de controle
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

                    // Converte bool para Sim/Não para exibir no TextBox
                    txtCastrado.Text = animalSelecionado.Castrado ? "Sim" : "Não";
                    txtVermifugado.Text = animalSelecionado.Vermifugado ? "Sim" : "Não";
                }
            }
        }

        // Navegação
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