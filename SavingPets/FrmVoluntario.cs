using SavingPets.Controllers;
using SavingPets.Models;
using System;
using System.Windows.Forms;

namespace SavingPets
{
    public partial class FrmVoluntario : Form
    {
        private VoluntarioController controller;

        public FrmVoluntario()
        {
            InitializeComponent();
            controller = new VoluntarioController();

            // Tenta carregar o próximo ID ao iniciar o formulário
            CarregarProximoId();

            // Certifique-se de que os eventos de Click estejam vinculados no Designer:
            // btnCadastrar -> btnCadastrar_Click
            // btnVoltar -> btnVoltar_Click
        }

        // =======================================================
        // MÉTODOS AUXILIARES
        // =======================================================

        private void CarregarProximoId()
        {
            try
            {
                // ATENÇÃO: Verifique se o nome é 'txtIdVoluntario' no seu designer
                if (Controls.Find("txtIdVoluntario", true).Length > 0)
                {
                    //txtIdVoluntario.Text = controller.BuscarProximoId().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar ID: " + ex.Message, "Erro de Conexão");
            }
        }

        private void LimparCampos()
        {
            // Limpa todos os TextBoxes e reseta os controles
            txtNome.Clear();
            txtCpf.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtCep.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            txtSenha.Clear(); // Corrigido

            // Reseta RadioButtons para padrões
            rbMasculino.Checked = true;
            rbFeminino.Checked = true;

            // Reseta DatePickers
            dtNascimento.Value = DateTime.Now.AddYears(-10);
            dtCadastro.Value = DateTime.Now;
        }


        // =======================================================
        // MANIPULADORES DE EVENTOS
        // =======================================================

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Coletar e validar o Sexo
                string sexo = "";
                if (rbMasculino.Checked) sexo = "M";
                else if (rbFeminino.Checked) sexo = "F";
                else
                {
                    MessageBox.Show("Selecione o sexo.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Coletar e validar o Número
                if (!int.TryParse(txtNumero.Text, out int numeroEndereco))
                {
                    MessageBox.Show("O número do endereço deve ser um valor numérico válido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Criação do objeto Model
                Voluntario novoVoluntario = new Voluntario
                {
                    // Dados de Pessoa
                    Nome = txtNome.Text,
                    Cpf = txtCpf.Text,
                    TelefoneCompleto = txtTelefone.Text,
                    DataNascimento = dtNascimento.Value,
                    Sexo = sexo,
                    DataCadastro = dtCadastro.Value, // Data de entrada como voluntário

                    // Endereço
                    Cep = txtCep.Text,
                    Rua = txtRua.Text,
                    Numero = numeroEndereco,
                    Complemento = txtComplemento.Text,
                    Bairro = txtBairro.Text,
                    Cidade = txtCidade.Text,
                    Estado = txtEstado.Text,

                    // Login
                    Email = txtEmail.Text, // Corrigido
                    Senha = txtSenha.Text, // Corrigido

                    // Lógica para Tutor
                    //EhTutor = rbTutorSim.Checked
                };

                // 4. Chama controller para cadastro
                controller.Cadastrar(novoVoluntario);

                MessageBox.Show("Voluntário cadastrado com sucesso! " +
                                (novoVoluntario.EhTutor ? "O usuário também foi registrado como Tutor." : ""),
                                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 5. Limpar e recarregar
                LimparCampos();
                CarregarProximoId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método btnVoltar_Click
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            // Lógica para voltar ao menu (mantida como no arquivo original do usuário)
            FrmMenu janela = new FrmMenu();
            this.Hide();
            janela.ShowDialog();
            this.Show();
        }

        // Evento que pode ter sido gerado no Designer (deixado vazio)
        private void groupBox1_Enter(object sender, EventArgs e) { }
    }
}