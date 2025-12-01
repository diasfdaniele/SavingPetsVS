using SavingPets.DAL;
using System;
using System.Drawing;
using System.Windows.Forms;
using static SavingPets.DAL.Login;

namespace SavingPets
{
    public partial class FrmMenu : Form
    {
        // Variável de controle da animação do menu
        

        public FrmMenu()
        {
            InitializeComponent();

            // Verifica se é administrador para mostrar/esconder o botão de configurações/admin
            // Nota: Se fSideBar for o menu todo, cuidado ao esconder ele inteiro. 
            // Talvez você queira esconder apenas um botão específico (ex: btnAlteracoes).
            bool IsAdministradorLogado = SessaoUsuario.IsAdministradorLogado;

            // Exemplo: Esconde o botão de Log de Alterações se não for admin
            if (!IsAdministradorLogado)
            {
                fSideBar.Visible = false;
                // fSideBar.Hide(); // CUIDADO: Isso esconde o menu todo! Só descomente se for a intenção.
            }
        }

       

        // ========================================================
        // EVENTOS DOS BOTÕES DO MENU (Navegação)
        // ========================================================

        // --- ANIMAIS ---
        private void btnAnimais_Click(object sender, EventArgs e)
        {
            cmsAnimais.Show(btnAnimais, new Point(btnAnimais.Width, 0));
        }

        private void cadastrarAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirJanela(new FrmAnimal());
        }

        private void consultarAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirJanela(new FrmGerenciarAnimal());
        }

        private void editarAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirJanela(new FrmGerenciarAnimal());
        }

        // --- TUTORES ---
        private void btnTutores_Click(object sender, EventArgs e)
        {
            cmsTutor.Show(btnTutores, new Point(btnTutores.Width, 0));
        }

        private void cadastrarTutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirJanela(new FrmTutor());
        }

        private void consultarTutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirJanela(new FrmGerenciarTutor());
        }

        private void editarTutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirJanela(new FrmGerenciarTutor());
        }

        // --- PROCESSO ADOTIVO ---
        private void btnProcesso_Click(object sender, EventArgs e)
        {
            cmsAdocao.Show(btnProcesso, new Point(btnProcesso.Width, 0));
        }

        private void cadastrarProcessoAdotivoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirJanela(new FrmCadastrarProcesso());
        }

        private void consultarProcessoAdotivoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirJanela(new FrmGerenciarProcessoAdotivo());
        }

        private void editarExcluirProcessoAdotivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirJanela(new FrmGerenciarProcessoAdotivo());
        }

        // --- VISITA DOMICILIAR ---
        private void registrarVisitaDomiciliarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirJanela(new FrmVisita());
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e) // Consultar Visita
        {
            AbrirJanela(new FrmGerenciarVisita());
        }

        private void editarExcluirVisitaDomiciliarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirJanela(new FrmGerenciarVisita());
        }

        // --- OCORRÊNCIAS ---
        private void btnOcorrencia_Click(object sender, EventArgs e)
        {
            cmsOcorrencia.Show(btnOcorrencia, new Point(btnOcorrencia.Width, 0));
        }

        private void registrarOcorrênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirJanela(new FrmOcorrencia());
        }

        private void consultarOcorrênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirJanela(new FrmGerenciarOcorrencias());
        }

        // --- OUTROS BOTÕES ---
        private void btnCadastrarVoluntario_Click(object sender, EventArgs e)
        {
            AbrirJanela(new FrmVoluntario());
        }

        private void btnEmitirRelatorio_Click(object sender, EventArgs e)
        {
            AbrirJanela(new FrmRelatorioGerencial());
        }

        private void btnAlteracoes_Click(object sender, EventArgs e)
        {
            AbrirJanela(new FrmAlteracoes());
        }

        // ========================================================
        // MÉTODOS AUXILIARES
        // ========================================================

        // Método genérico para abrir janelas e esconder o menu (Evita repetição de código)
        private void AbrirJanela(Form janela)
        {
            this.Hide();
            janela.ShowDialog();
            this.Show();
        }

        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall) return;

            var resultado = MessageBox.Show(
                "Deseja realmente sair do sistema?",
                "Confirmar saída",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }

        // Eventos vazios ou redundantes mantidos para compatibilidade com Designer
        private void fSideBar_Paint(object sender, PaintEventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void button1_Click_1(object sender, EventArgs e) { }
        private void btnMenuTutor_Click(object sender, EventArgs e) { btnTutores_Click(sender, e); }
        private void btnMenuProcesso_Click(object sender, EventArgs e) { btnProcesso_Click(sender, e); }
        private void btnMenuOcorrencia_Click(object sender, EventArgs e) { btnOcorrencia_Click(sender, e); }
        private void consultarProcessoAdotivoToolStripMenuItem_Click(object sender, EventArgs e) { AbrirJanela(new FrmGerenciarProcessoAdotivo()); }
        private void editarProcessoAdotivoToolStripMenuItem_Click(object sender, EventArgs e) { AbrirJanela(new FrmGerenciarProcessoAdotivo()); }
        private void consultarVisitaDomiciliarToolStripMenuItem_Click(object sender, EventArgs e) { }
    }
}