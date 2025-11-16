using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SavingPets.Models;
using SavingPets.Controllers;

namespace SavingPets
{
    public partial class FrmGerenciarOcorrencias : Form
    {
        //CONTROLADOR DE OCORRÊNCIAS
        //OBJETO RESPONSÁVEL PELA PONTE ENTRE INTERFACE E DADOS
        //ATUALMENTE TRABALHA EM MEMÓRIA, MAS SERÁ AJUSTADO PARA BANCO (MySQL)
        private OcorrenciaController controladorOcorrencia = new OcorrenciaController();

        //LISTA TEMPORÁRIA DE OCORRÊNCIAS
        //ENQUANTO NÃO HÁ BANCO, ARMAZENA OS DADOS EM MEMÓRIA
        private List<Ocorrencia> listaOcorrencias = new List<Ocorrencia>();

        public FrmGerenciarOcorrencias()
        {
            InitializeComponent();

            //CONFIGURAÇÃO DO DATAGRID (EXIBE AUTOMATICAMENTE AS COLUNAS)
            dgvOcorrencias.AutoGenerateColumns = true;

            //CARREGA OCORRÊNCIAS PARA TESTE
            //DEVE SER SUBSTITUÍDO POR SELECT DO BANCO
            CarregarOcorrenciasExemplo();
        }

        //SIMULAÇÃO DE DADOS PARA TESTES INTERNOS
        //APÓS INTEGRAÇÃO COM MYSQL, ESTA FUNÇÃO SERÁ REMOVIDA
        private void CarregarOcorrenciasExemplo()
        {
            //Criação de objetos de processo apenas para teste
            //No banco, virão de SELECT com JOIN entre Processos e Ocorrências
            ProcessoAdotivo processo1 = new ProcessoAdotivo
            {
                IdProcesso = 1,
                Tutor = new Tutor { NomeTutor = "Maria Silva" },
                Animal = new Animal { NomeAnimal = "Rex" },
                DataAdocao = new DateTime(2025, 11, 11)
            };

            ProcessoAdotivo processo2 = new ProcessoAdotivo
            {
                IdProcesso = 2,
                Tutor = new Tutor { NomeTutor = "cleiton Silva" },
                Animal = new Animal { NomeAnimal = "nina" },
                DataAdocao = new DateTime(2025, 10, 10)
            };

            //Criação das ocorrências apenas em memória
            //No banco, o ID será gerado automaticamente (AUTO_INCREMENT)
            Ocorrencia o1 = new Ocorrencia
            {
                IdOcorrencia = 1,
                Processo = processo1,
                DataOcorrencia = new DateTime(2025, 11, 12),
                Descricao = "Animal sofrendo maus-tratos.",
                Gravidade = "Alta",
                ProvidenciaTomada = "Notificação e recolhimento do animal."
            };

            Ocorrencia o2 = new Ocorrencia
            {
                IdOcorrencia = 2,
                Processo = processo2,
                DataOcorrencia = new DateTime(2025, 11, 10),
                Descricao = "Animal fugiu temporariamente.",
                Gravidade = "Média",
                ProvidenciaTomada = "Animal encontrado e retornou ao lar."
            };

            //ARMAZENA AS OCORRÊNCIAS NA LISTA DA CAMADA DE CONTROLLER
            //APÓS INTEGRAÇÃO → CONTROLADOR IRÁ INSERIR NO BANCO
            controladorOcorrencia.CadastrarOcorrencia(o1);
            controladorOcorrencia.CadastrarOcorrencia(o2);
        }

        //ALTERA O TEXTO DO LABEL DE FILTRO CONFORME O RADIO BUTTON CLICADO
        private void rbNomeTutor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNomeTutor.Checked)
                lblFiltro.Text = "Nome do tutor:";
        }

        private void rbNomeAnimal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNomeAnimal.Checked)
                lblFiltro.Text = "Nome do animal:";
        }

        private void rbIdProcesso_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIdProcesso.Checked)
                lblFiltro.Text = "ID do processo:";
        }

        private void rbIdOcorrencia_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIdOcorrencia.Checked)
                lblFiltro.Text = "ID da ocorrência:";
        }

        //BOTÃO DE PESQUISA (LUPA)
        //FILTRA AS OCORRÊNCIAS CONFORME O TIPO DE FILTRO
        //APÓS INTEGRAÇÃO COM BANCO → UTILIZAR CONSULTA SQL COM WHERE
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string termo = txtPesquisarOcorrencias.Text.ToLower();
            List<Ocorrencia> resultados = new List<Ocorrencia>();

            //PEGA TODAS AS OCORRÊNCIAS CADASTRADAS
            //APÓS BANCO → SELECT * FROM ocorrencias
            listaOcorrencias = controladorOcorrencia.ListarOcorrencias();

            //APLICA FILTRO DE PESQUISA LOCALMENTE
            if (rbNomeTutor.Checked)
            {
                resultados = listaOcorrencias
                    .Where(o => o.Processo.Tutor.NomeTutor.ToLower().Contains(termo))
                    .ToList();
            }
            else if (rbNomeAnimal.Checked)
            {
                resultados = listaOcorrencias
                    .Where(o => o.Processo.Animal.NomeAnimal.ToLower().Contains(termo))
                    .ToList();
            }
            else if (rbIdProcesso.Checked && int.TryParse(termo, out int idProc))
            {
                resultados = listaOcorrencias
                    .Where(o => o.Processo.IdProcesso == idProc)
                    .ToList();
            }
            else if (rbIdOcorrencia.Checked && int.TryParse(termo, out int idOc))
            {
                resultados = listaOcorrencias
                    .Where(o => o.IdOcorrencia == idOc)
                    .ToList();
            }

            //EXIBE FILTRO NO DATAGRID
            dgvOcorrencias.DataSource = resultados;

            //MENSAGEM QUANDO NENHUMA OCORRÊNCIA É ENCONTRADA
            if (resultados.Count == 0)
            {
                MessageBox.Show("Nenhuma ocorrência encontrada.");
            }
        }

        //EVENTO DISPARADO AO CLICAR EM UMA LINHA DO DATAGRID
        //PREENCHE OS CAMPOS DA TELA COM OS DADOS DA LINHA SELECIONADA
        private void dgvOcorrencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Ocorrencia ocorrenciaSelecionada = (Ocorrencia)dgvOcorrencias.Rows[e.RowIndex].DataBoundItem;

                //PREENCHE CAMPOS DA TELA COM OS DADOS DA OCORRÊNCIA
                txtNomeTutor.Text = ocorrenciaSelecionada.Processo.Tutor.NomeTutor;
                txtNomeAnimal.Text = ocorrenciaSelecionada.Processo.Animal.NomeAnimal;
                txtIdProcesso.Text = ocorrenciaSelecionada.Processo.IdProcesso.ToString();
                txtIdOcorrencia.Text = ocorrenciaSelecionada.IdOcorrencia.ToString();
                txtDescricao.Text = ocorrenciaSelecionada.Descricao;
                dataOcorrencia.Value = ocorrenciaSelecionada.DataOcorrencia;
                txtGravidade.Text = ocorrenciaSelecionada.Gravidade;
                txtProvidencia.Text = ocorrenciaSelecionada.ProvidenciaTomada;
            }
        }

        //BOTÃO VOLTAR – RETORNA AO MENU PRINCIPAL
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }
    }
}
