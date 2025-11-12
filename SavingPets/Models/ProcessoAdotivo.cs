using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingPets.Models
{
    public class ProcessoAdotivo
    {
        public int IdProcesso { get; set; }

        // Ligação com Tutor
        public int IdTutor { get; set; }
        public string NomeTutor { get; set; }

        // Ligação com Animal
        public int IdAnimal { get; set; }
        public string NomeAnimal { get; set; }

        // Informações específicas do processo de adoção
        public DateTime DataAdocao { get; set; }
        public DateTime DataAgendamentoVisita { get; set; }
        public string Observacoes { get; set; }
    }
}
