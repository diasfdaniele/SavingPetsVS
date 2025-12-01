using SavingPets.Controllers;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SavingPets
{
    public partial class FrmGerenciarVisita : Form
    {
        private readonly VisitaController visitaController = new VisitaController();
        private List<Visita> listaVisitas = new List<Visita>();

        public FrmGerenciarVisita()
        {
            InitializeComponent();
            CarregarVisitas();
            dgvVisita.CellClick += dgvVisita_CellClick;
        }

        // CARREGA TODAS AS VISITAS NO GRID
        private void CarregarVisitas()
        {
            try
            {
                // Garante que a lista nunca seja null
                listaVisitas = visitaController.ListarVisitas() ?? new List<Visita>();

                // Limpa o grid antes de atribuir os dados
                dgvVisita.DataSource = null;
                dgvVisita.DataSource = listaVisitas;

                // Ajusta as colunas do grid para mostrar apenas o que queremos
                AjustarColunas();

                // Se a lista estiver vazia, avisa o usuário
                if (listaVisitas.Count == 0)
                {
                    MessageBox.Show("Nenhuma visita cadastrada no sistema.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista de visitas:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // AJUSTA COLUNAS DO DATA GRID 
        private void AjustarColunas()
        {
            if (dgvVisita.Columns.Count == 0)
                return;

            // Colunas que queremos exibir
            if (dgvVisita.Columns.Contains("IdVisita"))
                dgvVisita.Columns["IdVisita"].HeaderText = "Código";

            if (dgvVisita.Columns.Contains("DataVisita"))
                dgvVisita.Columns["DataVisita"].HeaderText = "Data da Visita";

            if (dgvVisita.Columns.Contains("Responsavel"))
                dgvVisita.Columns["Responsavel"].HeaderText = "Responsável";

            if (dgvVisita.Columns.Contains("Situacao"))
                dgvVisita.Columns["Situacao"].HeaderText = "Situação";

            if (dgvVisita.Columns.Contains("DataAgendada"))
                dgvVisita.Columns["DataAgendada"].HeaderText = "Data Agendada";

            if (dgvVisita.Columns.Contains("Conclusao"))
                dgvVisita.Columns["Conclusao"].HeaderText = "Conclusão";

            // Oculta todas as colunas extras
            string[] colunasParaOcultar = { "IdAdocao", "IdProcessoAdotivo", "IdVoluntario", "Orientacoes", "Observacoes" };
            foreach (var col in colunasParaOcultar)
            {
                if (dgvVisita.Columns.Contains(col))
                    dgvVisita.Columns[col].Visible = false;
            }

            // Deixa o grid somente leitura e com seleção de linha completa
            dgvVisita.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVisita.MultiSelect = false;
            dgvVisita.ReadOnly = true;
        }

        // BOTÃO BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtPesquisar.Text.Trim();

            if (string.IsNullOrWhiteSpace(filtro))
            {
                CarregarVisitas();
                return;
            }

            try
            {
                var resultados = visitaController.BuscarVisita(filtro);

                dgvVisita.DataSource = null;
                dgvVisita.DataSource = resultados;

                AjustarColunas();

                if (resultados.Count == 0)
                {
                    MessageBox.Show("Nenhuma visita encontrada para o termo informado.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar visitas:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // MOSTRAR OBSERVAÇÕES EM POPUP AO CLICAR NA VISITA
        private void btnVerObservacoes_Click(object sender, EventArgs e)
        {
            if (dgvVisita.CurrentRow == null)
                return;

            int idVisita = Convert.ToInt32(dgvVisita.CurrentRow.Cells["IdVisita"].Value);

            try
            {
                List<string> observacoes = visitaController.ListarObservacoesPorVisita(idVisita);

                if (observacoes.Count == 0)
                {
                    MessageBox.Show("Esta visita não possui observações registradas.",
                        "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string texto = string.Join("\n• ", observacoes);

                MessageBox.Show("Observações desta visita:\n\n• " + texto,
                    "Observações", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exibir observações:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BOTÃO EXCLUIR VISITA + OBSERVAÇÕES
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvVisita.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma visita para excluir.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idVisita = Convert.ToInt32(dgvVisita.CurrentRow.Cells["IdVisita"].Value);

            var confirm = MessageBox.Show(
                "Tem certeza que deseja excluir esta visita?\n\nAs observações também serão removidas.",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.No)
                return;

            try
            {
                visitaController.ExcluirVisita(idVisita);

                MessageBox.Show("Visita excluída com sucesso!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarVisitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir visita:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BOTÃO ATUALIZAR LISTA
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarVisitas();
        }
        // BOTÃO VOLTAR
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }

        // CONFIRMAÇÃO QUANDO FECHA A JANELA
        private void FrmGerenciarVisita_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
                return;

            var result = MessageBox.Show(
                "Deseja realmente sair?",
                "Confirmar saída",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void dgvVisita_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex < 0) return;

                var visitaSelecionada = dgvVisita.Rows[e.RowIndex].DataBoundItem as Visita;
                if (visitaSelecionada == null) return;

                //CAMPOS BÁSICOS
                txtIdVisita.Text = visitaSelecionada.IdVisita.ToString();
                txtIdProcesso.Text = visitaSelecionada.IdProcessoAdotivo.ToString();
                txtResponsavel.Text = visitaSelecionada.Responsavel;
                txtStatus.Text = visitaSelecionada.Situacao;
                txtOrientacoes.Text = visitaSelecionada.Orientacoes;
                txtConclusao.Text = visitaSelecionada.Conclusao;

                dataVisita.Value = visitaSelecionada.DataVisita == DateTime.MinValue
                    ? DateTime.Now
                    : visitaSelecionada.DataVisita;

                dataAgendamento.Value = visitaSelecionada.DataAgendada == DateTime.MinValue
                    ? DateTime.Now
                    : visitaSelecionada.DataAgendada;

                //OBSERVAÇÕES LIVRES
                if (visitaSelecionada.Observacoes != null && visitaSelecionada.Observacoes.Count > 0)
                    txtObservacoes.Text = string.Join(Environment.NewLine, visitaSelecionada.Observacoes);
                else
                    txtObservacoes.Text = "";

                //OBSERVAÇÕES DETALHADAS
                var obs = visitaSelecionada.ObservacoesDetalhadas;
                if (obs != null)
                {
                    txtFisico.Text = obs.CondicaoFisica;
                    txtComportamento.Text = obs.Comportamento;
                    txtSaudavel.Text = obs.AparenciaSaudavel;
                    txtHigiene.Text = obs.CondicoesHigiene;
                    txtVacinado.Text = obs.Vacinado;
                    txtAcompanhamento.Text = obs.Acompanhamento;
                    txtAmbiente.Text = obs.CondicoesAmbiente;
                    txtMausTratos.Text = obs.IndicioMaustratos;
                    txtAdaptacao.Text = obs.Adaptacao;
                    txtRelacao.Text = obs.RelacaoTutor;
                    txtAlteracao.Text = obs.Alteracoes;

                    txtObservacoes.Text = obs.ObservacoesLivres;
                }
                else
                {
                    // Limpa tudo caso não tenha observações detalhadas
                    txtFisico.Clear();
                    txtComportamento.Clear();
                    txtSaudavel.Clear();
                    txtHigiene.Clear();
                    txtVacinado.Clear();
                    txtAcompanhamento.Clear();
                    txtAmbiente.Clear();
                    txtMausTratos.Clear();
                    txtAdaptacao.Clear();
                    txtRelacao.Clear();
                    txtAlteracao.Clear();
                    txtObservacoes.Clear();
                }
            }
        }
    }
}

