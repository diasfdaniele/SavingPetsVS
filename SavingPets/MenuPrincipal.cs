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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnAnimais_Click(object sender, EventArgs e)
        {
            CadastroAnimal janela = new CadastroAnimal();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void btnOcorrencia_Click(object sender, EventArgs e)
        {
            Ocorrencia janela = new Ocorrencia();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void btnTutores_Click(object sender, EventArgs e)
        {
            Tutores janela = new Tutores();
            Hide();
            janela.ShowDialog();
            Show();
        }
    }
}
