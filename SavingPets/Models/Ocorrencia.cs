using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SavingPets.Models
{
    //Classe que representa uma ocorrência registrada
    //Cada ocorrência está sempre associada a um processo adotivo específico
    public class Ocorrencia
    {
        public int IdOcorrencia { get; set; }

        // campo que o form usa como Id do processo
        // no banco esse campo se chama idProcessoAdotivo
        public int IdProcesso { get; set; }
        public int IdProcessoAdotivo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string Gravidade { get; set; }           
        public string ProvidenciaTomada { get; set; }   

        // para facilitar preenchimento do grid / detalhes
        public string NomeTutor { get; set; }
        public string NomeAnimal { get; set; }

        // objeto opcional com mais dados do processo
        public ProcessoAdotivo Processo { get; set; }

        
    }
}
