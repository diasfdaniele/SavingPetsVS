using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingPets.Controllers
{
    internal class TutorController
    {
        private static List<Tutor> tutores = new List<Tutor>();

        // Cadastrar tutor (gerando ID automaticamente)
        public void CadastrarTutor(Tutor novoTutor)
        {
            if (novoTutor.IdTutor == 0)
            {
                int novoId = (tutores.Count == 0) ? 1 : tutores.Max(t => t.IdTutor) + 1;
                novoTutor.IdTutor = novoId;
            }

            if (tutores.Any(t => t.IdTutor == novoTutor.IdTutor))
                throw new Exception("Já existe um tutor com esse ID!");

            tutores.Add(novoTutor);
        }

        // Editar tutor existente
        public void EditarTutor(Tutor tutorEditado)
        {
            var tutor = tutores.FirstOrDefault(t => t.IdTutor == tutorEditado.IdTutor);
            if (tutor == null)
                throw new Exception("Tutor não encontrado!");

            tutor.IdAnimal = tutorEditado.IdAnimal;
            tutor.NomeTutor = tutorEditado.NomeTutor;
            tutor.SexoTutor = tutorEditado.SexoTutor;
            tutor.CPF = tutorEditado.CPF;
            tutor.Telefone = tutorEditado.Telefone;
            tutor.Email = tutorEditado.Email;
            tutor.CEP = tutorEditado.CEP;
            tutor.Rua = tutorEditado.Rua;
            tutor.Numero = tutorEditado.Numero;
            tutor.Complemento = tutorEditado.Complemento;
            tutor.Bairro = tutorEditado.Bairro;
            tutor.Cidade = tutorEditado.Cidade;
            tutor.Estado = tutorEditado.Estado;
        }

        // Listar tutores
        public List<Tutor> ListarTutores()
        {
            return tutores;
        }

        // Buscar tutor por ID
        public Tutor BuscarPorId(int id)
        {
            return tutores.FirstOrDefault(t => t.IdTutor == id);
        }

        // Gerar próximo ID
        public int ObterProximoId()
        {
            return tutores.Count == 0 ? 1 : tutores.Max(t => t.IdTutor) + 1;
        }
    }
}
