using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingPets.Models
{
    internal class Animal
    {
        public int IdAnimal { get; set; }
        
        public string NomeAnimal { get; set; }
        
        public string Especie { get; set; } 
        
        public string Raca { get; set; }
       
        public string SexoAnimal { get; set; } 
        
        public string Vacinas { get; set; } 

        public bool Vermifugado { get; set; }
        public bool Castrado { get; set; }

        public string HistoricoDoencas { get; set; }
        
        
        
    }
}
