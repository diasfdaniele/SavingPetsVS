using SavingPets.Controllers;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavingPets
{
    public partial class FrmOcorrencia : Form
    {

        private OcorrenciaController controladorOcorrencia = new OcorrenciaController();
        private ProcessoAdotivo processoSelecionado;

        public FrmOcorrencia()
        {
            InitializeComponent();
        }

        //Evento de click para cadastrar ocorrencia
        private void btnCadastrarOcorrencia_Click(object sender, EventArgs e)
        {
            try
            {
                if (processoSelecionado == null)
                {
                    MessageBox.Show("Selecione um processo adotivo antes de cadastrar a ocorrência!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDescricao.Text))
                {
                    MessageBox.Show("Por favor, preencha a descrição do ocorrido.", "ATENÇÃO");
                    txtDescricao.Focus();
                    return;
                }

                if (!rbBaixa.Checked && !rbMedia.Checked && !rbAlta.Checked)
                {
                    MessageBox.Show("Por favor, selecione a gravidade da ocorrência.", "ATENÇÃO");
                    return;
                }

                // monta objeto de ocorrência
                Ocorrencia nova = new Ocorrencia
                {
                    Processo = processoSelecionado,
                    IdProcessoAdotivo = processoSelecionado.IdProcesso,
                    Descricao = txtDescricao.Text.Trim(),
                    DataOcorrencia = dataOcorrido.Value.Date,
                    ProvidenciaTomada = txtProvidencia.Text.Trim(),
                    Gravidade = rbBaixa.Checked ? "Baixa" : rbMedia.Checked ? "Media" : "Alta"
                };

                controladorOcorrencia.CadastrarOcorrencia(nova);

                MessageBox.Show("Ocorrência cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // limpa campos
                txtDescricao.Clear();
                txtProvidencia.Clear();
                rbBaixa.Checked = rbMedia.Checked = rbAlta.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar ocorrência: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Evento de click para pesquisar processo
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                using (FrmConsultarProcesso tela = new FrmConsultarProcesso())
                {
                    var resultado = tela.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        if (tela.Tag == null)
                        {
                            MessageBox.Show("A tela retornou OK, mas não enviou o processo selecionado (Tag == null).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        ProcessoAdotivo p = tela.Tag as ProcessoAdotivo;
                        if (p == null)
                        {
                            MessageBox.Show("O objeto retornado não é um ProcessoAdotivo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Preenche os campos no formulário
                        txtId.Text = p.IdProcesso.ToString();
                        txtNomeTutor.Text = p.Tutor?.NomeTutor ?? "";
                        txtNomeAnimal.Text = p.Animal?.NomeAnimal ?? "";
                        dataAdocao.Value = p.DataAdocao == DateTime.MinValue ? DateTime.Now.Date : p.DataAdocao;

                        // armazena também localmente para uso posterior 
                        this.processoSelecionado = p;
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir consulta de processos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Botão de click para voltar ao menu inicial
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void FrmOcorrencia_FormClosing(object sender, FormClosingEventArgs e)
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
