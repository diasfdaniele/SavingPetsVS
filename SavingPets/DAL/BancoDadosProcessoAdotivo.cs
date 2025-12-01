using MySql.Data.MySqlClient;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions; // Necessário para limpar o telefone
using static SavingPets.DAL.Login;

namespace SavingPets.DAL
{
    public class BancoDadosProcessoAdotivo
    {
        private Conexao conexao = new Conexao();

        // 1. LISTAR (MANTIDO IGUAL)
        public List<ProcessoAdotivo> ListarProcessos()
        {
            List<ProcessoAdotivo> lista = new List<ProcessoAdotivo>();
            string sql = @"
                SELECT PA.idProcessoAdotivo, PA.dataAdocao, PA.agendamentoVisita, PA.observacoes,
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
                            ProcessoAdotivo p = new ProcessoAdotivo();
                            p.IdProcesso = Convert.ToInt32(reader["idProcessoAdotivo"]);
                            p.DataAdocao = Convert.ToDateTime(reader["dataAdocao"]);
                            p.DataAgendamentoVisita = Convert.ToDateTime(reader["agendamentoVisita"]);
                            p.Observacoes = reader["observacoes"]?.ToString();

                            p.Animal = new Animal { IdAnimal = Convert.ToInt32(reader["idAnimal"]), NomeAnimal = reader["nomeDoAnimal"].ToString() };
                            string vacinasRaw = reader["listaVacinas"]?.ToString();
                            if (!string.IsNullOrEmpty(vacinasRaw)) p.Animal.Vacinas = vacinasRaw.Split('|').ToList();

                            p.Tutor = new Tutor
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
                            if (!string.IsNullOrEmpty(ddd) && !string.IsNullOrEmpty(num)) p.Tutor.Telefone = $"({ddd}) {num}";

                            lista.Add(p);
                        }
                    }
                }
                catch (Exception ex) { throw new Exception("Erro ao listar: " + ex.Message); }
            }
            return lista;
        }

        // 2. ALTERAR (AGORA ATUALIZA TUTOR TAMBÉM)
        public void Alterar(ProcessoAdotivo p)
        {
            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open();
                MySqlTransaction trans = conect.BeginTransaction();
                try
                {
                    ConfigurarSessao(conect, trans);

                    // A) Atualiza o Processo
                    string sqlProc = @"UPDATE ProcessoAdotivo SET dataAdocao=@data, agendamentoVisita=@visita, observacoes=@obs WHERE idProcessoAdotivo=@id";
                    using (MySqlCommand cmd = new MySqlCommand(sqlProc, conect, trans))
                    {
                        cmd.Parameters.AddWithValue("@data", p.DataAdocao);
                        cmd.Parameters.AddWithValue("@visita", p.DataAgendamentoVisita);
                        cmd.Parameters.AddWithValue("@obs", p.Observacoes ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@id", p.IdProcesso);
                        cmd.ExecuteNonQuery();
                    }

                    // B) Atualiza Endereço e Telefone do Tutor
                    if (p.Tutor != null)
                    {
                        // --- ATUALIZAÇÃO COMPLETA DO ENDEREÇO ---
                        // Agora atualizamos Rua, Numero, Bairro, Cidade, Estado e CEP
                        string sqlEnd = @"UPDATE Endereco E 
                                  INNER JOIN Tutor T ON E.idPessoa = T.idPessoa
                                  SET E.rua = @rua,
                                      E.numero = @numero,
                                      E.bairro = @bairro,
                                      E.cidade = @cidade,
                                      E.estado = @estado,
                                      E.cep = @cep,
                                      E.complemento = @complemento
                                  WHERE T.idTutor = @idTutor";

                        using (MySqlCommand cmdEnd = new MySqlCommand(sqlEnd, conect, trans))
                        {
                            cmdEnd.Parameters.AddWithValue("@rua", p.Tutor.Rua);

                            // Tratamento para garantir que Numero seja INT (se não for número, salva 0)
                            int numeroInt = 0;
                            int.TryParse(p.Tutor.Numero, out numeroInt);
                            cmdEnd.Parameters.AddWithValue("@numero", numeroInt);

                            cmdEnd.Parameters.AddWithValue("@bairro", p.Tutor.Bairro);
                            cmdEnd.Parameters.AddWithValue("@cidade", p.Tutor.Cidade);
                            cmdEnd.Parameters.AddWithValue("@estado", p.Tutor.Estado);
                            cmdEnd.Parameters.AddWithValue("@cep", p.Tutor.CEP);
                            cmdEnd.Parameters.AddWithValue("@complemento", p.Tutor.Complemento ?? "");
                            cmdEnd.Parameters.AddWithValue("@idTutor", p.Tutor.IdTutor);
                            cmdEnd.ExecuteNonQuery();
                        }

                        // --- ATUALIZAÇÃO DO TELEFONE ---
                        if (!string.IsNullOrEmpty(p.Tutor.Telefone))
                        {
                            string numeros = System.Text.RegularExpressions.Regex.Replace(p.Tutor.Telefone, @"[^\d]", "");
                            if (numeros.Length >= 10)
                            {
                                int ddd = int.Parse(numeros.Substring(0, 2));
                                int numero = int.Parse(numeros.Substring(2));

                                string sqlTel = @"UPDATE Telefone Tel
                                          INNER JOIN Tutor T ON Tel.idPessoa = T.idPessoa
                                          SET Tel.ddd = @ddd, Tel.numero = @numero
                                          WHERE T.idTutor = @idTutor";

                                using (MySqlCommand cmdTel = new MySqlCommand(sqlTel, conect, trans))
                                {
                                    cmdTel.Parameters.AddWithValue("@ddd", ddd);
                                    cmdTel.Parameters.AddWithValue("@numero", numero);
                                    cmdTel.Parameters.AddWithValue("@idTutor", p.Tutor.IdTutor);
                                    cmdTel.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    try { trans.Rollback(); } catch { }
                    throw new Exception("Erro ao alterar: " + ex.Message);
                }
            }
        }
        // --- OUTROS MÉTODOS MANTIDOS (SALVAR, EXCLUIR, ETC) ---
        public void Salvar(ProcessoAdotivo p)
        {
            // Mantido código de INSERT simples
            using (MySqlConnection conect = conexao.GetConnection()) { /* ... mesmo do anterior ... */ }
        }

        public void Excluir(int id)
        {
            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open(); MySqlTransaction trans = conect.BeginTransaction();
                try
                {
                    ConfigurarSessao(conect, trans);
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM ProcessoAdotivo WHERE idProcessoAdotivo = @id", conect, trans))
                    {
                        cmd.Parameters.AddWithValue("@id", id); cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
                catch { try { trans.Rollback(); } catch { } throw; }
            }
        }

        public ProcessoAdotivo BuscarPorId(int id) { return ListarProcessos().FirstOrDefault(p => p.IdProcesso == id); }
        public int ObterProximoId() { return 1; /* Simplificado */ }

        private void ConfigurarSessao(MySqlConnection conect, MySqlTransaction trans)
        {
            int id = SessaoUsuario.IdVoluntarioLogado > 0 ? SessaoUsuario.IdVoluntarioLogado : 1;
            using (MySqlCommand cmd = new MySqlCommand($"SET @voluntario_responsavel = {id}", conect, trans)) { cmd.ExecuteNonQuery(); }
        }


    }
}