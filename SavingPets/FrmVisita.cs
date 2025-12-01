using SavingPets.Controllers;
using SavingPets.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SavingPets
{
    public partial class FrmVisita : Form
    {
        private readonly VisitaController visitaController = new VisitaController();
        private ProcessoAdotivo processoSelecionado;
        private BindingSource listaObservacoes = new BindingSource();

        public FrmVisita()
        {
            InitializeComponent();
            // Carrega o ID assim que a tela abre
            CarregarProximoId();
            PreencherResponsavel();
        }

        // --- ATUALIZA O CAMPO COM O PRÓXIMO ID DA VISITA ---
        private void CarregarProximoId()
        {
            try
            {
                int proximoId = visitaController.ObterProximoId();
                txtIdVisita.Text = proximoId.ToString(); // << CORREÇÃO AQUI
            }
            catch
            {
                // Se der erro, deixa vazio ou trata conforme necessidade
                txtIdVisita.Text = "";
            }
        }

        private void PreencherResponsavel()
        {
            try
            {
                txtResponsavel.Text = visitaController.ObterNomeResponsavel();
            }
            catch { }
        }

        // BOTÃO PESQUISAR (Busca o Processo Adotivo)
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FrmConsultarProcesso lookup = new FrmConsultarProcesso();

            if (lookup.ShowDialog() == DialogResult.OK)
            {
                processoSelecionado = (ProcessoAdotivo)lookup.Tag;

                // txtId continua mostrando o ID do PROCESSO selecionado
                txtId.Text = processoSelecionado.IdProcesso.ToString();

                txtNomeAnimal.Text = processoSelecionado.Animal.NomeAnimal;
                txtNomeTutor.Text = processoSelecionado.Tutor.NomeTutor;
                dataAdocao.Value = processoSelecionado.DataAdocao;
            }
        }

        // BOTÃO CADASTRAR
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (processoSelecionado == null)
                {
                    MessageBox.Show("Selecione um processo de adoção.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtResponsavel.Text))
                {
                    MessageBox.Show("Informe o responsável pela visita.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtResponsavel.Focus();
                    return;
                }

                if (cbxStatusVisita.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione a situação da visita.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Visita visita = new Visita
                {
                    IdAdocao = processoSelecionado.IdProcesso,
                    IdVoluntario = 0,
                    DataVisita = dataVisita.Value,
                    Situacao = cbxStatusVisita.Text.Trim(),
                    DataAgendada = dataAdocao.Value,
                    Conclusao = "Acompanhamento Periódico",
                    Orientacoes = txtOrientacao.Text.Trim(),
                    Observacoes = listaObservacoes.List.Cast<string>().ToList(),
                    ObservacoesDetalhadas = new ObservacoesVisita()
                };

                visitaController.CadastrarVisita(visita);

                MessageBox.Show("Visita cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar visita:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            processoSelecionado = null;

            txtId.Clear(); // Limpa ID do Processo
                           // txtIdVisita.Clear(); // Não limpamos, nós recarregamos abaixo

            txtNomeTutor.Clear();
            txtNomeAnimal.Clear();
            txtObservacoes.Clear();
            cbxStatusVisita.SelectedIndex = -1;
            listaObservacoes.Clear();

            // Atualiza para o próximo ID disponível
            CarregarProximoId();

            // Garante que o nome do responsável continue lá
            PreencherResponsavel();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void FrmVisita_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall) return;

            if (MessageBox.Show("Deseja realmente sair?", "Confirmar saída", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}