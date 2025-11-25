using Org.BouncyCastle.Asn1.Cmp;
using SavingPets.Controllers;
using SavingPets.Models;
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
    public partial class FrmVisita : Form
    {
        // Controladores
        private ProcessoAdotivoController processoController = new ProcessoAdotivoController();
        private VisitaController visitaController = new VisitaController();

        // Guarda o processo selecionado pelo usuário
        private ProcessoAdotivo processoSelecionado;

        public FrmVisita()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FrmConsultarProcesso frm = new FrmConsultarProcesso();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                processoSelecionado = (ProcessoAdotivo)frm.Tag;

                // Preenche os campos na tela
                txtId.Text = processoSelecionado.IdProcesso.ToString();
                txtNomeTutor.Text = processoSelecionado.Tutor.NomeTutor;
                txtNomeAnimal.Text = processoSelecionado.Animal.NomeAnimal;
                dataAdocao.Value = processoSelecionado.DataAdocao;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDAÇÕES DA INTERFACE

                if (processoSelecionado == null)
                {
                    MessageBox.Show("Por favor, selecione primeiro um processo adotivo.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtResponsavel.Text))
                {
                    MessageBox.Show("Por favor, informe o responsável pela visita.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtResponsavel.Focus();
                    return;
                }

                if (cbxStatusVisita.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione o status da visita.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbxFisico.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, informe a condição física do animal.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbxComportamento.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, informe o comportamento do animal.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!rbSeguro.Checked && !rbSatisfatorio.Checked && !rbInseguro.Checked)
                {
                    MessageBox.Show("Por favor, selecione a condição do ambiente.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!rbSim.Checked && !rbNao.Checked && !rbDuvida.Checked)
                {
                    MessageBox.Show("Por favor, informe se há indícios de maus-tratos.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // CRIA OBJETO VISITA
                Visita novaVisita = new Visita
                {
                    Processo = processoSelecionado,
                    DataVisita = dataVisita.Value,
                    Responsavel = txtResponsavel.Text.Trim(),
                    Status = cbxStatusVisita.Text,

                    // Bem-estar
                    CondicaoFisica = cbxFisico.Text,
                    Comportamento = cbxComportamento.Text,
                    AnimalSaudavel = cbxSaudavel.Text,
                    CondicoesHigiene = cbxHigiene.Text,
                    VacinasEmDia = rbVacinado.Checked ? "Sim" : "Não",
                    AcompanhamentoVeterinario = rbAcompanhado.Checked ? "Sim" : "Não",

                    // Ambiente
                    CondicaoAmbiente =
                        rbSeguro.Checked ? "Seguro" :
                        rbSatisfatorio.Checked ? "Adequado" : "Inseguro",

                    MausTratos =
                        rbSim.Checked ? "Sim" :
                        rbNao.Checked ? "Não" : "Em dúvida",

                    // Adaptação
                    AdaptacaoAmbiente = cbxAdaptacao.Text,
                    RelacaoTutor = cbxRelacao.Text,
                    AlteracoesComportamento = txtComportamento.Text.Trim(),

                    // Recomendações
                    OrientacoesDadas = txtOrientacao.Text.Trim(),
                    ProximaVisitaSugerida = dataAgendamento.Value,
                    Observacoes = txtObservacoes.Text.Trim(),
                    ConclusaoVisita = cbxConclusao.Text,
                };

                // ENVIA AO CONTROLLER (VALIDAÇÃO DE REGRA)

                visitaController.CadastrarVisita(novaVisita);

                MessageBox.Show("Visita cadastrada com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar visita: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtResponsavel.Clear();
            cbxStatusVisita.SelectedIndex = -1;

            cbxFisico.SelectedIndex = -1;
            cbxComportamento.SelectedIndex = -1;
            cbxSaudavel.SelectedIndex = -1;
            cbxHigiene.SelectedIndex = -1;

            rbVacinado.Checked = false;
            rbNaoVacinado.Checked = false;

            rbAcompanhado.Checked = false;
            rbNaoAcompanhado.Checked = false;

            rbSeguro.Checked = false;
            rbSatisfatorio.Checked = false;
            rbInseguro.Checked = false;

            rbSim.Checked = false;
            rbNao.Checked = false;
            rbDuvida.Checked = false;

            txtObservacoes.Clear();
            cbxAdaptacao.SelectedIndex = -1;
            cbxRelacao.SelectedIndex = -1;

            txtComportamento.Clear();
            txtOrientacao.Clear();

            cbxConclusao.SelectedIndex = -1;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVisita_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
