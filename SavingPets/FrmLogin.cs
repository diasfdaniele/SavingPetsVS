using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SavingPets.DAL;

namespace SavingPets
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            //Comandos para deixar os label com plano de
            //fundo do picturebox (imagem)
            

            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label3.Parent = pictureBox1;
            label4.Parent = pictureBox1;
            label5.Parent = pictureBox1;
            label6.Parent = pictureBox1;
            label7.Parent = pictureBox1;

        }

        //Evento de clique para abrir página do menu principal
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                Login login = new Login();

                if (login.Logar(txtEmail.Text, txtSenha.Text))
                {
                    FrmMenu janela = new FrmMenu();
                    Hide();
                    janela.ShowDialog();
                    Show();
                }
                else if(string.IsNullOrEmpty(this.txtEmail.Text))
                {
                    MessageBox.Show("Por favor, preencha o Email.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtEmail.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(this.txtSenha.Text))
                {
                    MessageBox.Show("Por favor, informe sua senha.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtSenha.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("Email ou senha incorretos.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtEmail.Focus();
                    return;
                }

            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //Evento de clique para limpar os campos e-mail e senha
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtSenha.Clear();
        }

        //Evento de clique para registrar novo usuário voluntário
        //Falta desenvolver tela
        
    }
}
