using SavingPets.Controllers;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SavingPets
{
    public partial class FrmTutor : Form
    {
        private Tutor tutorEmEdicao = null;
        public FrmTutor()
        {
            InitializeComponent();
        }

        public FrmTutor(Tutor tutorEditado)
        {
            InitializeComponent();
            tutorEmEdicao = tutorEditado;
            PreencherCampos(tutorEditado);
        }

        private void PreencherCampos(Tutor t)
        {
            txtIdTutor.Text = t.IdTutor.ToString();
            txtIdAnimal.Text = t.IdAnimal.ToString();
            txtNomeTutor.Text = t.NomeTutor;

            if (t.SexoTutor == "Masculino")
                rbMasculino.Checked = true;
            else if (t.SexoTutor == "Feminino")
                rbFeminino.Checked = true;

            txtCpf.Text = t.CPF;
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


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            bool modoEdicao = tutorEmEdicao != null;

            try
            {
                TutorController controller = new TutorController();

                string sexoT = "";
                if (rbMasculino.Checked)
                    sexoT = "Masculino";
                else if (rbFeminino.Checked)
                    sexoT = "Feminino";
                else
                {
                    MessageBox.Show("Selecione o sexo do tutor!");
                    return;
                }

                //Verifica campos obrigatórios
                if (string.IsNullOrEmpty(txtNomeTutor.Text) ||
                    string.IsNullOrEmpty(txtCpf.Text) ||
                    string.IsNullOrEmpty(txtEmail.Text) ||
                    string.IsNullOrEmpty(txtTelefone.Text) ||
                    string.IsNullOrEmpty(txtCep.Text) ||
                    string.IsNullOrEmpty(txtRua.Text) ||
                    string.IsNullOrEmpty(txtNumero.Text) ||
                    string.IsNullOrEmpty(txtBairro.Text) ||
                    string.IsNullOrEmpty(txtCidade.Text) ||
                    string.IsNullOrEmpty(txtEstado.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios (apenas complemento é opcional)!",
                        "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //aqui pega os valores dos campos cpf e email
                string cpf = txtCpf.Text.Trim();
                string email = txtEmail.Text.Trim();
                string telefone = txtTelefone.Text.Trim();
                string cep = txtCep.Text.Trim();

                //validação de CPF
                if (!Validacoes.ValidarCPF(cpf))
                {
                    MessageBox.Show("CPF inválido! Verifique e tente novamente.",
                        "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCpf.Focus();
                    return; // Interrompe o cadastro
                }

                //validação de e-mail
                if (!Validacoes.ValidarEmail(email))
                {
                    MessageBox.Show("E-mail inválido! Verifique e tente novamente.",
                        "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                //validação de telefone
                if (!Validacoes.ValidarTelefone(telefone))
                {
                    MessageBox.Show("Telefone inválido! Verifique o número digitado.\nUse o formato (DDD) 99999-9999.",
                        "Telefone inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefone.Focus();
                    return;
                }

                //validação de CEP
                if (!Validacoes.ValidarCEP(cep))
                {
                    MessageBox.Show("CEP inválido! O formato deve conter 8 números, ex: 12345-678.",
                        "CEP inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCep.Focus();
                    return;
                }

                Tutor novo = new Tutor
                {
                    IdTutor = 0, //será gerado automaticamente
                    IdAnimal = string.IsNullOrWhiteSpace(txtIdAnimal.Text) ? 0 : int.Parse(txtIdAnimal.Text),
                    NomeTutor = txtNomeTutor.Text,
                    SexoTutor = sexoT,
                    CPF = txtCpf.Text,
                    Telefone = telefone,
                    Email = txtEmail.Text,
                    CEP = txtCep.Text,
                    Rua = txtRua.Text,
                    Numero = txtNumero.Text,
                    Complemento = txtComplemento.Text,
                    Bairro = txtBairro.Text,
                    Cidade = txtCidade.Text,
                    Estado = txtEstado.Text
                };

                controller.CadastrarTutor(novo);
                MessageBox.Show($"Tutor cadastrado com sucesso!");

                txtIdTutor.Text = controller.ObterProximoId().ToString();
                LimparCampos();


                if (modoEdicao)
                {
                    //editar
                    novo.IdTutor = tutorEmEdicao.IdTutor; //garante que o ID não muda

                    controller.EditarTutor(novo);
                    MessageBox.Show("Tutor editado com sucesso!");
                }
                else
                {
                    // CADASTRAR
                    controller.CadastrarTutor(novo);
                    MessageBox.Show("Tutor cadastrado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void FrmTutor_Load(object sender, EventArgs e)
        {
            try
            {
                TutorController controller = new TutorController();

                int proximoId = controller.ObterProximoId();
                txtIdTutor.Text = proximoId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar próximo ID: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            txtIdAnimal.Clear();
            txtNomeTutor.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtCep.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            rbMasculino.Checked = false;
            rbFeminino.Checked = false;
        }

        private void FrmTutor_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
