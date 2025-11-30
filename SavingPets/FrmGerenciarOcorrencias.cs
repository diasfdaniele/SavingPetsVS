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
        private OcorrenciaController controladorOcorrencia = new OcorrenciaController();

        private int idProcesso;

        public FrmGerenciarOcorrencias()
        {
            InitializeComponent();

            dgvOcorrencias.AutoGenerateColumns = true;
            dgvOcorrencias.DataSource = controladorOcorrencia.BuscarTodos();
        }

        public FrmGerenciarOcorrencias(int idProcesso)
        {
            InitializeComponent();

            this.idProcesso = idProcesso;

            dgvOcorrencias.AutoGenerateColumns = true;
            dgvOcorrencias.DataSource = controladorOcorrencia.BuscarPorProcesso(idProcesso);
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
            string termo = txtPesquisarOcorrencias.Text.Trim();
            List<OcorrenciaView> resultados = new List<OcorrenciaView>();

            if (rbNomeTutor.Checked)
            {
                resultados = controladorOcorrencia.BuscarPorNomeTutor(termo);
            }
            else if (rbNomeAnimal.Checked)
            {
                resultados = controladorOcorrencia.BuscarPorNomeAnimal(termo);
            }
            else if (rbIdProcesso.Checked && int.TryParse(termo, out int idProc))
            {
                resultados = controladorOcorrencia.BuscarPorIdProcesso(idProc);
            }
            else if (rbIdOcorrencia.Checked && int.TryParse(termo, out int idOc))
            {
                var oc = controladorOcorrencia.BuscarPorId(idOc);
                if (oc != null)
                    resultados.Add(oc);
            }

            dgvOcorrencias.DataSource = resultados;

            if (resultados.Count == 0)
                MessageBox.Show("Nenhuma ocorrência encontrada.");
        }

        //EVENTO DISPARADO AO CLICAR EM UMA LINHA DO DATAGRID
        //PREENCHE OS CAMPOS DA TELA COM OS DADOS DA LINHA SELECIONADA
        private void dgvOcorrencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                OcorrenciaView oc = (OcorrenciaView)dgvOcorrencias.Rows[e.RowIndex].DataBoundItem;

                txtNomeTutor.Text = oc.NomeTutor;
                txtNomeAnimal.Text = oc.NomeAnimal;
                txtIdProcesso.Text = oc.IdProcessoAdotivo.ToString();
                txtIdOcorrencia.Text = oc.IdOcorrencia.ToString();
                txtDescricao.Text = oc.Descricao;
                dataOcorrencia.Value = oc.DataOcorrencia;
                txtGravidade.Text = oc.Tipo; // se "Gravidade" era o antigo "Tipo"
                txtProvidencia.Text = ""; // remover, pois não existe no banco
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

        public class OcorrenciaView
        {
            public int IdOcorrencia { get; set; }
            public int IdProcessoAdotivo { get; set; }
            public string NomeTutor { get; set; }
            public string NomeAnimal { get; set; }
            public string Tipo { get; set; }
            public DateTime DataOcorrencia { get; set; }
            public string Descricao { get; set; }
        }

        private void FrmGerenciarOcorrencias_FormClosing(object sender, FormClosingEventArgs e)
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
