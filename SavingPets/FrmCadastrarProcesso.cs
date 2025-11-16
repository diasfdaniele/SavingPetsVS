using Org.BouncyCastle.Asn1.Cmp;
using SavingPets.Controllers;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavingPets
{
    public partial class FrmCadastrarProcesso : Form
    {

        // Controllers usados pela tela
        TutorController tutorController = new TutorController();
        AnimalController animalController = new AnimalController();
        ProcessoAdotivoController processoController = new ProcessoAdotivoController();

        // Guardam os objetos selecionados na busca
        private Tutor tutorSelecionado;
        private Animal animalSelecionado;
        public FrmCadastrarProcesso()
        {
            InitializeComponent();
        }

        private void btnCadastrarProcesso_Click(object sender, EventArgs e)
        {
            try
            {
                if (tutorSelecionado == null)
                    throw new Exception("Selecione um tutor.");

                if (animalSelecionado == null)
                    throw new Exception("Selecione um animal.");

                if (dataAdocao.Value.Date > DateTime.Today)
                    throw new Exception("A data de adoção não pode ser futura.");

                ProcessoAdotivo novo = new ProcessoAdotivo()
                {
                    Tutor = tutorSelecionado,
                    Animal = animalSelecionado,
                    DataAdocao = dataAdocao.Value,
                    DataAgendamentoVisita = dataAgendamento.Value,
                    Observacoes = txtObservacoes.Text
                };

                processoController.Cadastrar(novo);

                MessageBox.Show("Processo adotivo cadastrado com sucesso!",
                                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparFormulario()
        {
            txtIdTutor.Clear();
            txtNomeTutor.Clear();
            txtIdAnimal.Clear();
            txtNomeAnimal.Clear();
            dataAdocao.Value = DateTime.Today;
            txtObservacoes.Clear();

            tutorSelecionado = null;
            animalSelecionado = null;
        }

        private void btnPesquisarTutor_Click(object sender, EventArgs e)
        {
            FrmConsultarTutor frm = new FrmConsultarTutor();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                tutorSelecionado = (Tutor)frm.Tag;
                txtIdTutor.Text = tutorSelecionado.IdTutor.ToString();
                txtNomeTutor.Text = tutorSelecionado.NomeTutor;
                txtCpf.Text = tutorSelecionado.CPF;
                txtTelefone.Text = tutorSelecionado.Telefone;
                txtEmail.Text = tutorSelecionado.Email;
            }
        }

        private void btnPesquisarAnimal_Click(object sender, EventArgs e)
        {
            FrmConsultarAnimal frm = new FrmConsultarAnimal();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                animalSelecionado = (Animal)frm.Tag;
                txtIdAnimal.Text = animalSelecionado.IdAnimal.ToString();
                txtNomeAnimal.Text = animalSelecionado.NomeAnimal;
                txtEspecie.Text = animalSelecionado.Especie;
                txtSexo.Text = animalSelecionado.SexoAnimal;
                txtCastrado.Text = animalSelecionado.Castrado.ToString();
                txtVermifugado.Text = animalSelecionado.Vermifugado.ToString();
                txtVacinado.Text = animalSelecionado.Vacinas.ToString();

            }
        }
    }
}

