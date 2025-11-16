using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SavingPets.Models;
using SavingPets.Controllers;

namespace SavingPets
{
    public partial class FrmCadastrarProcesso : Form
    {
        private Tutor tutorSelecionado = null;
        private Animal animalSelecionado = null;

        private TutorController tutorController = new TutorController();
        private AnimalController animalController = new AnimalController();
        private ProcessoAdotivoController processoController = new ProcessoAdotivoController();
        public FrmCadastrarProcesso()
        {
            InitializeComponent();
        }

        private void btnCadastrarProcesso_Click(object sender, EventArgs e)
        {
            /*DEPENDE DO BACKEND DE ANIMAL E TUTOR
             * try
            {
                // Cria o objeto ProcessoAdotivo com base nos dados inseridos
                ProcessoAdotivo novo = new ProcessoAdotivo
                {
                    NomeTutor = txtNomeTutor.Text,
                    CpfTutor = txtCpf.Text,
                    TelefoneTutor = txtTelefone.Text,
                    EmailTutor = txtEmail.Text,
                    EnderecoTutor = txtEndereco.Text,

                    NomeAnimal = txtNomeAnimal.Text,
                    Especie = txtEspecie.Text,
                    Sexo = txtSexo.Text,
                    Castrado = txtCastrado.Text.ToLower() == "sim",
                    Vermifugado = txtVermifugado.Text.ToLower() == "sim",
                    Vacinacao = txtVacinado.Text,

                    DataAdocao = dataAdocao.Value,
                    AgendamentoVisita = dataAgendamento.Value,
                    Observacoes = txtObservacoes.Text
                };

                processoController.CadastrarProcesso(novo);

                MessageBox.Show("Processo adotivo cadastrado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtNomeTutor.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtNomeAnimal.Clear();
            txtEspecie.Clear();
            txtSexo.Clear();
            txtCastrado.Clear();
            txtVermifugado.Clear();
            txtVacinado.Clear();
            txtObservacoes.Clear();*/
            //DEPENDE DO BACKEND DE ANIMAL E TUTOR
        }

        private void FrmCadastrarProcesso_Load(object sender, EventArgs e)
        {

        }

        private void FrmCadastrarProcesso_Load_1(object sender, EventArgs e)
        {

        }

        private void btnPesquisarTutor_Click(object sender, EventArgs e)
        {

        }
    }
}

