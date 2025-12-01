using SavingPets.Controllers;
using SavingPets.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SavingPets
{
    public partial class FrmVisita : Form
    {
        // Controller principal responsável por validar e salvar no banco
        private readonly VisitaController visitaController = new VisitaController();

        // Processo selecionado
        private ProcessoAdotivo processoSelecionado;

        // Lista temporária para armazenar observações antes de salvar no banco:
        private BindingSource listaObservacoes = new BindingSource();

        public FrmVisita()
        {
            InitializeComponent();
        }


        //BOTÃO PESQUISAR PROCESSO
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FrmConsultarProcesso lookup = new FrmConsultarProcesso();

            if (lookup.ShowDialog() == DialogResult.OK)
            {
                processoSelecionado = (ProcessoAdotivo)lookup.Tag;

                txtId.Text = processoSelecionado.IdProcesso.ToString();
                txtNomeAnimal.Text = processoSelecionado.Animal.NomeAnimal;
                txtNomeTutor.Text = processoSelecionado.Tutor.NomeTutor;
                dataAdocao.Value = processoSelecionado.DataAdocao;
            }
        }

        //BOTÃO CADASTRAR VISITA
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                //VALIDAÇÃO
                if (processoSelecionado == null)
                {
                    MessageBox.Show("Selecione um processo de adoção.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtResponsavel.Text))
                {
                    MessageBox.Show("Informe o responsável pela visita.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtResponsavel.Focus();
                    return;
                }

                if (cbxStatusVisita.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione a situação da visita.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //CRIA OBJETO VISITA PRINCIPAL
                Visita visita = new Visita
                {
                    IdAdocao = processoSelecionado.IdProcesso,
                    IdVoluntario = 1, // exemplo: pegar do usuário logado
                    DataVisita = dataVisita.Value,
                    Situacao = cbxStatusVisita.Text.Trim(),
                    DataAgendada = dataAdocao.Value, // ou outro campo de agendamento
                    Conclusao = "Acompanhamento Periódico", // valor padrão
                    Orientacoes = txtOrientacao.Text.Trim(), // se tiver campo no form
                    Observacoes = listaObservacoes.List.Cast<string>().ToList(),
                    ObservacoesDetalhadas = new ObservacoesVisita()
                };

                //ENVIA AO CONTROLLER
                visitaController.CadastrarVisita(visita);

                MessageBox.Show("Visita cadastrada com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar visita:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //LIMPAR CAMPOS
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            processoSelecionado = null;

            txtId.Clear();
            txtNomeTutor.Clear();
            txtNomeAnimal.Clear();
            txtResponsavel.Clear();
            txtObservacoes.Clear();

            cbxStatusVisita.SelectedIndex = -1;

            listaObservacoes.Clear();
        }

        //VOLTAR PARA O MENU
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }

        //CONFIRMAÇÃO AO FECHAR
        private void FrmVisita_FormClosing(object sender, FormClosingEventArgs e)
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


    }
}
