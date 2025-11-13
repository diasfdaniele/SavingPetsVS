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

namespace SavingPets
{
    public partial class FrmConsultarProcesso : Form
    {

        //LISTA DE SIMULAÇÃO DOS DADOS
        private List<ProcessoAdotivo> listaProcessos;
        //Comando para guardar tipo de filtro que usuario escolheu
        private string filtroAtual = "NomeTutor";
        //Objeto que guarda o processo selecionado
        private ProcessoAdotivo processoSelecionado;

        public FrmConsultarProcesso()
        {
            InitializeComponent();
            CarregarProcessosSimulados(); // enquanto não tiver banco
            AtualizarGrid(); //exibe dados no datagrid

            //Associação de evento quando usuário seleciona linha
            dgvProcessos.SelectionChanged += dgvProcessos_SelectionChanged;
        }

        //CLASSE QUE SIMULA O BANCO DE DADOS
        //PRECISA SER REVISTA PÓS INTEGRAÇÃO COM BANCO
        private void CarregarProcessosSimulados()
        {
            listaProcessos = new List<ProcessoAdotivo>
            {
                new ProcessoAdotivo { IdProcesso = 1, NomeTutor = "Ana Souza", NomeAnimal = "Rex", DataAdocao = new DateTime(2025, 10, 15) },
                new ProcessoAdotivo { IdProcesso = 2, NomeTutor = "João Lima", NomeAnimal = "Luna", DataAdocao = new DateTime(2025, 9, 5) },
                new ProcessoAdotivo { IdProcesso = 3, NomeTutor = "Marcos Oliveira", NomeAnimal = "Mia", DataAdocao = new DateTime(2025, 8, 20) }
            };
        }

        //Exibição dos processos no datagrid
        private void AtualizarGrid()
        {
            dgvProcessos.DataSource = null;
            dgvProcessos.DataSource = listaProcessos;

            dgvProcessos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProcessos.MultiSelect = false;
            dgvProcessos.ReadOnly = true;
        }

        //Eventos de click para filtro de pesquisa
        private void rbNomeTutor_CheckedChanged(object sender, EventArgs e)
        {
            filtroAtual = "NomeTutor";
        }

        private void rbNomeAnimal_CheckedChanged(object sender, EventArgs e)
        {
            filtroAtual = "NomeAnimal";
        }

        private void rbIdProcesso_CheckedChanged(object sender, EventArgs e)
        {
            filtroAtual = "IdProcesso";
        }

        //Pesquisa de processo adotivo (dispara a cada letra digitada)
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            //converte caracteres para letra minuscula
            string termo = txtPesquisar.Text.ToLower();

            //filtra a lista conforme tipo de filtro
            var filtrados = listaProcessos.Where(p =>
                (filtroAtual == "NomeTutor" && p.NomeTutor.ToLower().Contains(termo)) ||
                (filtroAtual == "NomeAnimal" && p.NomeAnimal.ToLower().Contains(termo)) ||
                (filtroAtual == "IdProcesso" && p.IdProcesso.ToString().Contains(termo))
            ).ToList();

            //atualiza datagrid conforme resultados filtrados
            dgvProcessos.DataSource = null;
            dgvProcessos.DataSource = filtrados;
        }

        //Evento de clique para gerar detalhes ao clicar
        private void dgvProcessos_SelectionChanged(object sender, EventArgs e)
        {
            //Verifica se há pelo menos uma linha selecionada
            if (dgvProcessos.SelectedRows.Count > 0)
            {
                //recupera o objeto associado a linha selecionada
                var processo = dgvProcessos.SelectedRows[0].DataBoundItem as ProcessoAdotivo;

                if (processo != null)
                {
                    processoSelecionado = processo;
                    ExibirDetalhes(processoSelecionado);
                }
            }
        }

        //Exibe as informações do processo nos textbox
        private void ExibirDetalhes(ProcessoAdotivo processo)
        {
            txtId.Text = processo.IdProcesso.ToString();
            txtNomeTutor.Text = processo.NomeTutor;
            txtNomeAnimal.Text = processo.NomeAnimal;
            dataAdocao.Value = processo.DataAdocao;
        }

        //Evento de click para retornar o processo para a outra tela
        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (processoSelecionado != null)
            {
                this.Tag = processoSelecionado;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione um processo antes de confirmar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Evento de click para fechar a tela
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmConsultarProcesso_Load(object sender, EventArgs e)
        {

        }
    }
}
