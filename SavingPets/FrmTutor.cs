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

                Tutor novo = new Tutor
                {
                    IdTutor = 0, // será gerado automaticamente
                    IdAnimal = string.IsNullOrWhiteSpace(txtIdAnimal.Text) ? 0 : int.Parse(txtIdAnimal.Text),
                    NomeTutor = txtNomeTutor.Text,
                    SexoTutor = sexoT,
                    CPF = txtCpf.Text,
                    Telefone = txtTelefone.Text,
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
