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

        //Cria instâncias dos controladores que fazem a ponte entre a tela e a lógica do sistema
        ProcessoAdotivoController processoController = new ProcessoAdotivoController();
        private OcorrenciaController controladorOcorrencia = new OcorrenciaController();
        //Guarda o processo que o usuário escolheu
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
                //Validações para ajudar o usuário 
                //Verifica se o usuário escolheu um processo
                if (processoSelecionado == null)
                {
                    MessageBox.Show("Selecione um processo antes de cadastrar a ocorrência!");
                    return;
                }

                //Obrigatoriedade preenchimento da descrição do ocorrido
                if (string.IsNullOrWhiteSpace(txtDescricao.Text))
                {
                    MessageBox.Show("Preencha a descrição do ocorrido.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDescricao.Focus();
                    return;
                }

                //Obrigatoriedade preenchimento gravidade
                if (!rbBaixa.Checked && !rbMedia.Checked && !rbAlta.Checked)
                {
                    MessageBox.Show("Selecione a gravidade (Baixa, Média ou Alta).", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Cria uma nova ocorrência com os dados preenchidos
                Ocorrencia novaOcorrencia = new Ocorrencia
                {
                    Processo = processoSelecionado,
                    DataOcorrencia = dataOcorrido.Value,
                    Descricao = txtDescricao.Text.Trim(),
                    Gravidade = rbBaixa.Checked ? "Baixa" : rbMedia.Checked ? "Média" : "Alta",
                    ProvidenciaTomada = txtProvidencia.Text.Trim()
                };

                //Verifica qual gravidade foi selecionada
                if (rbBaixa.Checked)
                    novaOcorrencia.Gravidade = "Baixa";
                else if (rbMedia.Checked)
                    novaOcorrencia.Gravidade = "Média";
                else if (rbAlta.Checked)
                    novaOcorrencia.Gravidade = "Alta";

                //Cadastra a ocorrência (por enquanto, só em memória)
                //PARTE QUE PRECISA INTEGRAR BANCO
                controladorOcorrencia.CadastrarOcorrencia(novaOcorrencia);

                //Exibe mensagem de sucesso após conclusão do cadastro
                MessageBox.Show("Ocorrência cadastrada com sucesso!", "Sucesso",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpa os campos para o próximo cadastro
                txtNomeTutor.Clear();
                txtNomeAnimal.Clear();
                txtId.Clear();
                txtDescricao.Clear();
                txtProvidencia.Clear();
                rbBaixa.Checked = false;
                rbMedia.Checked = false;
                rbAlta.Checked = false;

            }
            catch (Exception ex)
            {
                //Mostra o texto da exceção
                MessageBox.Show("Erro ao cadastrar ocorrência: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Evento de click para pesquisar processo
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FrmConsultarProcesso frm = new FrmConsultarProcesso();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                processoSelecionado = (ProcessoAdotivo)frm.Tag;
                txtId.Text = processoSelecionado.IdProcesso.ToString();
                txtNomeTutor.Text = processoSelecionado.NomeTutor;
                txtNomeAnimal.Text = processoSelecionado.NomeAnimal;
                dataAdocao.Value = processoSelecionado.DataAdocao;
            }
        }

        //Botão de click para voltar ao menu inicial
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
