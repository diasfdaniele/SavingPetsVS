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
        public FrmTutor()
        {
            InitializeComponent();
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
    }
}
