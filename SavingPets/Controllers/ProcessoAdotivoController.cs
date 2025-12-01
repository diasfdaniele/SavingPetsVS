using SavingPets.DAL;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SavingPets.Controllers
{
    internal class ProcessoAdotivoController
    {
        // Conexão com o DAL
        private BancoDadosProcessoAdotivo processoDados = new BancoDadosProcessoAdotivo();

        public ProcessoAdotivo DependenciaProcessoAdotivo
        {
            get => default;
            set
            {
            }
        }

        public void Cadastrar(ProcessoAdotivo processo)
        {
            ValidarProcesso(processo);
            processoDados.Salvar(processo);
        }

        public List<ProcessoAdotivo> Listar()
        {
            return processoDados.ListarProcessos();
        }

        public ProcessoAdotivo BuscarPorId(int id)
        {
            if (id <= 0) return null;
            return processoDados.BuscarPorId(id);
        }

        public void Editar(ProcessoAdotivo processoEditado)
        {
            if (processoEditado.IdProcesso <= 0)
                throw new Exception("ID do processo inválido para edição!");

            ValidarProcesso(processoEditado);
            processoDados.Alterar(processoEditado);
        }

        public void Excluir(int id)
        {
            if (id <= 0) throw new Exception("ID inválido.");
            processoDados.Excluir(id);
        }

        public int ObterProximoId()
        {
            return processoDados.ObterProximoId();
        }

        // Validações básicas antes de enviar pro banco
        private void ValidarProcesso(ProcessoAdotivo p)
        {
            if (p.Animal == null || p.Animal.IdAnimal <= 0)
                throw new Exception("É necessário vincular um Animal ao processo.");

            if (p.Tutor == null || p.Tutor.IdTutor <= 0)
                throw new Exception("É necessário vincular um Tutor ao processo.");

            if (p.DataAdocao == DateTime.MinValue)
                throw new Exception("Data de adoção inválida.");
        }
    }
}