using System;
using System.Collections.Generic;
using System.Linq;
using SavingPets.Models;

namespace SavingPets.Controllers
{
    public class ProcessoAdotivoController
    {
        //CLASSE QUE IRÁ MANIPULAR OS DADOS DAS OCORRENCIAS
        //CÓDIGO CRIADO PARA SIMULAR SITUAÇÕES DE TESTE DO SISTEMA
        //NECESSÁRIO AJUSTAR NA INTEGRAÇÃO COM BANCO DE DADOS

        // Lista simulando o banco de dados
        private static List<ProcessoAdotivo> listaProcessos = new List<ProcessoAdotivo>();

        // Método para cadastrar novo processo
        public void CadastrarProcesso(ProcessoAdotivo novoProcesso)
        {
            // Gera um ID automático se ainda não tiver
            if (novoProcesso.IdProcesso == 0)
                novoProcesso.IdProcesso = listaProcessos.Count + 1;

            listaProcessos.Add(novoProcesso);
        }

        // Buscar por ID
        public ProcessoAdotivo BuscarPorId(int id)
        {
            return listaProcessos.FirstOrDefault(p => p.IdProcesso == id);
        }

        // Buscar por nome do tutor
        public List<ProcessoAdotivo> BuscarPorNomeTutor(string nome)
        {
            return listaProcessos
                .Where(p => p.NomeTutor.ToLower().Contains(nome.ToLower()))
                .ToList();
        }

        // Retornar todos os processos
        public List<ProcessoAdotivo> ListarTodos()
        {
            return listaProcessos;
        }
    }
}
