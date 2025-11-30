using MySql.Data.MySqlClient;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Data;
using static SavingPets.DAL.Login;

namespace SavingPets.DAL
{
    public class BancoDadosProcessoAdotivo
    {
        private Conexao conexao = new Conexao();

        // =================================================================
        // 1. LISTAR TODOS (Read)
        // =================================================================
        public List<ProcessoAdotivo> ListarProcessos()
        {
            List<ProcessoAdotivo> lista = new List<ProcessoAdotivo>();

            string sql = @"
                SELECT 
                    PA.idProcessoAdotivo, PA.dataAdocao, PA.agendamentoVisita, PA.observacoes,
                    A.idAnimal, A.nome AS nomeDoAnimal,
                    T.idTutor, P.nome AS nomeDoTutor
                FROM ProcessoAdotivo PA
                INNER JOIN Animal A ON PA.idAnimal = A.idAnimal
                INNER JOIN Tutor T ON PA.idTutor = T.idTutor
                INNER JOIN Pessoa P ON T.idPessoa = P.idPessoa
                ORDER BY PA.dataAdocao DESC;";

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
                            ProcessoAdotivo processo = new ProcessoAdotivo();

                            // Mapeamento Processo
                            processo.IdProcesso = Convert.ToInt32(reader["idProcessoAdotivo"]);
                            processo.DataAdocao = Convert.ToDateTime(reader["dataAdocao"]);
                            processo.DataAgendamentoVisita = Convert.ToDateTime(reader["agendamentoVisita"]);
                            processo.Observacoes = reader["observacoes"] != DBNull.Value ? reader["observacoes"].ToString() : "";

                            // Mapeamento Animal (Apenas o necessário para exibir na lista)
                            processo.Animal = new Animal
                            {
                                IdAnimal = Convert.ToInt32(reader["idAnimal"]),
                                NomeAnimal = reader["nomeDoAnimal"].ToString()
                            };

                            // Mapeamento Tutor (Apenas o necessário para exibir na lista)
                            processo.Tutor = new Tutor
                            {
                                IdTutor = Convert.ToInt32(reader["idTutor"]),
                                NomeTutor = reader["nomeDoTutor"].ToString()
                            };

                            lista.Add(processo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao listar processos: " + ex.Message);
                }
            }
            return lista;
        }

        // =================================================================
        // 2. BUSCAR POR ID (Read Unico)
        // =================================================================
        public ProcessoAdotivo BuscarPorId(int id)
        {
            ProcessoAdotivo processo = null;

            string sql = @"
                SELECT 
                    PA.idProcessoAdotivo, PA.dataAdocao, PA.agendamentoVisita, PA.observacoes,
                    A.idAnimal, A.nome AS nomeDoAnimal,
                    T.idTutor, P.nome AS nomeDoTutor
                FROM ProcessoAdotivo PA
                INNER JOIN Animal A ON PA.idAnimal = A.idAnimal
                INNER JOIN Tutor T ON PA.idTutor = T.idTutor
                INNER JOIN Pessoa P ON T.idPessoa = P.idPessoa
                WHERE PA.idProcessoAdotivo = @id;";

            using (MySqlConnection conect = conexao.GetConnection())
            {
                try
                {
                    conect.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conect))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                processo = new ProcessoAdotivo();

                                processo.IdProcesso = Convert.ToInt32(reader["idProcessoAdotivo"]);
                                processo.DataAdocao = Convert.ToDateTime(reader["dataAdocao"]);
                                processo.DataAgendamentoVisita = Convert.ToDateTime(reader["agendamentoVisita"]);
                                processo.Observacoes = reader["observacoes"]?.ToString();

                                processo.Animal = new Animal
                                {
                                    IdAnimal = Convert.ToInt32(reader["idAnimal"]),
                                    NomeAnimal = reader["nomeDoAnimal"].ToString()
                                };

                                processo.Tutor = new Tutor
                                {
                                    IdTutor = Convert.ToInt32(reader["idTutor"]),
                                    NomeTutor = reader["nomeDoTutor"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar processo: " + ex.Message);
                }
            }
            return processo;
        }

