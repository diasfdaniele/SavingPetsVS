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

        // Representa processo adotivo ao qual ocorrência está vinculada
        // O tipo "ProcessoAdotivo" é outra classe do sistema, usada aqui como referência
        public ProcessoAdotivo Processo { get; set; }  

        public DateTime DataOcorrencia { get; set; }
        public string Descricao { get; set; }
        public string Gravidade { get; set; }
        public string ProvidenciaTomada { get; set; }
    }
}
