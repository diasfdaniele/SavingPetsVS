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
        bool sidebarExpand;
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

        //Evento de clique para acessar consulta de animais
        private void consultarAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGerenciarAnimal janela = new FrmGerenciarAnimal();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void editarAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGerenciarAnimal janela = new FrmGerenciarAnimal();
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

        //Evento de click para acessar consulta de tutor
        private void consultarTutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGerenciarTutor janela = new FrmGerenciarTutor();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void editarTutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGerenciarTutor janela = new FrmGerenciarTutor();
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
        private void registrarVisitaDomiciliarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmVisita janela = new FrmVisita();
            Hide();
            janela.ShowDialog();
            Show();
        }


        //Evento de click para cadastrar processo adotivo
        private void cadastrarProcessoAdotivoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCadastrarProcesso janela = new FrmCadastrarProcesso();
            Hide();
            janela.ShowDialog();
            Show();
        }


        //Evento de click para exibir consulta de processo adotivo 
        private void consultarProcessoAdotivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGerenciarProcessoAdotivo janela = new FrmGerenciarProcessoAdotivo();
            Hide();
            janela.ShowDialog();
            Show();
        }
        private void editarProcessoAdotivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGerenciarProcessoAdotivo janela = new FrmGerenciarProcessoAdotivo();
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

        //Evento de clique para cadastrar ocorrencia
        private void registrarOcorrênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOcorrencia janela = new FrmOcorrencia();
            Hide();
            janela.ShowDialog();
            Show();
        }

        //Evento de click para consultar ocorrencia
        private void consultarOcorrênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGerenciarOcorrencias janela = new FrmGerenciarOcorrencias();
            Hide();
            janela.ShowDialog();
            Show();
        }


        private void tmSideBar_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                fSideBar.Width -= 25;

                if (fSideBar.Width <= fSideBar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    tmSideBar.Stop();
                }
            }
            else
            {
                fSideBar.Width += 25;
                if (fSideBar.Width >= fSideBar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    tmSideBar.Stop();
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            tmSideBar.Start();
        }

        private void consultarVisitaDomiciliarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultarProcessoAdotivoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmGerenciarProcessoAdotivo janela = new FrmGerenciarProcessoAdotivo();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void editarExcluirProcessoAdotivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGerenciarProcessoAdotivo janela = new FrmGerenciarProcessoAdotivo();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGerenciarVisita janela = new FrmGerenciarVisita();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void editarExcluirVisitaDomiciliarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmGerenciarVisita janela = new FrmGerenciarVisita();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {

            // Se o sistema está fechando porque Application.Exit() foi chamado,
            // não mostrar a mensagem novamente.
            if (e.CloseReason == CloseReason.ApplicationExitCall)
                return;

            //Exibe mensagem de confirmação
            var resultado = MessageBox.Show(
                "Deseja realmente sair do sistema?",
                "Confirmar saída",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            //se clica não, cancela o fechamento
            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            Application.Exit();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
