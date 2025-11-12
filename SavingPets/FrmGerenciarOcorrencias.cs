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
        //CRIADA PARA TESTES, AVALIAR NECESSIDADE PÓS INTEGRAÇÃO BANCO
        //Criação de controlador de ocorrencias
        //para a manipulação dos dados
        private OcorrenciaController controladorOcorrencia = new OcorrenciaController();

        //Lista de ocorrencias onde os dados vão ficar temporariamente 
        //armazenados (enquanto ainda não há banco)
        private List<Ocorrencia> listaOcorrencias = new List<Ocorrencia>();
        public FrmGerenciarOcorrencias()
        {
            InitializeComponent();

            //Código para inicialização do datagrid
            dgvOcorrencias.AutoGenerateColumns = true;

            //Simulação para carregar ocorrencias
            //PRECISA INTEGRAR COM BANCO
            CarregarOcorrenciasExemplo();
        }

        //SIMULAÇÃO DE DADOS PARA TESTES
        //PRECISA AJUSTAR QUANDO INTEGRAR COM BANCO
        private void CarregarOcorrenciasExemplo()
        {
            ProcessoAdotivo processo1 = new ProcessoAdotivo
            {
                IdProcesso = 1,
                NomeTutor = "Maria Silva",
                NomeAnimal = "Rex",
                DataAdocao = new DateTime(2025, 11, 11)
            };

            ProcessoAdotivo processo2 = new ProcessoAdotivo
            {
                IdProcesso = 2,
                NomeTutor = "João Souza",
                NomeAnimal = "Luna",
                DataAdocao = new DateTime(2025, 10, 10)
            };

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

            //Método chamado para armazenar as ocorrencias na lista 
            controladorOcorrencia.CadastrarOcorrencia(o1);
            controladorOcorrencia.CadastrarOcorrencia(o2);
        }

        //Alteração do nome do label de acordo com rdb selecionado
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

        //Evento de click da LUPA(Pesquisar)
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string termo = txtPesquisarOcorrencias.Text.ToLower();
            List<Ocorrencia> resultados = new List<Ocorrencia>();

            //Pega todas as ocorrências cadastradas
            listaOcorrencias = controladorOcorrencia.ListarOcorrencias();

            //Procura na lista ocorrencias com o texto digitado
            if (rbNomeTutor.Checked)
            {
                resultados = listaOcorrencias
                    .Where(o => o.Processo.NomeTutor.ToLower().Contains(termo))
                    .ToList();
            }
            else if (rbNomeAnimal.Checked)
            {
                resultados = listaOcorrencias
                    .Where(o => o.Processo.NomeAnimal.ToLower().Contains(termo))
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

            // Mostra no DataGridView
            dgvOcorrencias.DataSource = resultados;

            if (resultados.Count == 0)
            {
                MessageBox.Show("Nenhuma ocorrência encontrada.");
            }
        }

        //Evento de clique para quando o usuário clica numa linha da tabela
        private void dgvOcorrencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Ocorrencia ocorrenciaSelecionada = (Ocorrencia)dgvOcorrencias.Rows[e.RowIndex].DataBoundItem;

                txtNomeTutor.Text = ocorrenciaSelecionada.Processo.NomeTutor;
                txtNomeAnimal.Text = ocorrenciaSelecionada.Processo.NomeAnimal;
                txtIdProcesso.Text = ocorrenciaSelecionada.Processo.IdProcesso.ToString();
                txtIdOcorrencia.Text = ocorrenciaSelecionada.IdOcorrencia.ToString();
                txtDescricao.Text = ocorrenciaSelecionada.Descricao;
                dataOcorrencia.Value = ocorrenciaSelecionada.DataOcorrencia;
                txtGravidade.Text = ocorrenciaSelecionada.Gravidade;
                txtProvidencia.Text = ocorrenciaSelecionada.ProvidenciaTomada;
            }
        }

        //Evento de click para voltar ao menu principal
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }
    }
}

