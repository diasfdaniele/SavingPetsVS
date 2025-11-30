using MySql.Data.MySqlClient;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static SavingPets.DAL.Login;

namespace SavingPets.DAL
{
    public class BancoDeDadosTutor
    {
        private Conexao conexao = new Conexao();

        // =================================================================
        // 1. LISTAR TODOS OS TUTORES (Leitura)
        // =================================================================
        public List<Tutor> ListarTutores()
        {
            List<Tutor> listaTutores = new List<Tutor>();

            string sql = @"
                            SELECT 
                                T.idTutor, 
                                P.idPessoa, P.nome, P.cpf, P.email, P.dataNascimento, P.sexo, 
                                E.cep, E.rua, E.numero, E.bairro, E.cidade, E.estado, E.complemento,
                                Tel.ddd, Tel.numero AS numeroTelefone
                            FROM Tutor T
                            INNER JOIN Pessoa P ON T.idPessoa = P.idPessoa
                            INNER JOIN Endereco E ON P.idPessoa = E.idPessoa
                            INNER JOIN Telefone Tel ON P.idPessoa = Tel.idPessoa
                            ORDER BY P.nome ASC;";

            using (MySqlConnection conect = conexao.GetConnection())
            {
                try
                {
                    conect.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conect))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Tutor tutor = new Tutor();

                                tutor.IdTutor = Convert.ToInt32(reader["idTutor"]);
                                tutor.NomeTutor = reader["nome"].ToString();
                                tutor.CPF = reader["cpf"].ToString();
                                tutor.Email = reader["email"] != DBNull.Value ? reader["email"].ToString() : null;
                                tutor.DataNascimento = Convert.ToDateTime(reader["dataNascimento"]);
                                tutor.SexoTutor = reader["sexo"].ToString();

                                tutor.CEP = reader["cep"].ToString();
                                tutor.Rua = reader["rua"].ToString();
                                tutor.Numero = reader["numero"].ToString();
                                tutor.Bairro = reader["bairro"].ToString();
                                tutor.Cidade = reader["cidade"].ToString();
                                tutor.Estado = reader["estado"].ToString();
                                tutor.Complemento = reader["complemento"] != DBNull.Value ? reader["complemento"].ToString() : null;

                                string ddd = reader["ddd"].ToString();
                                string num = reader["numeroTelefone"].ToString();
                                tutor.Telefone = $"({ddd}) {num}";

                                listaTutores.Add(tutor);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao listar tutores: " + ex.Message);
                }
            }
            return listaTutores;
        }

        // =================================================================
        // 2. BUSCAR POR ID (Leitura)
        // =================================================================
        public Tutor BuscarPorId(int idTutor)
        {
            Tutor tutor = null;

            string sql = @"
                SELECT 
                    T.idTutor, 
                    P.idPessoa, P.nome, P.cpf, P.email, P.dataNascimento, P.sexo, 
                    E.cep, E.rua, E.numero, E.bairro, E.cidade, E.estado, E.complemento,
                    Tel.ddd, Tel.numero AS numeroTelefone
                FROM Tutor T
                INNER JOIN Pessoa P ON T.idPessoa = P.idPessoa
                INNER JOIN Endereco E ON P.idPessoa = E.idPessoa
                INNER JOIN Telefone Tel ON P.idPessoa = Tel.idPessoa
                WHERE T.idTutor = @idTutor;";

            using (MySqlConnection conect = conexao.GetConnection())
            {
                try
                {
                    conect.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conect))
                    {
                        cmd.Parameters.AddWithValue("@idTutor", idTutor);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tutor = new Tutor();
                                tutor.IdTutor = Convert.ToInt32(reader["idTutor"]);
                                tutor.NomeTutor = reader["nome"].ToString();
                                tutor.CPF = reader["cpf"].ToString();
                                tutor.Email = reader["email"] != DBNull.Value ? reader["email"].ToString() : null;
                                tutor.DataNascimento = Convert.ToDateTime(reader["dataNascimento"]);
                                tutor.SexoTutor = reader["sexo"].ToString();

                                tutor.CEP = reader["cep"].ToString();
                                tutor.Rua = reader["rua"].ToString();
                                tutor.Numero = reader["numero"].ToString();
                                tutor.Bairro = reader["bairro"].ToString();
                                tutor.Cidade = reader["cidade"].ToString();
                                tutor.Estado = reader["estado"].ToString();
                                tutor.Complemento = reader["complemento"] != DBNull.Value ? reader["complemento"].ToString() : null;

                                string ddd = reader["ddd"].ToString();
                                string num = reader["numeroTelefone"].ToString();
                                tutor.Telefone = $"({ddd}) {num}";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar tutor por ID: " + ex.Message);
                }
            }
            return tutor;
        }

        // =================================================================
        // 3. SALVAR DADOS (Create)
        // =================================================================
        public void SalvaDados(Tutor tutor)
        {
            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open();
                MySqlTransaction trans = conect.BeginTransaction();

                try
                {
                    // Log
                    int idVoluntarioAtual = SessaoUsuario.IdVoluntarioLogado;
                    if (idVoluntarioAtual > 0)
                    {
                        using (MySqlCommand cmdSessao = new MySqlCommand($"SET @voluntario_responsavel = {idVoluntarioAtual};", conect, trans))
                        {
                            cmdSessao.ExecuteNonQuery();
                        }
                    }

                    // Pessoa
                    string sqlInsertPessoa = @"
                        INSERT INTO Pessoa (nome, cpf, email, dataNascimento, sexo, dataCadastro, login, senha)
                        VALUES (@nome, @cpf, @email, @dataNascimento, @sexo, NOW(), @login, @senha);
                        SELECT LAST_INSERT_ID();";

                    int novoIdPessoa = 0;
                    using (MySqlCommand cmd = new MySqlCommand(sqlInsertPessoa, conect, trans))
                    {
                        cmd.Parameters.AddWithValue("@nome", tutor.NomeTutor);
                        cmd.Parameters.AddWithValue("@cpf", tutor.CPF);
                        cmd.Parameters.AddWithValue("@email", tutor.Email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@dataNascimento", tutor.DataNascimento);
                        cmd.Parameters.AddWithValue("@sexo", tutor.SexoTutor);
                        cmd.Parameters.AddWithValue("@login", tutor.Email);
                        cmd.Parameters.AddWithValue("@senha", "1234");
                        novoIdPessoa = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Endereco
                    string sqlInsertEndereco = @"
                        INSERT INTO Endereco (cep, rua, numero, bairro, cidade, estado, complemento, idPessoa)
                        VALUES (@cep, @rua, @numero, @bairro, @cidade, @estado, @complemento, @idPessoa);";

                    using (MySqlCommand cmdEnd = new MySqlCommand(sqlInsertEndereco, conect, trans))
                    {
                        cmdEnd.Parameters.AddWithValue("@cep", tutor.CEP);
                        cmdEnd.Parameters.AddWithValue("@rua", tutor.Rua);
                        cmdEnd.Parameters.AddWithValue("@numero", tutor.Numero);
                        cmdEnd.Parameters.AddWithValue("@bairro", tutor.Bairro);
                        cmdEnd.Parameters.AddWithValue("@cidade", tutor.Cidade);
                        cmdEnd.Parameters.AddWithValue("@estado", tutor.Estado);
                        cmdEnd.Parameters.AddWithValue("@complemento", tutor.Complemento ?? (object)DBNull.Value);
                        cmdEnd.Parameters.AddWithValue("@idPessoa", novoIdPessoa);
                        cmdEnd.ExecuteNonQuery();
                    }

                    // Telefone
                    string telNumeros = new string(tutor.Telefone.Where(char.IsDigit).ToArray());
                    if (telNumeros.Length >= 10)
                    {
                        string ddd = telNumeros.Substring(0, 2);
                        string numero = telNumeros.Substring(2);
                        string sqlInsertTel = @"INSERT INTO Telefone (ddd, numero, idPessoa) VALUES (@ddd, @numero, @idPessoa);";
                        using (MySqlCommand cmdTel = new MySqlCommand(sqlInsertTel, conect, trans))
                        {
                            cmdTel.Parameters.AddWithValue("@ddd", ddd);
                            cmdTel.Parameters.AddWithValue("@numero", numero);
                            cmdTel.Parameters.AddWithValue("@idPessoa", novoIdPessoa);
                            cmdTel.ExecuteNonQuery();
                        }
                    }

                    // Tutor
                    string sqlInsertTutor = @"INSERT INTO Tutor(idPessoa) VALUES (@idPessoa)";
                    using (MySqlCommand cmdTutor = new MySqlCommand(sqlInsertTutor, conect, trans))
                    {
                        cmdTutor.Parameters.AddWithValue("@idPessoa", novoIdPessoa);
                        cmdTutor.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    try { trans.Rollback(); } catch { }
                    throw new Exception("Erro ao salvar dados: " + ex.Message);
                }
            }
        }

        // =================================================================
        // 4. EDITAR TUTOR (Update)
        // =================================================================
        public void EditarTutor(Tutor tutorEditado)
        {
            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open();
                MySqlTransaction trans = conect.BeginTransaction();

                try
                {
                    int idVoluntarioAtual = SessaoUsuario.IdVoluntarioLogado;
                    if (idVoluntarioAtual > 0)
                    {
                        using (MySqlCommand cmdSessao = new MySqlCommand($"SET @voluntario_responsavel = {idVoluntarioAtual};", conect, trans))
                        {
                            cmdSessao.ExecuteNonQuery();
                        }
                    }

                    int idPessoa = 0;
                    string sqlGetId = "SELECT idPessoa FROM Tutor WHERE idTutor = @idTutor";
                    using (MySqlCommand cmdGet = new MySqlCommand(sqlGetId, conect, trans))
                    {
                        cmdGet.Parameters.AddWithValue("@idTutor", tutorEditado.IdTutor);
                        object result = cmdGet.ExecuteScalar();
                        if (result != null) idPessoa = Convert.ToInt32(result);
                        else throw new Exception("Tutor não encontrado.");
                    }

                    string sqlUpdatePessoa = @"
                        UPDATE Pessoa SET 
                            nome = @nome, cpf = @cpf, email = @email, 
                            dataNascimento = @dataNascimento, sexo = @sexo
                        WHERE idPessoa = @idPessoa;";

                    using (MySqlCommand cmd = new MySqlCommand(sqlUpdatePessoa, conect, trans))
                    {
                        cmd.Parameters.AddWithValue("@nome", tutorEditado.NomeTutor);
                        cmd.Parameters.AddWithValue("@cpf", tutorEditado.CPF);
                        cmd.Parameters.AddWithValue("@email", tutorEditado.Email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@dataNascimento", tutorEditado.DataNascimento);
                        cmd.Parameters.AddWithValue("@sexo", tutorEditado.SexoTutor);
                        cmd.Parameters.AddWithValue("@idPessoa", idPessoa);
                        cmd.ExecuteNonQuery();
                    }

                    string sqlUpdateEndereco = @"
                        UPDATE Endereco SET 
                            cep = @cep, rua = @rua, numero = @numero, bairro = @bairro, 
                            cidade = @cidade, estado = @estado, complemento = @complemento
                        WHERE idPessoa = @idPessoa;";

                    using (MySqlCommand cmdEnd = new MySqlCommand(sqlUpdateEndereco, conect, trans))
                    {
                        cmdEnd.Parameters.AddWithValue("@cep", tutorEditado.CEP);
                        cmdEnd.Parameters.AddWithValue("@rua", tutorEditado.Rua);
                        cmdEnd.Parameters.AddWithValue("@numero", tutorEditado.Numero);
                        cmdEnd.Parameters.AddWithValue("@bairro", tutorEditado.Bairro);
                        cmdEnd.Parameters.AddWithValue("@cidade", tutorEditado.Cidade);
                        cmdEnd.Parameters.AddWithValue("@estado", tutorEditado.Estado);
                        cmdEnd.Parameters.AddWithValue("@complemento", tutorEditado.Complemento ?? (object)DBNull.Value);
                        cmdEnd.Parameters.AddWithValue("@idPessoa", idPessoa);
                        cmdEnd.ExecuteNonQuery();
                    }

                    string telNumeros = new string(tutorEditado.Telefone.Where(char.IsDigit).ToArray());
                    if (telNumeros.Length >= 10)
                    {
                        string ddd = telNumeros.Substring(0, 2);
                        string numero = telNumeros.Substring(2);
                        string sqlUpdateTel = @"UPDATE Telefone SET ddd = @ddd, numero = @numero WHERE idPessoa = @idPessoa;";
                        using (MySqlCommand cmdTel = new MySqlCommand(sqlUpdateTel, conect, trans))
                        {
                            cmdTel.Parameters.AddWithValue("@ddd", ddd);
                            cmdTel.Parameters.AddWithValue("@numero", numero);
                            cmdTel.Parameters.AddWithValue("@idPessoa", idPessoa);
                            cmdTel.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    try { trans.Rollback(); } catch { }
                    throw new Exception("Erro ao editar dados: " + ex.Message);
                }
            }
        }

        // =================================================================
        // 5. EXCLUIR TUTOR (Delete) - [NOVO]
        // =================================================================
        public void ExcluirTutor(int idTutor)
        {
            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open();
                MySqlTransaction trans = conect.BeginTransaction();

                try
                {
                    // 1. Log (Define quem está excluindo)
                    int idVoluntarioAtual = SessaoUsuario.IdVoluntarioLogado;
                    if (idVoluntarioAtual > 0)
                    {
                        using (MySqlCommand cmdSessao = new MySqlCommand($"SET @voluntario_responsavel = {idVoluntarioAtual};", conect, trans))
                        {
                            cmdSessao.ExecuteNonQuery();
                        }
                    }

                    // 2. Busca o ID PESSOA vinculado ao Tutor
                    int idPessoa = 0;
                    string sqlGetId = "SELECT idPessoa FROM Tutor WHERE idTutor = @idTutor";
                    using (MySqlCommand cmdGet = new MySqlCommand(sqlGetId, conect, trans))
                    {
                        cmdGet.Parameters.AddWithValue("@idTutor", idTutor);
                        object result = cmdGet.ExecuteScalar();
                        if (result != null) idPessoa = Convert.ToInt32(result);
                        else throw new Exception("Tutor não encontrado para exclusão.");
                    }

                    // 3. Deleta a PESSOA (A Trigger do banco fará o delete em cascata de Tutor, Endereco, Telefone, etc)
                    string sqlDelete = "DELETE FROM Pessoa WHERE idPessoa = @idPessoa";
                    using (MySqlCommand cmd = new MySqlCommand(sqlDelete, conect, trans))
                    {
                        cmd.Parameters.AddWithValue("@idPessoa", idPessoa);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    try { trans.Rollback(); } catch { }
                    throw new Exception("Erro ao excluir tutor: " + ex.Message);
                }
            }
        }

        // =================================================================
        // 6. OBTER PRÓXIMO ID (Consultando Metadados do MySQL)
        // =================================================================
        public int ProximoId()
        {
            int nextId = 1;

            using (MySqlConnection conect = conexao.GetConnection())
            {
                try
                {
                    conect.Open();
                    string sql = $@"
                        SELECT AUTO_INCREMENT
                        FROM information_schema.TABLES
                        WHERE TABLE_SCHEMA = '{conect.Database}'
                        AND TABLE_NAME = 'Tutor';";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conect))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            nextId = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao obter o próximo ID: " + ex.Message);
                }
            }
            return nextId;
        }
    }
}