using MySql.Data.MySqlClient;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using static SavingPets.FrmGerenciarOcorrencias;

namespace SavingPets.DAL
{
    public class BancoDadosOcorrencia
    {
        private Conexao conexao = new Conexao();

        // Insere uma nova ocorrência no BD (usa transação)
        public void SalvarDados(Ocorrencia ocorr)
        {
            using (MySqlConnection conn = conexao.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = @"
                            INSERT INTO Ocorrencia
                            (idProcessoAdotivo, descricao, dataOcorrencia, acao, tipoOcorrencia)
                            VALUES (@idProcesso, @descricao, @dataOcorrencia, @acao, @tipo)";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@idProcesso", ocorr.IdProcessoAdotivo);
                            cmd.Parameters.AddWithValue("@descricao", ocorr.Descricao ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@dataOcorrencia", ocorr.DataOcorrencia.Date);
                            cmd.Parameters.AddWithValue("@acao",
                                string.IsNullOrWhiteSpace(ocorr.ProvidenciaTomada) ? (object)DBNull.Value : ocorr.ProvidenciaTomada);
                            cmd.Parameters.AddWithValue("@tipo",
                                string.IsNullOrWhiteSpace(ocorr.Gravidade) ? (object)DBNull.Value : ocorr.Gravidade);

                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        try { trans.Rollback(); } catch { }
                        throw new Exception("Erro ao salvar ocorrência: " + ex.Message);
                    }
                }
            }
        }

        // Busca todas as ocorrências simples (sem JOINs) e retorna List<Ocorrencia>
        public List<Ocorrencia> BuscarTodos()
        {
            var lista = new List<Ocorrencia>();
            string sql = "SELECT idOcorrencia, idProcessoAdotivo, descricao, dataOcorrencia, acao, tipoOcorrencia FROM Ocorrencia ORDER BY idOcorrencia DESC";

            using (MySqlConnection conn = conexao.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var o = new Ocorrencia
                        {
                            IdOcorrencia = dr.GetInt32("idOcorrencia"),
                            IdProcessoAdotivo = dr.GetInt32("idProcessoAdotivo"),
                            Descricao = dr.IsDBNull(dr.GetOrdinal("descricao")) ? "" : dr.GetString("descricao"),
                            DataOcorrencia = dr.IsDBNull(dr.GetOrdinal("dataOcorrencia")) ? DateTime.MinValue : dr.GetDateTime("dataOcorrencia"),
                            ProvidenciaTomada = dr.IsDBNull(dr.GetOrdinal("acao")) ? "" : dr.GetString("acao"),
                            Gravidade = dr.IsDBNull(dr.GetOrdinal("tipoOcorrencia")) ? "" : dr.GetString("tipoOcorrencia")
                        };
                        lista.Add(o);
                    }
                }
            }
            return lista;
        }

        // Busca ocorrências detalhadas (com JOIN para NomeTutor / NomeAnimal) por idProcesso
        public List<OcorrenciaView> BuscarPorProcesso(int idProcesso)
        {
            string sql = @"
                SELECT 
                    o.idOcorrencia,
                    o.idProcessoAdotivo,
                    o.tipoOcorrencia AS tipo,
                    o.dataOcorrencia,
                    o.descricao,
                    pe.nome AS NomeTutor,
                    a.nome AS NomeAnimal
                FROM Ocorrencia o
                INNER JOIN ProcessoAdotivo pa ON o.idProcessoAdotivo = pa.idProcessoAdotivo
                INNER JOIN Tutor t ON pa.idTutor = t.idTutor
                INNER JOIN Pessoa pe ON t.idPessoa = pe.idPessoa
                INNER JOIN Animal a ON pa.idAnimal = a.idAnimal
                WHERE o.idProcessoAdotivo = @id
                ORDER BY o.dataOcorrencia DESC;
            ";

            var lista = new List<OcorrenciaView>();
            using (MySqlConnection conn = conexao.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idProcesso);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            lista.Add(new OcorrenciaView
                            {
                                IdOcorrencia = rdr.GetInt32("idOcorrencia"),
                                IdProcessoAdotivo = rdr.GetInt32("idProcessoAdotivo"),
                                NomeTutor = rdr.IsDBNull(rdr.GetOrdinal("NomeTutor")) ? "" : rdr.GetString("NomeTutor"),
                                NomeAnimal = rdr.IsDBNull(rdr.GetOrdinal("NomeAnimal")) ? "" : rdr.GetString("NomeAnimal"),
                                Tipo = rdr.IsDBNull(rdr.GetOrdinal("tipo")) ? "" : rdr.GetString("tipo"),
                                DataOcorrencia = rdr.IsDBNull(rdr.GetOrdinal("dataOcorrencia")) ? DateTime.MinValue : rdr.GetDateTime("dataOcorrencia"),
                                Descricao = rdr.IsDBNull(rdr.GetOrdinal("descricao")) ? "" : rdr.GetString("descricao")
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // Lista ocorrências do processo sem JOIN (se você preferir Ocorrencia simples)
        public List<Ocorrencia> ListarPorProcesso(int idProcesso)
        {
            var lista = new List<Ocorrencia>();
            string sql = @"
                SELECT idOcorrencia, idProcessoAdotivo, descricao, dataOcorrencia, acao, tipoOcorrencia
                FROM Ocorrencia
                WHERE idProcessoAdotivo = @idProcesso
                ORDER BY dataOcorrencia DESC";

            using (MySqlConnection conn = conexao.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idProcesso", idProcesso);
                    using (MySqlDataReader leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            var o = new Ocorrencia
                            {
                                IdOcorrencia = leitor.GetInt32("idOcorrencia"),
                                IdProcessoAdotivo = leitor.GetInt32("idProcessoAdotivo"),
                                Descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao")) ? "" : leitor.GetString("descricao"),
                                DataOcorrencia = leitor.IsDBNull(leitor.GetOrdinal("dataOcorrencia")) ? DateTime.MinValue : leitor.GetDateTime("dataOcorrencia"),
                                ProvidenciaTomada = leitor.IsDBNull(leitor.GetOrdinal("acao")) ? "" : leitor.GetString("acao"),
                                Gravidade = leitor.IsDBNull(leitor.GetOrdinal("tipoOcorrencia")) ? "" : leitor.GetString("tipoOcorrencia")
                            };
                            lista.Add(o);
                        }
                    }
                }
            }
            return lista;
        }

        // Busca por nome do tutor (usa a mesma query de JOIN; retorna OcorrenciaView)
        public List<OcorrenciaView> BuscarPorNomeTutor(string nome)
        {
            string sql = @"
                SELECT o.idOcorrencia, o.idProcessoAdotivo, o.tipoOcorrencia AS tipo, o.dataOcorrencia, o.descricao,
                       pe.nome AS NomeTutor, a.nome AS NomeAnimal
                FROM Ocorrencia o
                INNER JOIN ProcessoAdotivo pa ON o.idProcessoAdotivo = pa.idProcessoAdotivo
                INNER JOIN Tutor t ON pa.idTutor = t.idTutor
                INNER JOIN Pessoa pe ON t.idPessoa = pe.idPessoa
                INNER JOIN Animal a ON pa.idAnimal = a.idAnimal
                WHERE LOWER(pe.nome) LIKE LOWER(@nome)
                ORDER BY o.dataOcorrencia DESC;
            ";

            return ExecutarConsultaView(sql, new MySqlParameter("@nome", "%" + nome + "%"));
        }

        // Busca por nome do animal
        public List<OcorrenciaView> BuscarPorNomeAnimal(string nome)
        {
            string sql = @"
                SELECT o.idOcorrencia, o.idProcessoAdotivo, o.tipoOcorrencia AS tipo, o.dataOcorrencia, o.descricao,
                       pe.nome AS NomeTutor, a.nome AS NomeAnimal
                FROM Ocorrencia o
                INNER JOIN ProcessoAdotivo pa ON o.idProcessoAdotivo = pa.idProcessoAdotivo
                INNER JOIN Tutor t ON pa.idTutor = t.idTutor
                INNER JOIN Pessoa pe ON t.idPessoa = pe.idPessoa
                INNER JOIN Animal a ON pa.idAnimal = a.idAnimal
                WHERE LOWER(a.nome) LIKE LOWER(@nome)
                ORDER BY o.dataOcorrencia DESC;
            ";

            return ExecutarConsultaView(sql, new MySqlParameter("@nome", "%" + nome + "%"));
        }


        // Busca por id da ocorrência
        public OcorrenciaView BuscarPorId(int id)
        {
            string sql = @"
                SELECT o.idOcorrencia, o.idProcessoAdotivo, o.tipoOcorrencia AS tipo, o.dataOcorrencia, o.descricao,
                       pe.nome AS NomeTutor, a.nome AS NomeAnimal
                FROM Ocorrencia o
                INNER JOIN ProcessoAdotivo pa ON o.idProcessoAdotivo = pa.idProcessoAdotivo
                INNER JOIN Tutor t ON pa.idTutor = t.idTutor
                INNER JOIN Pessoa pe ON t.idPessoa = pe.idPessoa
                INNER JOIN Animal a ON pa.idAnimal = a.idAnimal
                WHERE o.idOcorrencia = @id
                LIMIT 1;
            ";

            var lista = ExecutarConsultaView(sql, new MySqlParameter("@id", id));
            return lista.Count > 0 ? lista[0] : null;
        }

        // Helper genérico que executa uma query (com JOINs) retornando List<OcorrenciaView>
        private List<OcorrenciaView> ExecutarConsultaView(string sql, MySqlParameter parametro)
        {
            var lista = new List<OcorrenciaView>();
            using (MySqlConnection conn = conexao.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    if (parametro != null) cmd.Parameters.Add(parametro);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            lista.Add(new OcorrenciaView
                            {
                                IdOcorrencia = rdr.GetInt32("idOcorrencia"),
                                IdProcessoAdotivo = rdr.GetInt32("idProcessoAdotivo"),
                                NomeTutor = rdr.IsDBNull(rdr.GetOrdinal("NomeTutor")) ? "" : rdr.GetString("NomeTutor"),
                                NomeAnimal = rdr.IsDBNull(rdr.GetOrdinal("NomeAnimal")) ? "" : rdr.GetString("NomeAnimal"),
                                Tipo = rdr.IsDBNull(rdr.GetOrdinal("tipo")) ? "" : rdr.GetString("tipo"),
                                DataOcorrencia = rdr.IsDBNull(rdr.GetOrdinal("dataOcorrencia")) ? DateTime.MinValue : rdr.GetDateTime("dataOcorrencia"),
                                Descricao = rdr.IsDBNull(rdr.GetOrdinal("descricao")) ? "" : rdr.GetString("descricao")
                            });
                        }
                    }
                }
            }
            return lista;
        }

        // Lista de ids (útil para comboboxes)
        public List<int> ListarIds()
        {
            var ids = new List<int>();
            string sql = "SELECT idOcorrencia FROM Ocorrencia";
            using (MySqlConnection conn = conexao.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                        ids.Add(leitor.GetInt32("idOcorrencia"));
                }
            }
            return ids;
        }
    }
}
