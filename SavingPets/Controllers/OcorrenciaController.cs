using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SavingPets.Controllers
{
    public class OcorrenciaController
    {
        //CLASSE QUE IRÁ MANIPULAR OS DADOS DAS OCORRENCIAS
        //CÓDIGO CRIADO PARA SIMULAR SITUAÇÕES DE TESTE DO SISTEMA
        //NECESSÁRIO AJUSTAR NA INTEGRAÇÃO COM BANCO DE DADOS

        //Lista compartilhada entre todas as instâncias
        private static List<Ocorrencia> listaOcorrencias = new List<Ocorrencia>();

        //Método para cadastrar ocorrencia
        public void CadastrarOcorrencia(Ocorrencia ocorrencia)
        {
            listaOcorrencias.Add(ocorrencia);
        }

        //Método para listar todas as ocorrências
        public List<Ocorrencia> ListarOcorrencias()
        {
            return listaOcorrencias;
        }

        //Método para buscar por nome, ID etc.
        public List<Ocorrencia> BuscarOcorrencias(string termo, string tipoFiltro)
        {
            List<Ocorrencia> resultados = new List<Ocorrencia>();

            foreach (Ocorrencia o in listaOcorrencias)
            {
                if (tipoFiltro == "NomeTutor" && o.Processo.NomeTutor.ToLower().Contains(termo.ToLower()))
                    resultados.Add(o);

                else if (tipoFiltro == "NomeAnimal" && o.Processo.NomeAnimal.ToLower().Contains(termo.ToLower()))
                    resultados.Add(o);

                else if (tipoFiltro == "IdProcesso" && o.Processo.IdProcesso.ToString() == termo)
                    resultados.Add(o);

                else if (tipoFiltro == "IdOcorrencia" && o.IdOcorrencia.ToString() == termo)
                    resultados.Add(o);
            }

            return resultados;
        }
    }
}