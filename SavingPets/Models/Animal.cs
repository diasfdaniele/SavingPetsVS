using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingPets.Models
{
    public class Animal
    {
        public int IdAnimal { get; set; }              // PK (gerado pelo DB)
        public string NomeAnimal { get; set; }
        public string Especie { get; set; }           // "Cachorro" / "Gato"
        public string Raca { get; set; }
        public string SexoAnimal { get; set; }        // "Macho" / "Fêmea"

        // Lista de vacinas (cada item será um registro na tabela Vacina)
        public List<string> Vacinas { get; set; } = new List<string>();

        public bool Vermifugado { get; set; }         // true = Sim, false = Não
        public bool Castrado { get; set; }            // true = Sim, false = Não

        public string HistoricoDoencas { get; set; }  // histórico de saúde
    }
}
