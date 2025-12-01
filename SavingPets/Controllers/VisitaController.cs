using SavingPets.Models;
using SavingPets.DAL;
using System;
using System.Collections.Generic;

namespace SavingPets.Controllers // Namespace ajustado
{
    public class VisitaController
    {
        private readonly BancoDadosVisita _repository = new BancoDadosVisita();

        public Visita DependenciaVisita
        {
            get => default;
            set { }
        }

        //CADASTRAR VISITA – versão antiga
        public bool CadastrarVisita(
            int idAdocao,
            DateTime data,
            string responsavel,
            string situacao,
            List<string> observacoes)
        {
            Visita visita = new Visita
            {
                IdAdocao = idAdocao,
                DataVisita = data,
                Responsavel = responsavel,
                Situacao = situacao,
                Observacoes = observacoes,
                ObservacoesDetalhadas = new ObservacoesVisita()
            };
            return _repository.InserirVisitaCompleta(visita);
        }

        //CADASTRAR VISITA – NOVO
        public bool CadastrarVisita(Visita visita)
        {
            if (visita == null) throw new ArgumentNullException(nameof(visita));
            if (visita.ObservacoesDetalhadas == null) visita.ObservacoesDetalhadas = new ObservacoesVisita();
            visita.IdProcessoAdotivo = visita.IdAdocao;
            return _repository.InserirVisitaCompleta(visita);
        }

        public List<Visita> ListarVisitas() => _repository.ListarVisitas();
        public Visita BuscarVisita(int id) => _repository.BuscarVisita(id);
        public bool ExcluirVisita(int id) => _repository.ExcluirVisita(id);
        public int ObterProximoId() => _repository.ObterProximoId();

        public List<Visita> BuscarVisita(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro)) return ListarVisitas();
            return _repository.BuscarVisitasPorFiltro(filtro);
        }

        public List<string> ListarObservacoesPorVisita(int idVisita)
        {
            var visita = _repository.BuscarVisita(idVisita);
            if (visita == null) return new List<string>();
            return visita.Observacoes ?? new List<string>();
        }

        // 🔥 NOVO: Obtém o nome do voluntário logado para preencher a tela
        public string ObterNomeResponsavel()
        {
            return _repository.ObterNomeVoluntarioLogado();
        }
    }
}