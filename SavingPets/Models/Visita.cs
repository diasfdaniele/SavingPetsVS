using System;
using System.Collections.Generic;

namespace SavingPets.Models
{
    public class Visita
    {
        public int IdVisita { get; set; }
        public int IdAdocao { get; set; }
        public int IdProcessoAdotivo
        {
            get => IdAdocao;
            set => IdAdocao = value;
        }

        public DateTime DataVisita { get; set; }
        public string Responsavel { get; set; }
        public string Situacao { get; set; }
        public List<string> Observacoes { get; set; } = new List<string>();
        public int IdVoluntario { get; set; }             // idVoluntario FK (preencher na UI/controle)
        public DateTime DataAgendada { get; set; }        // agendamento
        public string Conclusao { get; set; }             // conclusao
        public string Orientacoes { get; set; }           // orientacoes

        // Observações detalhadas (tabela ObservacoesVisita)
        public ObservacoesVisita ObservacoesDetalhadas { get; set; } = new ObservacoesVisita();

        
    }
}
