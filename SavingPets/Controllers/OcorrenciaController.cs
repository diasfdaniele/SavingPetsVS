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
        //CAMADA ATUA COMO PONTE ENTRE INTERFACE E DADOS

        //Lista compartilhada entre todas as instâncias
        //Simulação de armazenamento em memória
        // (BANCO) — será substituída por SELECT no banco de dados
        private static List<Ocorrencia> listaOcorrencias = new List<Ocorrencia>();

        //Comando para geração de ID automático
        // (BANCO) — esse valor será gerado automaticamente pelo campo AUTO_INCREMENT do MySQL
        private static int ultimoId = 0;

        //Método para validação dos campos da ocorrência
        //Apresenta mensagem clara quando entrada inválida
        private void Validar(Ocorrencia ocorrencia)
        {
            //Verifica se objeto recebido é nulo
            if (ocorrencia == null)
                throw new ArgumentNullException("ocorrencia", "Ocorrência é nula.");

            //Verifica se processo adotivo foi informado
            // (BANCO) — validação continua igual, pois depende do objeto, não do banco
            if (ocorrencia.Processo == null)
                throw new Exception("ATENÇÃO: É obrigatório selecionar um processo adotivo anter de prosseguir.");

            //Descrição como campo de preenchimento obrigatório
            if (string.IsNullOrWhiteSpace(ocorrencia.Descricao))
                throw new Exception("ATENÇÃO: A descrição do ocorrido é campo de preenchimento obrigatório.");

            //Validação da gravidade
            var grav = (ocorrencia.Gravidade ?? "").ToLower();
            if (!(grav == "baixa" || grav == "média" || grav == "media" || grav == "alta"))
                throw new Exception("ATENÇÃO: A gravidade da ocorrência é campo obrigatório. \nInforme a gravidade da ocorrência (Baixa, Média ou Alta).");

            //Não pode ser inserida data superior a data atual
            if (ocorrencia.DataOcorrencia > DateTime.Now)
                throw new Exception("ATENÇÃO: A data informada não pode ser posterior à data de hoje.");

            //Data do ocorrido não pode ser anterior à data de adoção (regra opcional)
            if (ocorrencia.Processo != null && ocorrencia.DataOcorrencia < ocorrencia.Processo.DataAdocao)
                throw new Exception("ATENÇÃO: A data do ocorrido não pode ser anterior à data de adoção do processo.");
        }

        //Método para cadastrar ocorrencia
        public void CadastrarOcorrencia(Ocorrencia ocorrencia)
        {
            //Chama o método de validação
            Validar(ocorrencia);

            //Gera Id automático
            // (BANCO) — será removido, pois o ID virá do banco após o INSERT
            ultimoId++;
            ocorrencia.IdOcorrencia = ultimoId;

            //Adiciona ocorrencia na lista de memoria
            // (BANCO) — será substituído por INSERT INTO Ocorrencias (...)
            listaOcorrencias.Add(ocorrencia);
        }

        //Método para listar todas as ocorrências
        public List<Ocorrencia> ListarOcorrencias()
        {
            //Retorna todas as ocorrências simuladas
            // (BANCO) — será substituído por SELECT * FROM Ocorrencias
            return listaOcorrencias;
        }

        //Método para buscar por nome, ID etc.
        public List<Ocorrencia> BuscarOcorrencias(string termo, string tipoFiltro)
        {
            List<Ocorrencia> resultados = new List<Ocorrencia>();

            //Percorre todas as ocorrencias cadastradas
            // (BANCO) — toda essa filtragem será substituída por SELECT com WHERE dinâmico
            foreach (Ocorrencia o in listaOcorrencias)
            {
                if (tipoFiltro == "NomeTutor" && o.Processo.Tutor.NomeTutor.ToLower().Contains(termo.ToLower()))
                    resultados.Add(o);

                else if (tipoFiltro == "NomeAnimal" && o.Processo.Animal.NomeAnimal.ToLower().Contains(termo.ToLower()))
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
