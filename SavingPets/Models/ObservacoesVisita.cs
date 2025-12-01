using System;

namespace SavingPets.Models
{
    // Representa a linha da tabela ObservacoesVisita (1:1 com Visita)
    public class ObservacoesVisita
    {
        public int IdObservacoesVisita { get; set; }
        public int IdVisita { get; set; }

        public string CondicaoFisica { get; set; }        // condicao_fisica
        public string Comportamento { get; set; }         // comportamento
        public string AparenciaSaudavel { get; set; }     // aparencia_saudavel
        public string CondicoesHigiene { get; set; }      // condicoes_higiene
        public string Vacinado { get; set; }              // vacinado
        public string Acompanhamento { get; set; }        // acompanhamento
        public string CondicoesAmbiente { get; set; }     // condicoes_ambiente
        public string IndicioMaustratos { get; set; }     // indicio_maustratos
        public string Adaptacao { get; set; }             // adaptacao
        public string RelacaoTutor { get; set; }          // relacao_tutor
        public string Alteracoes { get; set; }            // alteracoes
        public string ObservacoesLivres { get; set; }     // observacoes (campo texto)
    }
}