        // =================================================================
        // 3. SALVAR (Create)
        // =================================================================
        public void Salvar(ProcessoAdotivo processo)
        {
            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open();
                MySqlTransaction trans = conect.BeginTransaction();

                try
                {
                    // 1. Configura Sessão para Trigger (Log)
                    ConfigurarSessao(conect, trans);

                    // 2. Insert
                    string sql = @"
                        INSERT INTO ProcessoAdotivo (idAnimal, idTutor, dataAdocao, agendamentoVisita, observacoes)
                        VALUES (@idAnimal, @idTutor, @dataAdocao, @agendamentoVisita, @observacoes);";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conect, trans))
                    {
                        cmd.Parameters.AddWithValue("@idAnimal", processo.Animal.IdAnimal);
                        cmd.Parameters.AddWithValue("@idTutor", processo.Tutor.IdTutor);
                        cmd.Parameters.AddWithValue("@dataAdocao", processo.DataAdocao);
                        // Mapeia a propriedade DataAgendamentoVisita do Model para a coluna agendamentoVisita do Banco
                        cmd.Parameters.AddWithValue("@agendamentoVisita", processo.DataAgendamentoVisita);
                        cmd.Parameters.AddWithValue("@observacoes", processo.Observacoes ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    try { trans.Rollback(); } catch { }
                    throw new Exception("Erro ao cadastrar processo: " + ex.Message);
                }
            }
        }

        // =================================================================
        // 4. ALTERAR (Update)
        // =================================================================
        public void Alterar(ProcessoAdotivo processo)
        {
            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open();
                MySqlTransaction trans = conect.BeginTransaction();

                try
                {
                    ConfigurarSessao(conect, trans);

                    string sql = @"
                        UPDATE ProcessoAdotivo SET 
                            idAnimal = @idAnimal,
                            idTutor = @idTutor,
                            dataAdocao = @dataAdocao,
                            agendamentoVisita = @agendamentoVisita,
                            observacoes = @observacoes
                        WHERE idProcessoAdotivo = @id;";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conect, trans))
                    {
                        cmd.Parameters.AddWithValue("@idAnimal", processo.Animal.IdAnimal);
                        cmd.Parameters.AddWithValue("@idTutor", processo.Tutor.IdTutor);
                        cmd.Parameters.AddWithValue("@dataAdocao", processo.DataAdocao);
                        cmd.Parameters.AddWithValue("@agendamentoVisita", processo.DataAgendamentoVisita);
                        cmd.Parameters.AddWithValue("@observacoes", processo.Observacoes ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@id", processo.IdProcesso);

                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    try { trans.Rollback(); } catch { }
                    throw new Exception("Erro ao editar processo: " + ex.Message);
                }
            }
        }

        // =================================================================
        // 5. EXCLUIR (Delete)
        // =================================================================
        public void Excluir(int idProcesso)
        {
            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open();
                MySqlTransaction trans = conect.BeginTransaction();

                try
                {
                    ConfigurarSessao(conect, trans);

                    string sql = "DELETE FROM ProcessoAdotivo WHERE idProcessoAdotivo = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conect, trans))
                    {
                        cmd.Parameters.AddWithValue("@id", idProcesso);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    try { trans.Rollback(); } catch { }
                    throw new Exception("Erro ao excluir processo: " + ex.Message);
                }
            }
        }

        // =================================================================
        // 6. PRÓXIMO ID (Auxiliar)
        // =================================================================
        public int ObterProximoId()
        {
            int nextId = 1;
            using (MySqlConnection conect = conexao.GetConnection())
            {
                try
                {
                    conect.Open();
                    string sql = $@"SELECT AUTO_INCREMENT FROM information_schema.TABLES 
                                    WHERE TABLE_SCHEMA = '{conect.Database}' AND TABLE_NAME = 'ProcessoAdotivo';";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conect))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value) nextId = Convert.ToInt32(result);
                    }
                }
                catch { /* Ignora erro e retorna 1 */ }
            }
            return nextId;
        }

        // --- Método Privado para Configurar Sessão (Evita repetição) ---
        private void ConfigurarSessao(MySqlConnection conect, MySqlTransaction trans)
        {
            int idVol = SessaoUsuario.IdVoluntarioLogado;
            if (idVol > 0)
            {
                using (MySqlCommand cmd = new MySqlCommand($"SET @voluntario_responsavel = {idVol};", conect, trans))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}