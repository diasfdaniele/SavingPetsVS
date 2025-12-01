using MySql.Data.MySqlClient;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace SavingPets.DAL
{
    public class BancoDadosLogAlteracoes
    {
        private Conexao conexao = new Conexao();

        public List<LogAlteracao> ListarLogs()
        {
            List<LogAlteracao> lista = new List<LogAlteracao>();

            // Query que cruza as tabelas para pegar o nome do voluntário
            string sql = @"
                SELECT 
                    L.idLogAlteracao, 
                    L.descricao, 
                    L.dataHora,
                    P.nome AS nomeVoluntario
                FROM LogAlteracao L
                INNER JOIN Voluntario V ON L.idVoluntario = V.idVoluntario
                INNER JOIN Pessoa P ON V.idPessoa = P.idPessoa
                ORDER BY L.dataHora DESC;"; // Mais recentes primeiro

            using (MySqlConnection conect = conexao.GetConnection())
            {
                try
                {
                    conect.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conect))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LogAlteracao log = new LogAlteracao
                            {
                                IdLog = Convert.ToInt32(reader["idLogAlteracao"]),
                                NomeVoluntario = reader["nomeVoluntario"].ToString(),
                                Descricao = reader["descricao"].ToString(),
                                DataHora = Convert.ToDateTime(reader["dataHora"])
                            };
                            lista.Add(log);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao listar logs: " + ex.Message);
                }
            }
            return lista;
        }
    }
}