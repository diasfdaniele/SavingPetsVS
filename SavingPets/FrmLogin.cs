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

        //Evento de clique para efetuar login
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                //cria um novo login
                Login login = new Login();

                //Chama o metodo Logar, para tentar logar no sistema, se email e senha estiverem corretos, ele fecha e abre o menu
                if (login.Logar(txtEmail.Text, txtSenha.Text))//Testa se o login está correto
                {
                    FrmMenu janela = new FrmMenu();
                    Close();
                    janela.ShowDialog();
                    Show();
                }
                else if (string.IsNullOrEmpty(this.txtEmail.Text))//Se login não retornar nada, testa se o campo txtEmail está vazio
                {
                    MessageBox.Show("Por favor, digite seu e-mail.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);//Exibe mensagem de erro
                    this.txtEmail.Focus();//Move o cursor para o text box Email
                    return;
                }
                else if (string.IsNullOrEmpty(this.txtSenha.Text))//Se login não retornar nada e email está preenchido, testa se o campo txtSenha está vazio
                {
                    MessageBox.Show("Por favor, informe sua senha.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtSenha.Focus();
                    return;
                }
                else // Se não estavam vazios, email e senha, exibe mensagem de login inválido
                {
                    MessageBox.Show("Email ou senha incorretos.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtEmail.Focus();
                    return;
                }

            }
            catch (Exception ex) //Para erros de banco, servidor e Etc.
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Entre em contato com um administrador da AAANO!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }


    }


}

