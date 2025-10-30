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
    public partial class FrmAnimal : Form
    {
        public FrmAnimal()
        {
            InitializeComponent();
        }

        //Evento de clique cadastrar animal
        private void btnCadAnimal_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }

        //Evento de clique para voltar ao menu principal
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }
    }
}
