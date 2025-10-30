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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        //Evento de clique botão lateral animais
        private void btnAnimais_Click(object sender, EventArgs e)
        {
            //Comando para exibição menu lateral
            int x = btnAnimais.Width;   
            int y = 0;                 

            cmsAnimais.Show(btnAnimais, new Point(x, y));
        }

        //Evento de clique botão lateral animais
        private void button1_Click(object sender, EventArgs e)
        {
            // Comando para exibição menu lateral
            int x = btnAnimais.Width;
            int y = 0;

            cmsAnimais.Show(btnAnimais, new Point(x, y));

        }

        //Evento de clique para acessar cadastro de animais
        private void cadastrarAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAnimal janela = new FrmAnimal();
            Hide();
            janela.ShowDialog();
            Show();
        }

        //Evento de clique botão lateral tutor
        private void btnTutores_Click(object sender, EventArgs e)
        {
            // Comando para exibição menu lateral
            int x = btnTutores.Width;
            int y = 0;

            cmsTutor.Show(btnTutores, new Point(x, y));
        }

        //Evento de clique botão lateral tutor
        private void btnMenuTutor_Click(object sender, EventArgs e)
        {
            // Comando para exibição menu lateral
            int x = btnTutores.Width;
            int y = 0;

            cmsTutor.Show(btnTutores, new Point(x, y));
        }

        //Evento de clique para acessar cadastro de tutor
        private void cadastrarTutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTutor janela = new FrmTutor();
            Hide();
            janela.ShowDialog();
            Show();
        }

        //Evento de clique para menu lateral processo adotivo
        private void btnProcesso_Click(object sender, EventArgs e)
        {
            // Comando para exibição menu lateral
            int x = btnProcesso.Width;
            int y = 0;

            cmsAdocao.Show(btnProcesso, new Point(x, y));
        }
        private void btnMenuProcesso_Click(object sender, EventArgs e)
        {
            // Comando para exibição menu lateral
            int x = btnProcesso.Width;
            int y = 0;

            cmsAdocao.Show(btnProcesso, new Point(x, y));
        }

        //Comando para acessar tela da visita domiciliar
        private void registrarVisitaDomiciliarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVisita janela = new FrmVisita();
            Hide();
            janela.ShowDialog();
            Show();
        }

        //Comando para exibição menu lateral ocorrencias
        private void btnOcorrencia_Click(object sender, EventArgs e)
        {
            // Comando para exibição menu lateral
            int x = btnOcorrencia.Width;
            int y = 0;

            cmsOcorrencia.Show(btnOcorrencia, new Point(x, y));
        }

        private void btnMenuOcorrencia_Click(object sender, EventArgs e)
        {
            // Comando para exibição menu lateral
            int x = btnOcorrencia.Width;
            int y = 0;

            cmsOcorrencia.Show(btnOcorrencia, new Point(x, y));
        }

        private void registrarOcorrênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOcorrencia janela = new FrmOcorrencia(this);
            Hide();
            janela.ShowDialog();
            Show();
        }
    }
}
