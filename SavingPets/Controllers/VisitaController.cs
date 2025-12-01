using SavingPets.Models;
using SavingPets.DAL;
using System;
using System.Collections.Generic;

public class VisitaController
{
    private readonly BancoDadosVisita _repository = new BancoDadosVisita();

    //CADASTRAR VISITA – versão antiga (para compatibilidade)
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
            ObservacoesDetalhadas = new ObservacoesVisita() // evita null
        };

        return _repository.InserirVisitaCompleta(visita);
    }

    //CADASTRAR VISITA – NOVO (com objeto completo)
    public bool CadastrarVisita(Visita visita)
    {
        if (visita == null)
            throw new ArgumentNullException(nameof(visita));

        //Garante que ObservacoesDetalhadas nunca seja null
        if (visita.ObservacoesDetalhadas == null)
            visita.ObservacoesDetalhadas = new ObservacoesVisita();

        //IdProcessoAdotivo é o mesmo campo da UI chamado IdAdocao
        visita.IdProcessoAdotivo = visita.IdAdocao;

        return _repository.InserirVisitaCompleta(visita);
    }

    //LISTAR TODAS AS VISITAS
    public List<Visita> ListarVisitas()
    {
        return _repository.ListarVisitas();
    }

    //BUSCAR POR ID
    public Visita BuscarVisita(int id)
    {
        return _repository.BuscarVisita(id);
    }

    //BUSCAR POR FILTRO (texto)
    public List<Visita> BuscarVisita(string filtro)
    {
        if (string.IsNullOrWhiteSpace(filtro))
            return ListarVisitas();

        return _repository.BuscarVisitasPorFiltro(filtro);
    }

    //LISTAR OBSERVAÇÕES (retorna lista de strings)
    public List<string> ListarObservacoesPorVisita(int idVisita)
    {
        var visita = _repository.BuscarVisita(idVisita);

        if (visita == null)
            return new List<string>();

        if (visita.Observacoes == null)
            visita.Observacoes = new List<string>();

        return visita.Observacoes;
    }

    //EXCLUIR VISITA
    public bool ExcluirVisita(int id)
    {
        return _repository.ExcluirVisita(id);
    }
}
