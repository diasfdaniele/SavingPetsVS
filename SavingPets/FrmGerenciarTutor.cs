using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SavingPets.Controllers; // Namespace do Controller
using SavingPets.Models;      // Namespace do Model

namespace SavingPets
{
    public partial class FrmGerenciarTutor : Form
    {
        // 1. Instância do Controller (Ponte para o Banco)
        private TutorController controller = new TutorController();

        // 2. Lista para armazenar os dados vindos do banco
        private List<Tutor> listaTutores = new List<Tutor>();

        // Controle de seleção e filtro
        private Tutor tutorSelecionado;
        private string filtroAtual = "CPF";

        public FrmGerenciarTutor()
        {
            InitializeComponent();

            // Configuração inicial
            rbCodigo_Tutor.Checked = true;

            // 3. Carrega dados reais do banco ao abrir
            CarregarTutoresDoBanco();

            // Configura o Grid
            AtualizarGrid();

            // Foram removidos as linhas:
            // dgvTutores.SelectionChanged += dgvTutores_SelectionChanged;
            // btnPesquisar_Tutor.Click += btnPesquisar_Tutor_Click;
            // btnEditar_Tutor.Click += btnEditar_Tutor_Click;
            // btnExcluir_Tutor.Click += btnExcluir_Tutor_Click;
            // Poís geravam click duplo involuntário
        }

        // ========================================================
        // MÉTODO DE LEITURA (DO BANCO)
        // ========================================================
        private void CarregarTutoresDoBanco()
        {
            try
            {
                // Busca a lista atualizada no MySQL
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

            ConfigurarVisualGrid();
        }

        // Atualiza grid com lista filtrada
        private void AtualizarGridFiltrado(List<Tutor> listaFiltrada)
        {
            dgvTutores.DataSource = null;
            dgvTutores.DataSource = listaFiltrada;

            ConfigurarVisualGrid();
        }

        private void ConfigurarVisualGrid()
        {
            dgvTutores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTutores.MultiSelect = false;
            dgvTutores.ReadOnly = true;

            // Oculta coluna complexa se existir
            if (dgvTutores.Columns["Animais"] != null)
                dgvTutores.Columns["Animais"].Visible = false;
        }

        // ========================================================
        // PESQUISA
        // ========================================================
        private void btnPesquisar_Tutor_Click(object sender, EventArgs e)
        {
            string termo = textBox1.Text.Trim().ToLower();

            // Proteção contra lista vazia ou nula
            if (listaTutores == null || listaTutores.Count == 0) return;

            // Se vazio, mostra tudo
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

            // Ao voltar, recarrega os dados do banco para refletir a edição
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

            // Confirmação de segurança
            var confirm = MessageBox.Show(
                $"Deseja excluir o tutor {tutorSelecionado.NomeTutor}?\n" +
                "ATENÇÃO: Isso apagará todo o histórico, animais e visitas vinculados!",
                "Confirmar exclusão crítica",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // 🔥 CHAMA A EXCLUSÃO REAL NO BANCO
                    controller.ExcluirTutor(tutorSelecionado.IdTutor);

                    MessageBox.Show("Tutor excluído com sucesso!");

                    // Atualiza a tela
                    CarregarTutoresDoBanco();
                    AtualizarGrid();

                    // Limpa os campos de detalhes visualmente
                    LimparCamposDetalhes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimparCamposDetalhes()
        {
            txtIdTutor.Clear();
            txtNomeTutor.Clear();
            txtSexoTutor.Clear();
            txtCPF.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtCep.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            tutorSelecionado = null;
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
            Show();
        }
    }
}