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
    public partial class FrmAnimal : Form
    {
        public FrmAnimal()
        {
            InitializeComponent();
        }

        private Animal animalEmEdicao;

        public FrmAnimal(Animal animal) : this()
        {
            animalEmEdicao = animal;

            // Preenche os campos com os dados do animal selecionado
            txtIdAnimal.Text = animal.IdAnimal.ToString();
            txtNomeAnimal.Text = animal.NomeAnimal;

            // Marca a espécie
            if (animal.Especie == "Cachorro")
                rbCachorro.Checked = true;
            else
                rbGato.Checked = true;

            // Marca o sexo
            if (animal.SexoAnimal == "Macho")
                rbMacho.Checked = true;
            else
                rbFemea.Checked = true;

            // Marca as vacinas
            cbAntirabica.Checked = animal.Vacinas.Contains("Antirrábica");
            cbPoli8.Checked = animal.Vacinas.Contains("V8");
            cbPoli10.Checked = animal.Vacinas.Contains("V10");
            cbPoli3.Checked = animal.Vacinas.Contains("V3");
            cbPoli4.Checked = animal.Vacinas.Contains("V4");
            cbPoli5.Checked = animal.Vacinas.Contains("V5");

            // Marca vermifugado
            rbVermifugado.Checked = animal.Vermifugado;
            rbNaoVermifugado.Checked = !animal.Vermifugado;

            // Marca castrado
            rbCastrado.Checked = animal.Castrado;
            rbNaoCastrado.Checked = !animal.Castrado;

            // Campos simples
            txtRaca.Text = animal.Raca;
            txtHistorico.Text = animal.HistoricoDoencas;

            // (opcional) muda o título da janela para indicar edição
            this.Text = "Editar Animal";
        }

        //Evento de clique cadastrar animal
        private void btnCadAnimal_Click(object sender, EventArgs e)
        {
            // Monta a lista de vacinas a partir dos checkboxes
            List<string> vacinasSelecionadas = new List<string>();
            if (cbAntirabica.Checked) vacinasSelecionadas.Add("Antirrábica");
            if (cbPoli8.Checked) vacinasSelecionadas.Add("Polivalente V8");
            if (cbPoli10.Checked) vacinasSelecionadas.Add("Polivalente V10");
            if (cbPoli3.Checked) vacinasSelecionadas.Add("Polivalente V3");
            if (cbPoli4.Checked) vacinasSelecionadas.Add("Polivalente V4");
            if (cbPoli5.Checked) vacinasSelecionadas.Add("Polivalente V5");

            // demais campos
            string especie = rbCachorro.Checked ? "Cachorro" : "Gato";
            string sexoA = rbMacho.Checked ? "Macho" : "Fêmea";
            bool vermifugado = rbVermifugado.Checked;
            bool castrado = rbCastrado.Checked;

            //Validações (mantive as suas)
            if (string.IsNullOrWhiteSpace(txtNomeAnimal.Text) ||
                string.IsNullOrWhiteSpace(txtRaca.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios!",
                    "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cria o objeto Animal - note que Vacinas recebe a LISTA, não a string
            Animal novo = new Animal
            {
                NomeAnimal = txtNomeAnimal.Text.Trim(),
                Especie = especie,
                SexoAnimal = sexoA,
                Vacinas = vacinasSelecionadas,      // <<< AQUI: lista, não string
                Vermifugado = vermifugado,
                Castrado = castrado,
                Raca = txtRaca.Text.Trim(),
                HistoricoDoencas = txtHistorico.Text.Trim()
            };

            // Se estivermos editando um animal existente, mantenha o Id
            if (animalEmEdicao != null)
            {
                novo.IdAnimal = animalEmEdicao.IdAnimal;
            }

            // Chama o controller
            AnimalController controller = new AnimalController();

            if (animalEmEdicao == null)
            {
                controller.CadastrarAnimal(novo);
                MessageBox.Show("Animal cadastrado com sucesso!");
                LimparCampos();   // <<< AQUI!!!
            }
            else
            {
                controller.EditarAnimal(novo);
                MessageBox.Show("Animal atualizado com sucesso!");
            }


        }


        //Evento de clique para voltar ao menu principal
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu janela = new FrmMenu();
            Hide();
            janela.ShowDialog();
            Show();
        }

        private void FrmAnimal_Load(object sender, EventArgs e)
        {
            try
            {
                AnimalController controller = new AnimalController();
                int proximoId = controller.ObterProximoId();
                txtIdAnimal.Text = proximoId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar próximo ID: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            txtNomeAnimal.Clear();
            txtRaca.Clear();
            txtHistorico.Clear();

            // Desmarca vacinas
            cbAntirabica.Checked = false;
            cbPoli8.Checked = false;
            cbPoli10.Checked = false;
            cbPoli3.Checked = false;
            cbPoli4.Checked = false;
            cbPoli5.Checked = false;

            // RadioButtons
            rbCachorro.Checked = false;
            rbGato.Checked = false;
            rbMacho.Checked = false;
            rbFemea.Checked = false;
            rbVermifugado.Checked = false;
            rbNaoVermifugado.Checked = false;
            rbCastrado.Checked = false;
            rbNaoCastrado.Checked = false;

            // Gera novo ID
            try
            {
                AnimalController controller = new AnimalController();
                txtIdAnimal.Text = controller.ObterProximoId().ToString();
            }
            catch { }
        }


        private void FrmAnimal_FormClosing(object sender, FormClosingEventArgs e)
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
