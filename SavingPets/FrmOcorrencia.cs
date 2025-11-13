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

        ProcessoAdotivoController processoController = new ProcessoAdotivoController();
        private OcorrenciaController controladorOcorrencia = new OcorrenciaController();
        //Guarda o processo que o usuário escolheu
        private ProcessoAdotivo processoSelecionado; 
         
        public FrmOcorrencia()
        {
            InitializeComponent();
        }

        private void btnCadastrarOcorrencia_Click(object sender, EventArgs e)
        {
            //Verifica se o usuário escolheu um processo
            if (processoSelecionado == null)
            {
                MessageBox.Show("Selecione um processo antes de cadastrar a ocorrência!");
                return;
            }

            //Cria uma nova ocorrência com os dados preenchidos
            Ocorrencia novaOcorrencia = new Ocorrencia();
            novaOcorrencia.Processo = processoSelecionado;
            novaOcorrencia.Descricao = txtDescricao.Text;
            novaOcorrencia.DataOcorrencia = dateTimePicker1.Value;
            novaOcorrencia.ProvidenciaTomada = txtProvidencia.Text;

            //Verifica qual gravidade foi selecionada
            if (rbBaixa.Checked)
                novaOcorrencia.Gravidade = "Gravidade Baixa";
            else if (rbMedia.Checked)
                novaOcorrencia.Gravidade = "Gravidade Média";
            else if (rbAlta.Checked)
                novaOcorrencia.Gravidade = "Gravidade Alta";

            //Cadastra a ocorrência (por enquanto, só em memória)
            //PARTE QUE PRECISA INTEGRAR BANCO
            controladorOcorrencia.CadastrarOcorrencia(novaOcorrencia);

            MessageBox.Show("Ocorrência cadastrada com sucesso!");

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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //Simulação: cria um processo só para teste
            //Necessário integrar com banco depois
            processoSelecionado = new ProcessoAdotivo();
            processoSelecionado.IdProcesso = 1;
            processoSelecionado.NomeTutor = "Maria Silva";
            processoSelecionado.NomeAnimal = "Rex";
            processoSelecionado.DataAdocao = new DateTime(2025, 01, 11);

            // Mostra as informações nos campos da tela
            txtNomeTutor.Text = processoSelecionado.NomeTutor;
            txtNomeAnimal.Text = processoSelecionado.NomeAnimal;
            txtId.Text = processoSelecionado.IdProcesso.ToString();
            dataAdocao.Value = processoSelecionado.DataAdocao;
        }

        //Botão de click para voltar ao menu inicial
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }


    }
}
