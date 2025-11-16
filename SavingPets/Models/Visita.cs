using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingPets.Models
{
    public class Visita
    {
        public int IdVisita { get; set; }
        public ProcessoAdotivo Processo { get; set; }

        // Dados da visita
        public DateTime DataVisita { get; set; }
        public string Responsavel { get; set; }
        public string Status { get; set; }

        // Bem-estar do animal
        public string CondicaoFisica { get; set; }
        public string Comportamento { get; set; }
        public string AnimalSaudavel { get; set; } // Sim/Não/Em dúvida
        public string CondicoesHigiene { get; set; }
        public string VacinasEmDia { get; set; } // Sim/Não
        public string AcompanhamentoVeterinario { get; set; } // Sim/Não

        // Ambiente
        public string CondicaoAmbiente { get; set; } // Seguro / Adequado / Inseguro
        public string MausTratos { get; set; } // Sim / Não / Em dúvida

        // Adaptação e relacionamento
        public string AdaptacaoAmbiente { get; set; }
        public string RelacaoTutor { get; set; }
        public string AlteracoesComportamento { get; set; }

        // Recomendações e ações futuras
        public string OrientacoesDadas { get; set; }
        public string ConclusaoVisita { get; set; }
        public string Observacoes {  get; set; }

        public DateTime ProximaVisitaSugerida { get; set; }

    }
}
