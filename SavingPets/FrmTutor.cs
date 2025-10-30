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
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }
    }
}
