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
    public partial class FrmInicial : Form
    {
        public FrmInicial()
        {
            InitializeComponent();

            //Comandos para deixar os label com plano de fundo do picturebox (imagem de fundo)
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label3.Parent = pictureBox1;

        }

        //Evento de clique do botão Login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            FrmLogin janela = new FrmLogin();
            Hide();
            janela.ShowDialog();
            Show();
        }
    }
}
