using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SavingPets.Models;

namespace SavingPets.Controllers
{



    internal class AnimalController
    {
        private static List<Animal> animais = new List<Animal>();

        public void CadastrarAnimal(Animal novoAnimal)
        {
            if (novoAnimal.IdAnimal == 0)
            {
                int novoId = (animais.Count == 0) ? 1 : animais.Max(a => a.IdAnimal) + 1;
                novoAnimal.IdAnimal = novoId;
            }

            if (animais.Any(a => a.IdAnimal == novoAnimal.IdAnimal))
                throw new Exception("Já existe um animal com esse ID!");

            animais.Add(novoAnimal);
        }

        public List<Animal> ListarAnimais()
        {
            return animais;
        }

        public void EditarAnimal(Animal animalEditado)
        {
            var animal = animais.FirstOrDefault(a => a.IdAnimal == animalEditado.IdAnimal);
            if (animal == null)
                throw new Exception("Animal não encontrado!");

            animal.NomeAnimal = animalEditado.NomeAnimal;
            animal.Raca = animalEditado.Raca;
            animal.SexoAnimal = animalEditado.SexoAnimal;
            animal.Especie = animalEditado.Especie;
        }

        public int ObterProximoId()
        {
            if (animais == null || animais.Count == 0)
                return 1;
            return animais.Max(a => a.IdAnimal) + 1;
        }

        //busca um animal pelo ID (opcional, útil para editar)
        public Animal BuscarPorId(int id)
        {
            return animais.FirstOrDefault(a => a.IdAnimal == id);
        }
    }
}
