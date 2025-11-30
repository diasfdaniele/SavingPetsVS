using SavingPets.DAL;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingPets.Controllers
{
    public class TutorController
    {
        // Instância da classe de Banco de Dados
        BancoDeDadosTutor tutorDados = new BancoDeDadosTutor();

        // Cadastrar tutor (Agora chama o Banco)
        public void CadastrarTutor(Tutor novoTutor)
        {
            // Podemos colocar validações aqui antes de enviar pro banco
            if (string.IsNullOrEmpty(novoTutor.NomeTutor))
                throw new Exception("O nome do tutor é obrigatório.");
            tutorDados.SalvaDados(novoTutor);
        }

        // Editar tutor existente (Agora chama o Banco)
        public void EditarTutor(Tutor tutorEditado)
        {
            tutorDados.EditarTutor(tutorEditado);
        }

        // Listar tutores (Busca do Banco)
        public List<Tutor> ListarTutores()
        {
            return tutorDados.ListarTutores();
        }

        // Buscar tutor por ID (Busca do Banco)
        public Tutor BuscarPorId(int id)
        {
            return tutorDados.BuscarPorId(id);
        }

        // Gerar próximo ID 
        // (Adaptado para calcular baseado no que já existe no banco)
        public int ObterProximoId()
        {
            return tutorDados.ProximoId();
        }
    }
}