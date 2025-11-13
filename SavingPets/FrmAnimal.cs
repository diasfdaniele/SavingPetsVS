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

            string especie = rbCachorro.Checked ? "Cachorro" : "Gato";


            string sexoA = rbMacho.Checked ? "Macho" : "Fêmea";



            List<string> vacinasSelecionadas = new List<string>();
            if (cbAntirabica.Checked) vacinasSelecionadas.Add("Antirrábica");
            if (cbPoli8.Checked) vacinasSelecionadas.Add("Polivalente V8");
            if (cbPoli10.Checked) vacinasSelecionadas.Add("Polivalente V10");
            if (cbPoli3.Checked) vacinasSelecionadas.Add("Polivalente V3");
            if (cbPoli4.Checked) vacinasSelecionadas.Add("Polivalente V4");
            if (cbPoli5.Checked) vacinasSelecionadas.Add("Polivalente V5");


            string vacinasTexto = string.Join("; ", vacinasSelecionadas);


            bool vermifugado = rbVermifugado.Checked; // true se "Sim", false se "Não"


            bool castrado = rbCastrado.Checked; // true se "Sim", false se "Não"


            especie = animal.Especie;
            sexoA = animal.SexoAnimal;
            vacinasTexto = animal.Vacinas;
            vermifugado = animal.Vermifugado;
            castrado = animal.Castrado;
            txtHistorico.Text = animal.HistoricoDoencas;
            

            // (opcional) muda o título da janela para indicar edição
            this.Text = "Editar Animal";
        }

        //Evento de clique cadastrar animal
        private void btnCadAnimal_Click(object sender, EventArgs e)
        {
            
           

            try
            {
                string especie = rbCachorro.Checked ? "Cachorro" : "Gato";

                string sexoA = rbMacho.Checked ? "Macho" : "Fêmea";


                List<string> vacinasSelecionadas = new List<string>();
                if (cbAntirabica.Checked) vacinasSelecionadas.Add("Antirrábica");
                if (cbPoli8.Checked) vacinasSelecionadas.Add("Polivalente V8");
                if (cbPoli10.Checked) vacinasSelecionadas.Add("Polivalente V10");
                if (cbPoli3.Checked) vacinasSelecionadas.Add("Polivalente V3");
                if (cbPoli4.Checked) vacinasSelecionadas.Add("Polivalente V4");
                if (cbPoli5.Checked) vacinasSelecionadas.Add("Polivalente V5");


                string vacinasTexto = string.Join("; ", vacinasSelecionadas);


                bool vermifugado = rbVermifugado.Checked; // true se "Sim", false se "Não"


                bool castrado = rbCastrado.Checked; // true se "Sim", false se "Não"


                //Verifica campos obrigatórios
                if (string.IsNullOrEmpty(txtNomeAnimal.Text) ||
                    string.IsNullOrEmpty(txtHistorico.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios!",
                        "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Animal novo = new Animal
                {
                    IdAnimal = int.Parse(txtIdAnimal.Text),
                    NomeAnimal = txtNomeAnimal.Text,
                    Especie = especie,
                    SexoAnimal = sexoA,
                    Vacinas = vacinasTexto,
                    Vermifugado = vermifugado,
                    Castrado = castrado,
                    HistoricoDoencas = txtHistorico.Text,
                    
                };

                AnimalController controller = new AnimalController();
                controller.CadastrarAnimal(novo);

                MessageBox.Show("Animal cadastrado com sucesso!");
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
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
    }
}
