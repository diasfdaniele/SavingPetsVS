using MySql.Data.MySqlClient;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static SavingPets.DAL.Login;

namespace SavingPets.DAL
{
    public class BancoDadosProcessoAdotivo
    {
        private Conexao conexao = new Conexao();

        //LISTAR TODOS (Com JOIN em Telefone e Endereço)
        public List<ProcessoAdotivo> ListarProcessos()
        {
            List<ProcessoAdotivo> lista = new List<ProcessoAdotivo>();

            string sql = @"
                SELECT 
                    PA.idProcessoAdotivo, PA.dataAdocao, PA.agendamentoVisita, PA.observacoes,
                    
                    A.idAnimal, A.nome AS nomeDoAnimal,
                    (SELECT GROUP_CONCAT(nome SEPARATOR '|') FROM Vacina V WHERE V.idAnimal = A.idAnimal) AS listaVacinas,

                    T.idTutor, P.nome AS nomeDoTutor,
                    
                    Tel.ddd, Tel.numero AS numeroTelefone,
                    
                    E.rua, E.bairro, E.cidade, E.estado, E.numero, E.cep, E.complemento
        
                FROM ProcessoAdotivo PA
                INNER JOIN Animal A ON PA.idAnimal = A.idAnimal
                INNER JOIN Tutor T ON PA.idTutor = T.idTutor
                INNER JOIN Pessoa P ON T.idPessoa = P.idPessoa
                LEFT JOIN Endereco E ON P.idPessoa = E.idPessoa
                LEFT JOIN Telefone Tel ON P.idPessoa = Tel.idPessoa
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
                            processo.IdProcesso = Convert.ToInt32(reader["idProcessoAdotivo"]);
                            processo.DataAdocao = Convert.ToDateTime(reader["dataAdocao"]);
                            processo.DataAgendamentoVisita = Convert.ToDateTime(reader["agendamentoVisita"]);
                            processo.Observacoes = reader["observacoes"]?.ToString();

                            // Animal
                            processo.Animal = new Animal
                            {
                                IdAnimal = Convert.ToInt32(reader["idAnimal"]),
                                NomeAnimal = reader["nomeDoAnimal"].ToString()
                            };
                            string vacinasRaw = reader["listaVacinas"]?.ToString();
                            if (!string.IsNullOrEmpty(vacinasRaw))
                                processo.Animal.Vacinas = vacinasRaw.Split('|').ToList();

                            // Tutor
                            processo.Tutor = new Tutor
                            {
                                IdTutor = Convert.ToInt32(reader["idTutor"]),
                                NomeTutor = reader["nomeDoTutor"].ToString(),
                                Rua = reader["rua"]?.ToString(),
                                Bairro = reader["bairro"]?.ToString(),
                                Cidade = reader["cidade"]?.ToString(),
                                Estado = reader["estado"]?.ToString(),
                                Numero = reader["numero"]?.ToString(),
                                CEP = reader["cep"]?.ToString(),
                                Complemento = reader["complemento"]?.ToString()
                            };

                            string ddd = reader["ddd"]?.ToString();
                            string num = reader["numeroTelefone"]?.ToString();
                            if (!string.IsNullOrEmpty(ddd) && !string.IsNullOrEmpty(num))
                            {
                                processo.Tutor.Telefone = $"({ddd}) {num}";
                            }

                            lista.Add(processo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro no DAL ao listar processos: " + ex.Message);
                }
            }
            return lista;
        }

        //BUSCAR POR ID
        public ProcessoAdotivo BuscarPorId(int id)
        {
            return ListarProcessos().FirstOrDefault(p => p.IdProcesso == id);
        }

        // 3. SALVAR (INSERT)
        public void Salvar(ProcessoAdotivo processo)
        {
            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open();
                MySqlTransaction trans = conect.BeginTransaction();
                try
                {
                    ConfigurarSessao(conect, trans);

                    string sql = @"
                        INSERT INTO ProcessoAdotivo (idAnimal, idTutor, dataAdocao, agendamentoVisita, observacoes)
                        VALUES (@idAnimal, @idTutor, @dataAdocao, @agendamentoVisita, @observacoes);";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conect, trans))
                    {
                        cmd.Parameters.AddWithValue("@idAnimal", processo.Animal.IdAnimal);
                        cmd.Parameters.AddWithValue("@idTutor", processo.Tutor.IdTutor);
                        cmd.Parameters.AddWithValue("@dataAdocao", processo.DataAdocao);
                        cmd.Parameters.AddWithValue("@agendamentoVisita", processo.DataAgendamentoVisita);
                        cmd.Parameters.AddWithValue("@observacoes", processo.Observacoes ?? (object)DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    try { trans.Rollback(); } catch { }
                    throw new Exception("Erro ao salvar processo: " + ex.Message);
                }
            }
        }

        //ALTERAR (UPDATE)
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
                        UPDATE ProcessoAdotivo 
                        SET dataAdocao = @dataAdocao, 
                            agendamentoVisita = @agendamentoVisita, 
                            observacoes = @observacoes
                        WHERE idProcessoAdotivo = @id;";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conect, trans))
                    {
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
                    throw new Exception("Erro ao alterar processo: " + ex.Message);
                }
            }
        }

        //EXCLUIR (DELETE)
        public void Excluir(int id)
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
                        cmd.Parameters.AddWithValue("@id", id);
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

        //PRÓXIMO ID
        public int ObterProximoId()
        {
            int nextId = 1;
            using (MySqlConnection conect = conexao.GetConnection())
            {
                try
                {
                    conect.Open();
                    string sql = $@"SELECT AUTO_INCREMENT FROM information_schema.TABLES WHERE TABLE_SCHEMA = '{conect.Database}' AND TABLE_NAME = 'ProcessoAdotivo';";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conect))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value) nextId = Convert.ToInt32(result);
                    }
                }
                catch { }
            }
            return nextId;
        }

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