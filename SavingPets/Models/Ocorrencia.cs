using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SavingPets.Models
{
    public class Ocorrencia
    {
        public int IdOcorrencia { get; set; }
        public ProcessoAdotivo Processo { get; set; }  // liga a ocorrência ao processo
        public DateTime DataOcorrencia { get; set; }
        public string Descricao { get; set; }
        public string Gravidade { get; set; }
        public string ProvidenciaTomada { get; set; }
    }
}
