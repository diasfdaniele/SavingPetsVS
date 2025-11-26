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
        //SUBSTITUIR POR SELECT DO BANCO APÓS INTEGRAÇÃO
        private List<ProcessoAdotivo> listaProcessos;

        //Comando para guardar tipo de filtro escolhido pelo usuário
        private string filtroAtual = "NomeTutor";

        //Objeto que guarda o processo selecionado no DataGrid
        private ProcessoAdotivo processoSelecionado;

        public FrmConsultarProcesso()
        {
            InitializeComponent();

            //Carrega processos simulados (EM MEMÓRIA)
            //EM BANCO → CARREGAR DADOS VIA SELECT
            CarregarProcessosSimulados();

            //Atualiza o DataGrid com os dados da lista
            AtualizarGrid();

            //Evento disparado quando o usuário seleciona uma linha do DataGrid
            dgvProcessos.SelectionChanged += dgvProcessos_SelectionChanged;
        }

        //CLASSE QUE SIMULA O BANCO DE DADOS
        //ESTE TRECHO SERÁ REMOVIDO APÓS INTEGRAÇÃO COM BANCO
        private void CarregarProcessosSimulados()
        {
            listaProcessos = new List<ProcessoAdotivo>
            {
                new ProcessoAdotivo { IdProcesso = 1, Tutor = new Tutor { NomeTutor = "Ana Souza" },
            Animal = new Animal { NomeAnimal = "Rex" }, DataAdocao = new DateTime(2025, 10, 15) },
            };
        }

        //Exibição dos processos no DataGridView
        //EM BANCO → A LISTA VIRÁ DE UMA CONSULTA SQL (SELECT)
        private void AtualizarGrid()
        {
            dgvProcessos.DataSource = null;
            dgvProcessos.DataSource = listaProcessos;

            //Configurações do DataGrid
            dgvProcessos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProcessos.MultiSelect = false;
            dgvProcessos.ReadOnly = true;
        }

        //RadioButton – troca o filtro ativo para Nome do Tutor
        private void rbNomeTutor_CheckedChanged(object sender, EventArgs e)
        {
            filtroAtual = "NomeTutor";
        }

        //RadioButton – troca o filtro ativo para Nome do Animal
        private void rbNomeAnimal_CheckedChanged(object sender, EventArgs e)
        {
            filtroAtual = "NomeAnimal";
        }

        //RadioButton – troca o filtro ativo para ID do Processo
        private void rbIdProcesso_CheckedChanged(object sender, EventArgs e)
        {
            filtroAtual = "IdProcesso";
        }

        //Pesquisa de processo enquanto usuário digita
        //EM BANCO → IMPLEMENTAR CONSULTA DINÂMICA COM LIKE
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string termo = txtPesquisar.Text.ToLower(); //converte texto para minusculo

            //Filtra lista conforme tipo de filtro selecionado
            var filtrados = listaProcessos.Where(p =>
                (filtroAtual == "NomeTutor" && p.Tutor.NomeTutor.ToLower().Contains(termo)) ||
                (filtroAtual == "NomeAnimal" && p.Animal.NomeAnimal.ToLower().Contains(termo)) ||
                (filtroAtual == "IdProcesso" && p.IdProcesso.ToString().Contains(termo))
            ).ToList();

            //Exibe resultados filtrados
            dgvProcessos.DataSource = null;
            dgvProcessos.DataSource = filtrados;
        }

        //Evento disparado quando o usuário seleciona uma linha no DataGrid
        private void dgvProcessos_SelectionChanged(object sender, EventArgs e)
        {
            //Verifica se há pelo menos uma linha selecionada
            if (dgvProcessos.SelectedRows.Count > 0)
            {
                //Recupera o objeto associado à linha selecionada
                var processo = dgvProcessos.SelectedRows[0].DataBoundItem as ProcessoAdotivo;

                //Se for válido, armazena como processo selecionado
                if (processo != null)
                {
                    processoSelecionado = processo;
                    ExibirDetalhes(processoSelecionado);
                }
            }
        }

        //Exibe dados do processo nos TextBox
        private void ExibirDetalhes(ProcessoAdotivo processo)
        {
            txtId.Text = processo.IdProcesso.ToString();
            txtNomeTutor.Text = processo.Tutor.NomeTutor;
            txtNomeAnimal.Text = processo.Animal.NomeAnimal;
            dataAdocao.Value = processo.DataAdocao;
        }

        //Retorna o processo selecionado para outra tela
        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (processoSelecionado != null)
            {
                //Envia o processo por meio da propriedade Tag
                this.Tag = processoSelecionado;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                //Mensagem caso usuário tente confirmar sem selecionar nada
                MessageBox.Show("Selecione um processo antes de confirmar.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Botão para fechar a tela
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FrmOcorrencia janela = new FrmOcorrencia();
            Hide();
            janela.ShowDialog();
            Show();
        }

    }
}
