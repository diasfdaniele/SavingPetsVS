using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SavingPets.Controllers
{
    internal class ProcessoAdotivoController
    {
        //POR ENQUANTO: lista em memória
        private static List<ProcessoAdotivo> processos = new List<ProcessoAdotivo>();

        // Quando integrar banco, substituir por chamada ao DAL
        // private static BancoDadosProcessoAdotivo processoDados = new BancoDadosProcessoAdotivo();

        public void Cadastrar(ProcessoAdotivo processo)
        {
            if (processo.IdProcesso == 0)
            {
                processo.IdProcesso = ObterProximoId();
            }

            // FUTURO: processoDados.Salvar(processo);
            processos.Add(processo);
        }

        public List<ProcessoAdotivo> Listar()
        {
            // FUTURO: return processoDados.ListarTodos();
            return processos;
        }
        public ProcessoAdotivo BuscarPorId(int id)
        {
            // FUTURO: return processoDados.Buscar(id);
            return processos.FirstOrDefault(p => p.IdProcesso == id);
        }

        public void Editar(ProcessoAdotivo processoEditado)
        {
            var processo = BuscarPorId(processoEditado.IdProcesso);
            if (processo == null)
                throw new Exception("Processo não encontrado!");

            processo.Tutor = processoEditado.Tutor;
            processo.Animal = processoEditado.Animal;
            processo.DataAdocao = processoEditado.DataAdocao;
            processo.Observacoes = processoEditado.Observacoes;

            // FUTURO: processoDados.Alterar(processoEditado);
        }

        public int ObterProximoId()
        {
            // ➜ FUTURO: return processoDados.ExtrairMaiorId() + 1;
            return processos.Count == 0 ? 1 : processos.Max(p => p.IdProcesso) + 1;
        }
    }
}
