using SavingPets.Controllers;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SavingPets
{
    public partial class FrmCadastrarProcesso : Form
    {
        private ProcessoAdotivoController processoController = new ProcessoAdotivoController();
        private Tutor tutorSelecionado;
        private Animal animalSelecionado;

        public FrmCadastrarProcesso()
        {
            InitializeComponent();

            // Configurações de Data
            dataAdocao.MaxDate = DateTime.Today;
            dataAgendamento.MinDate = DateTime.Today;

            CarregarProximoId();
        }

        // Método auxiliar para buscar o ID
        private void CarregarProximoId()
        {
            try
            {
                txtIdProcesso.Text = processoController.ObterProximoId().ToString();
                txtIdProcesso.Enabled = false; // Bloqueia para não editar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar ID: " + ex.Message);
            }
        }

        private void btnCadastrarProcesso_Click(object sender, EventArgs e)
        {
            try
            {
                // Validações
                if (tutorSelecionado == null) throw new Exception("Por favor, pesquise e selecione um tutor.");
                if (animalSelecionado == null) throw new Exception("Por favor, pesquise e selecione um animal.");
                if (dataAdocao.Value.Date > DateTime.Today) throw new Exception("A data de adoção não pode ser maior que hoje.");

                ProcessoAdotivo novo = new ProcessoAdotivo()
                {
                    IdProcesso = 0,
                    Tutor = tutorSelecionado,
                    Animal = animalSelecionado,
                    DataAdocao = dataAdocao.Value,
                    DataAgendamentoVisita = dataAgendamento.Value,
                    Observacoes = txtObservacoes.Text
                };

                processoController.Cadastrar(novo);

                MessageBox.Show("Processo adotivo cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparFormulario()
        {
            // Limpa campos visuais
            txtIdTutor.Clear();
            txtNomeTutor.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtEndereco.Clear(); // Limpa o endereço completo

            txtIdAnimal.Clear();
            txtNomeAnimal.Clear();
            txtEspecie.Clear();
            txtCastrado.Clear();
            txtVermifugado.Clear();
            txtSexo.Clear();
            txtVacinado.Clear(); // Limpa as vacinas

            dataAdocao.Value = DateTime.Today;
            dataAgendamento.Value = DateTime.Today;
            txtObservacoes.Clear();

            tutorSelecionado = null;
            animalSelecionado = null;

            //ATUALIZA O ID PARA O PRÓXIMO DA FILA
            CarregarProximoId();
        }

        //BOTÃO DE PESQUISA DE TUTOR (Com Endereço Completo e Inteligente)
        private void btnPesquisarTutor_Click(object sender, EventArgs e)
        {
            FrmConsultarTutor frm = new FrmConsultarTutor();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                tutorSelecionado = (Tutor)frm.Tag;
                if (tutorSelecionado != null)
                {
                    txtIdTutor.Text = tutorSelecionado.IdTutor.ToString();
                    txtNomeTutor.Text = tutorSelecionado.NomeTutor;
                    txtCpf.Text = tutorSelecionado.CPF;
                    txtTelefone.Text = tutorSelecionado.Telefone;
                    txtEmail.Text = tutorSelecionado.Email;

                    // Formatação Inteligente do Endereço
                    string complementoFormatado = string.IsNullOrWhiteSpace(tutorSelecionado.Complemento)
                        ? ""
                        : $", {tutorSelecionado.Complemento}";

                    txtEndereco.Text = $"{tutorSelecionado.Rua}, Nº {tutorSelecionado.Numero}{complementoFormatado} - {tutorSelecionado.Bairro}, {tutorSelecionado.Cidade}-{tutorSelecionado.Estado}, CEP: {tutorSelecionado.CEP}";
                }
            }
        }

        //BOTÃO DE PESQUISA DE ANIMAL (Com Vacinas)
        private void btnPesquisarAnimal_Click(object sender, EventArgs e)
        {
            FrmConsultarAnimal frm = new FrmConsultarAnimal();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                animalSelecionado = (Animal)frm.Tag;
                if (animalSelecionado != null)
                {
                    txtIdAnimal.Text = animalSelecionado.IdAnimal.ToString();
                    txtNomeAnimal.Text = animalSelecionado.NomeAnimal;
                    txtEspecie.Text = animalSelecionado.Especie;
                    txtSexo.Text = animalSelecionado.SexoAnimal;
                    txtCastrado.Text = animalSelecionado.Castrado ? "Sim" : "Não";
                    txtVermifugado.Text = animalSelecionado.Vermifugado ? "Sim" : "Não";

                    // Preenche Vacinas
                    if (animalSelecionado.Vacinas != null && animalSelecionado.Vacinas.Count > 0)
                    {
                        txtVacinado.Text = FormatarVacinas(animalSelecionado.Vacinas);
                    }
                    else
                    {
                        txtVacinado.Text = "Nenhuma vacina registrada";
                    }
                }
            }
        }

        // Auxiliar para formatar vacinas
        private string FormatarVacinas(List<string> vacinas)
        {
            if (vacinas.Count == 1) return vacinas[0];
            string inicio = string.Join(", ", vacinas.Take(vacinas.Count - 1));
            string ultimo = vacinas.Last();
            return $"{inicio} e {ultimo}";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void FrmCadastrarProcesso_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall) return;
            var resultado = MessageBox.Show("Deseja realmente sair do sistema?", "Confirmar saída", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No) e.Cancel = true;
            else Application.Exit();
        }
    }
}