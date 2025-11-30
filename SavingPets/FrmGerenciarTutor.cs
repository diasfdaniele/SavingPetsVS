using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SavingPets.Controllers; // Importante
using SavingPets.Models;      // Importante

namespace SavingPets
{
    public partial class FrmGerenciarTutor : Form
    {
        // 1. Instância do Controller (A Conexão com o Banco)
        private TutorController controller = new TutorController();

        // 2. Lista para armazenar os dados vindos do BANCO
        private List<Tutor> listaTutores = new List<Tutor>();

        // Controle de seleção e filtro
        private Tutor tutorSelecionado;
        private string filtroAtual = "CPF";

        public FrmGerenciarTutor()
        {
            InitializeComponent();

            // Configuração inicial dos RadioButtons
            rbCodigo_Tutor.Checked = true;

            // 3. CARREGA DADOS DO BANCO (Substituindo a simulação)
            CarregarTutoresDoBanco();

            // Configura e exibe no Grid
            AtualizarGrid();

            // Liga eventos
            dgvTutores.SelectionChanged += dgvTutores_SelectionChanged;
            btnPesquisar_Tutor.Click += btnPesquisar_Tutor_Click;
            btnEditar_Tutor.Click += btnEditar_Tutor_Click;

            // O botão excluir precisa de um método no controller, se não tiver, comente a linha abaixo
            // btnExcluir_Tutor.Click += btnExcluir_Tutor_Click; 
        }

        // ========================================================
        // MÉTODO DE LEITURA (DO BANCO)
        // ========================================================
        private void CarregarTutoresDoBanco()
        {
            try
            {
                // Busca a lista real lá do MySQL através do Controller
                listaTutores = controller.ListarTutores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar tutores: " + ex.Message);
            }
        }

        // ========================================================
        // ATUALIZAÇÃO DO GRID
        // ========================================================
        private void AtualizarGrid()
        {
            dgvTutores.DataSource = null;
            dgvTutores.DataSource = listaTutores;

            dgvTutores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTutores.MultiSelect = false;
            dgvTutores.ReadOnly = true;

            // Dica: Esconder a coluna de animais para não poluir o grid
            if (dgvTutores.Columns["Animais"] != null)
                dgvTutores.Columns["Animais"].Visible = false;
        }

        // Atualiza grid com lista filtrada
        private void AtualizarGridFiltrado(List<Tutor> listaFiltrada)
        {
            dgvTutores.DataSource = null;
            dgvTutores.DataSource = listaFiltrada;
            if (dgvTutores.Columns["Animais"] != null) dgvTutores.Columns["Animais"].Visible = false;
        }

        // ========================================================
        // PESQUISA
        // ========================================================
        private void btnPesquisar_Tutor_Click(object sender, EventArgs e)
        {
            string termo = textBox1.Text.Trim().ToLower();

            if (listaTutores == null || listaTutores.Count == 0) return;

            // Se o campo estiver vazio, recarrega tudo
            if (string.IsNullOrWhiteSpace(termo))
            {
                AtualizarGrid();
                return;
            }

            List<Tutor> filtrados = new List<Tutor>();

            if (rbCodigo_Tutor.Checked) // Busca por CPF
            {
                filtroAtual = "CPF";
                filtrados = listaTutores.Where(t => t.CPF.ToLower().Contains(termo)).ToList();
            }
            else if (rbNome_Tutor.Checked) // Busca por Nome
            {
                filtroAtual = "NomeTutor";
                filtrados = listaTutores.Where(t => t.NomeTutor.ToLower().Contains(termo)).ToList();
            }

            AtualizarGridFiltrado(filtrados);
        }

        // ========================================================
        // SELEÇÃO NO GRID
        // ========================================================
        private void dgvTutores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTutores.SelectedRows.Count > 0)
            {
                tutorSelecionado = dgvTutores.SelectedRows[0].DataBoundItem as Tutor;

                if (tutorSelecionado != null)
                {
                    ExibirDetalhes(tutorSelecionado);
                }
            }
        }

        private void ExibirDetalhes(Tutor t)
        {
            txtIdTutor.Text = t.IdTutor.ToString();
            txtNomeTutor.Text = t.NomeTutor;
            txtSexoTutor.Text = t.SexoTutor;
            txtCPF.Text = t.CPF;
            txtTelefone.Text = t.Telefone;
            txtEmail.Text = t.Email;

            txtCep.Text = t.CEP;
            txtRua.Text = t.Rua;
            txtNumero.Text = t.Numero;
            txtComplemento.Text = t.Complemento;
            txtBairro.Text = t.Bairro;
            txtCidade.Text = t.Cidade;
            txtEstado.Text = t.Estado;
        }

        // ========================================================
        // BOTÕES DE AÇÃO
        // ========================================================
        private void btnEditar_Tutor_Click(object sender, EventArgs e)
        {
            if (tutorSelecionado == null)
            {
                MessageBox.Show("Selecione um tutor para editar.");
                return;
            }

            // Abre o form de cadastro passando o tutor selecionado
            FrmTutor frm = new FrmTutor(tutorSelecionado);
            frm.ShowDialog();

            // Ao voltar, recarrega os dados do banco para ver as mudanças
            CarregarTutoresDoBanco();
            AtualizarGrid();
        }

        private void btnExcluir_Tutor_Click(object sender, EventArgs e)
        {
            if (tutorSelecionado == null)
            {
                MessageBox.Show("Selecione um tutor para excluir.");
                return;
            }

            var confirm = MessageBox.Show(
                $"Deseja excluir o tutor {tutorSelecionado.NomeTutor}?\nIsso apagará também os animais e visitas vinculados.",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // AQUI VOCÊ PRECISARÁ CRIAR O MÉTODO 'ExcluirTutor' NO CONTROLLER
                    // controller.ExcluirTutor(tutorSelecionado.IdTutor); 

                    MessageBox.Show("Funcionalidade de exclusão precisa ser implementada no DAL/Controller.");

                    // Após excluir:
                    // CarregarTutoresDoBanco();
                    // AtualizarGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }
            }
        }

        // ========================================================
        // FECHAMENTO E NAVEGAÇÃO
        // ========================================================
        private void FrmGerenciarTutor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall) return;

            var resultado = MessageBox.Show("Deseja realmente sair do sistema?", "Confirmar saída", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            Application.Exit();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show(); // Garante que volta se o menu fechar apenas com Hide
        }
    }
}