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
    public partial class FrmOcorrencia : Form
    {
        FrmMenu frmMenuPrincipal;
        public FrmOcorrencia(FrmMenu frmMenuPrincipal)
        {
            InitializeComponent();
        }

        private void FrmOcorrencia_FormClosed(object sender, FormClosedEventArgs e)
        {
            
                frmMenuPrincipal.Close();
        }

        private void btnCadastrarOcorrencia_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }
    }
}
