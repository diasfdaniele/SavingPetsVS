using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingPets.Models
{
    public class Tutor
    {
        public int IdTutor { get; set; }
        public int IdAnimal { get; set; }  // vínculo com o animal
        public string NomeTutor { get; set; }
        public string SexoTutor { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Endereço
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }


        public List<Animal> Animais { get; set; } = new List<Animal>();
    }
}
