using MySql.Data.MySqlClient;
using SavingPets.Models;
using SavingPets.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingPets.Controllers
{

    internal class AnimalController
    {
        private static BancoDadosAnimal animalDados = new BancoDadosAnimal();

        public void CadastrarAnimal(Animal novoAnimal)
        {

            animalDados.SalvaDados(novoAnimal);
            
        }

        public List<Animal> ListarAnimais()
        {

            List < Animal > animais = new List<Animal>();

            List<int> ids = animalDados.ListarIds();

            foreach (var id in ids)
            {
                Animal animal = animalDados.ExtrairDados(id);

                if(animal != null)
                {
                    animais.Add(animal);
                }
            }


            return animais;
        }

        public void EditarAnimal(Animal animalEditado)
        {
            animalDados.AlterarDados(animalEditado);
        }

        public int ObterProximoId()
        {
            return animalDados.ExtrairMaiorId() + 1;
        }

        //busca um animal pelo ID (opcional, útil para editar)
        public Animal BuscarPorId(int id)
        {
            return animalDados.ExtrairDados(id);
        }

        public void ExcluirAnimal() { }

    }
}
