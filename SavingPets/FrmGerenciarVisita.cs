using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.Cmp;
using SavingPets.Controllers;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SavingPets
{
    public partial class FrmGerenciarVisita : Form
    {
        // CONTROLLER USADO PARA MANIPULAR VISITAS
        // Contém APENAS LISTAS SIMULADAS.
        // Após a integração com o banco, TODO o acesso será feito via SELECT/INSERT/UPDATE/DELETE.

        private VisitaController visitaController = new VisitaController();

        // Lista usada para exibir no DataGridView
        private List<Visita> listaAtual = new List<Visita>();

        public FrmGerenciarVisita()
        {
            InitializeComponent();

            dgvVisita.AutoGenerateColumns = true;

            // Dados de exemplo para testes — será removido APÓS integração com o banco
            CarregarVisitasExemplo();
        }

        // SIMULAÇÃO DE DADOS — SOMENTE PARA TESTE SEM BANCO
        // Após integração: este método será DELETADO.       
        private void CarregarVisitasExemplo()
        {
            // Processo adotivo fictício
            ProcessoAdotivo processo1 = new ProcessoAdotivo
            {
                IdProcesso = 1,
                Tutor = new Tutor { NomeTutor = "Maria Silva" },
                Animal = new Animal { NomeAnimal = "Rex" },
                DataAdocao = DateTime.Now.AddMonths(-3)
            };

            // Visita fictícia
            Visita visita1 = new Visita
            {
                IdVisita = 1,
                Processo = processo1,
                DataVisita = DateTime.Now.AddDays(-10),
                Responsavel = "Bruno Santos",
                Status = "Realizada",

                // Bem-estar
                CondicaoFisica = "Boa",
                Comportamento = "Calmo",
                AnimalSaudavel = "Sim",
                CondicoesHigiene = "Adequada",
                VacinasEmDia = "Sim",
                AcompanhamentoVeterinario = "Sim",

                // Ambiente
                CondicaoAmbiente = "Seguro",
                MausTratos = "Não",
                AdaptacaoAmbiente = "Perfeita",

                // Relacionamento e observações
                RelacaoTutor = "Excelente",
                AlteracoesComportamento = "Nenhuma",
                OrientacoesDadas = "Manter rotina",
                ConclusaoVisita = "Animal saudável",
                Observacoes = "Tudo dentro do esperado",

                // Agendamento
                ProximaVisitaSugerida = DateTime.Now.AddMonths(1)
            };

            // Atualmente: armazenado APENAS na lista simulada do controller.
            // FUTURO: inserir no banco com INSERT INTO Visita (...)
            visitaController.CadastrarVisita(visita1);

            // Carregar o grid
            AtualizarGridCompleto();
        }

        // EVENTO DO BOTÃO PESQUISAR
        // FUTURO: Isso será SELECT ... WHERE camponEscolhido LIKE ...
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string termo = txtPesquisar.Text.Trim();

            if (string.IsNullOrWhiteSpace(termo))
            {
                MessageBox.Show("Digite algo para pesquisar.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filtro = ObterFiltroSelecionado();

            // No momento: filtragem em memória usando LINQ
            // FUTURO: SELECT * FROM Visita WHERE filtro LIKE '%termo%'
            listaAtual = visitaController.BuscarVisitas(termo, filtro);

            dgvVisita.DataSource = null;
            dgvVisita.DataSource = listaAtual;

            ConfigurarGrid();
        }

        // Identifica qual filtro de pesquisa o usuário escolheu
        private string ObterFiltroSelecionado()
        {
            if (rbNomeTutor.Checked) return "NomeTutor";
            if (rbNomeAnimal.Checked) return "NomeAnimal";
            if (rbIdProcesso.Checked) return "IdProcesso";
            if (rbIdVisita.Checked) return "IdVisita";

            return "NomeTutor"; // padrão
        }

        // Carrega todas as visitas cadastradas
        // FUTURO: SELECT * FROM Visita + JOIN ProcessoAdotivo
        private void AtualizarGridCompleto()
        {
            listaAtual = visitaController.ListarVisitas();

            dgvVisita.DataSource = null;
            dgvVisita.DataSource = listaAtual;

            ConfigurarGrid();
        }

        // Configuração do DataGridView
        // FUTURO: será automatizado caso o SELECT já traga os nomes do tutor/animal
        private void ConfigurarGrid()
        {
            if (dgvVisita.Columns.Count == 0) return;

            // Evita exibir o objeto Processo inteiro no grid
            dgvVisita.Columns["Processo"].Visible = false;

            // Ajustar headers
            dgvVisita.Columns["IdVisita"].HeaderText = "ID Visita";
            dgvVisita.Columns["DataVisita"].HeaderText = "Data";
            dgvVisita.Columns["Status"].HeaderText = "Status";
            dgvVisita.Columns["Responsavel"].HeaderText = "Responsável";

            // Colunas adicionais (derivadas da classe ProcessoAdotivo)
            dgvVisita.Columns.Add("NomeTutor", "Nome do Tutor");
            dgvVisita.Columns.Add("NomeAnimal", "Nome do Animal");
            dgvVisita.Columns.Add("IdProcesso", "ID Processo");

            // Preenche as colunas adicionais
            foreach (DataGridViewRow row in dgvVisita.Rows)
            {
                Visita v = row.DataBoundItem as Visita;

                if (v != null)
                {
                    row.Cells["NomeTutor"].Value = v.Processo.Tutor.NomeTutor;
                    row.Cells["NomeAnimal"].Value = v.Processo.Animal.NomeAnimal;
                    row.Cells["IdProcesso"].Value = v.Processo.IdProcesso;
                }
            }
        }


        // Atualiza label de filtro quando o rádio muda
        private void rbNomeTutor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNomeTutor.Checked)
                lblFiltro.Text = "Nome do Tutor:";
        }

        private void rbNomeAnimal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNomeAnimal.Checked)
                lblFiltro.Text = "Nome do Animal:";
        }

        private void rbIdProcesso_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIdProcesso.Checked)
                lblFiltro.Text = "ID do Processo:";
        }

        private void rbIdVisita_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIdVisita.Checked)
                lblFiltro.Text = "ID da Visita:";
        }

        // Quando usuário clica numa linha, carregar dados nos campos de edição
        private void dgvVisita_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Visita visita = dgvVisita.Rows[e.RowIndex].DataBoundItem as Visita;

            if (visita != null)
                PreencherCampos(visita);
        }

        // Copia os dados da visita selecionada para os TextBoxes e DatePickers
        private void PreencherCampos(Visita v)
        {
            txtNomeTutor.Text = v.Processo.Tutor.NomeTutor;
            txtNomeAnimal.Text = v.Processo.Animal.NomeAnimal;
            txtIdProcesso.Text = v.Processo.IdProcesso.ToString();
            txtIdVisita.Text = v.IdVisita.ToString();

            dataVisita.Value = v.DataVisita;
            txtStatus.Text = v.Status;
            txtResponsavel.Text = v.Responsavel;

            txtOrientacoes.Text = v.OrientacoesDadas;
            txtConclusao.Text = v.ConclusaoVisita;
            dataAgendamento.Value = v.ProximaVisitaSugerida;

            // Bem-estar
            txtFisico.Text = v.CondicaoFisica;
            txtComportamento.Text = v.Comportamento;
            txtSaudavel.Text = v.AnimalSaudavel;
            txtHigiene.Text = v.CondicoesHigiene;
            txtVacinado.Text = v.VacinasEmDia;
            txtAcompanhamento.Text = v.AcompanhamentoVeterinario;

            // Ambiente
            txtAmbiente.Text = v.CondicaoAmbiente;
            txtMausTratos.Text = v.MausTratos;
            txtAdaptacao.Text = v.AdaptacaoAmbiente;

            txtRelacao.Text = v.RelacaoTutor;
            txtAlteracao.Text = v.AlteracoesComportamento;
            txtObservacoes.Text = v.Observacoes;
        }

        // BOTÃO EXCLUIR
        // FUTURO: DELETE FROM Visita WHERE IdVisita = X
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvVisita.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma visita para excluir.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Visita visitaSelecionada = dgvVisita.SelectedRows[0].DataBoundItem as Visita;

            if (visitaSelecionada == null) return;

            var confirm = MessageBox.Show(
                "Deseja realmente excluir esta visita?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {

                // Atualmente: remove da lista simulada
                // FUTURO: DELETE FROM Visita WHERE IdVisita = @id
                visitaController.ListarVisitas().Remove(visitaSelecionada);

                AtualizarGridCompleto();
            }
        }


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void FrmGerenciarVisita_FormClosing(object sender, FormClosingEventArgs e)
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
