using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingPets.Models
{
    public class LogAlteracao
    {
        public int IdLog { get; set; }
        public string NomeVoluntario { get; set; } // Nome da Pessoa/Voluntário
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
    }
}