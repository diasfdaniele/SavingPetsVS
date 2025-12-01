using MySql.Data.MySqlClient;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SavingPets.DAL.Login; // Necessário para acessar SessaoUsuario

namespace SavingPets.DAL
{
    public class BancoDeDadosVoluntario
    {
        private Conexao conexao = new Conexao();

        // -----------------------------------------------------------------
        // SALVAR DADOS (INSERIR E ATUALIZAR)
        // -----------------------------------------------------------------
        /// <summary>
        /// Salva (insere ou atualiza) os dados do Voluntário e da Pessoa associada em uma única transação.
        /// </summary>
        public void SalvaDados(Voluntario voluntario)
        {
            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open();
                MySqlTransaction trans = conect.BeginTransaction();

                try
                {
                    // 1) Define a variável de sessão para auditoria
                    int idVoluntarioAtual = SessaoUsuario.IdVoluntarioLogado;
                    if (idVoluntarioAtual > 0)
                    {
                        using (MySqlCommand cmdSessao = new MySqlCommand(
                            $"SET @voluntario_responsavel = {idVoluntarioAtual};", conect, trans))
                        {
                            cmdSessao.ExecuteNonQuery();
                        }
                    }

                    // 2) Inserir ou Atualizar Pessoa
                    if (voluntario.IdPessoa == 0) // Inserir Nova Pessoa
                    {
                        string sqlInsertPessoa = @"
                            INSERT INTO Pessoa (nome, cpf, email, dataNascimento, sexo, dataCadastro, login, senha)
                            VALUES (@nome, @cpf, @email, @dataNascimento, @sexo, NOW(), @login, @senha);
                            SELECT LAST_INSERT_ID();";

                        using (MySqlCommand cmdPessoa = new MySqlCommand(sqlInsertPessoa, conect, trans))
                        {
                            cmdPessoa.Parameters.AddWithValue("@nome", voluntario.Nome);
                            cmdPessoa.Parameters.AddWithValue("@cpf", voluntario.Cpf);
                            cmdPessoa.Parameters.AddWithValue("@email", voluntario.Email);
                            cmdPessoa.Parameters.AddWithValue("@dataNascimento", voluntario.DataNascimento);
                            cmdPessoa.Parameters.AddWithValue("@sexo", voluntario.Sexo);
                            cmdPessoa.Parameters.AddWithValue("@login", voluntario.Login);
                            cmdPessoa.Parameters.AddWithValue("@senha", voluntario.Senha);

                            // Recupera o ID gerado da Pessoa
                            voluntario.IdPessoa = Convert.ToInt32(cmdPessoa.ExecuteScalar());
                        }

                        // 3) Inserir Voluntario (apenas após inserir Pessoa)
                        string sqlInsertVoluntario = @"
                            INSERT INTO Voluntario (idPessoa, dataAdmissao)
                            VALUES (@idPessoa, @dataAdmissao);
                            SELECT LAST_INSERT_ID();";

                        using (MySqlCommand cmdVoluntario = new MySqlCommand(sqlInsertVoluntario, conect, trans))
                        {
                            cmdVoluntario.Parameters.AddWithValue("@idPessoa", voluntario.IdPessoa);
                            //cmdVoluntario.Parameters.AddWithValue("@dataAdmissao", voluntario.DataAdmissao);

                            // Recupera o ID gerado do Voluntario
                            voluntario.IdVoluntario = Convert.ToInt32(cmdVoluntario.ExecuteScalar());
                        }
                    }
                    else // Atualizar Pessoa e Voluntario
                    {
                        // 2) Atualizar Pessoa
                        string sqlUpdatePessoa = @"
                            UPDATE Pessoa SET
                                nome = @nome, cpf = @cpf, email = @email, dataNascimento = @dataNascimento,
                                sexo = @sexo, login = @login, senha = @senha
                            WHERE idPessoa = @idPessoa;";

                        using (MySqlCommand cmdPessoa = new MySqlCommand(sqlUpdatePessoa, conect, trans))
                        {
                            cmdPessoa.Parameters.AddWithValue("@idPessoa", voluntario.IdPessoa);
                            cmdPessoa.Parameters.AddWithValue("@nome", voluntario.Nome);
                            cmdPessoa.Parameters.AddWithValue("@cpf", voluntario.Cpf);
                            cmdPessoa.Parameters.AddWithValue("@email", voluntario.Email);
                            cmdPessoa.Parameters.AddWithValue("@dataNascimento", voluntario.DataNascimento);
                            cmdPessoa.Parameters.AddWithValue("@sexo", voluntario.Sexo);
                            cmdPessoa.Parameters.AddWithValue("@login", voluntario.Login);
                            cmdPessoa.Parameters.AddWithValue("@senha", voluntario.Senha);

                            cmdPessoa.ExecuteNonQuery();
                        }

                        // 3) Atualizar Voluntario
                        if (voluntario.IdVoluntario > 0)
                        {
                            string sqlUpdateVoluntario = @"
                                UPDATE Voluntario SET
                                    dataAdmissao = @dataAdmissao
                                WHERE idVoluntario = @idVoluntario;";

                            using (MySqlCommand cmdVoluntario = new MySqlCommand(sqlUpdateVoluntario, conect, trans))
                            {
                                cmdVoluntario.Parameters.AddWithValue("@idVoluntario", voluntario.IdVoluntario);
                               // cmdVoluntario.Parameters.AddWithValue("@dataAdmissao", voluntario.DataAdmissao);

                                cmdVoluntario.ExecuteNonQuery();
                            }
                        }
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Erro ao salvar dados do voluntário: " + ex.Message);
                }
            }
        }

        // -----------------------------------------------------------------
        // BUSCAR TODOS OS VOLUNTÁRIOS
        // -----------------------------------------------------------------
        /// <summary>
        /// Busca e retorna uma lista de todos os voluntários cadastrados.
        /// </summary>
        public List<Voluntario> BuscaVoluntarios()
        {
            List<Voluntario> lista = new List<Voluntario>();
            string sql = @"
                SELECT 
                    v.idVoluntario, v.dataAdmissao,
                    p.idPessoa, p.nome, p.cpf, p.email, p.dataNascimento, p.sexo, p.dataCadastro, p.login, p.senha
                FROM Voluntario v
                JOIN Pessoa p ON v.idPessoa = p.idPessoa
                ORDER BY p.nome;";

            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conect))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Voluntario voluntario = new Voluntario
                            {
                                IdVoluntario = reader.GetInt32("idVoluntario"),
                                //DataAdmissao = reader.GetDateTime("dataAdmissao"),

                                // Dados da Pessoa
                                IdPessoa = reader.GetInt32("idPessoa"),
                                Nome = reader.GetString("nome"),
                                Cpf = reader.GetString("cpf"),
                                Email = reader.GetString("email"),
                                DataNascimento = reader.GetDateTime("dataNascimento"),
                                Sexo = reader.GetString("sexo"),
                                DataCadastro = reader.GetDateTime("dataCadastro"),
                                Login = reader.GetString("login"),
                                Senha = reader.GetString("senha")
                            };
                            lista.Add(voluntario);
                        }
                    }
                }
            }
            return lista;
        }

        // -----------------------------------------------------------------
        // BUSCAR VOLUNTÁRIO POR ID
        // -----------------------------------------------------------------
        /// <summary>
        /// Busca um voluntário específico pelo seu ID.
        /// </summary>
        public Voluntario BuscaVoluntarioPorId(int idVoluntario)
        {
            Voluntario voluntario = null;
            string sql = @"
                SELECT 
                    v.idVoluntario, v.dataAdmissao,
                    p.idPessoa, p.nome, p.cpf, p.email, p.dataNascimento, p.sexo, p.dataCadastro, p.login, p.senha
                FROM Voluntario v
                JOIN Pessoa p ON v.idPessoa = p.idPessoa
                WHERE v.idVoluntario = @idVoluntario;";

            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conect))
                {
                    cmd.Parameters.AddWithValue("@idVoluntario", idVoluntario);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            voluntario = new Voluntario
                            {
                                IdVoluntario = reader.GetInt32("idVoluntario"),
                                //DataAdmissao = reader.GetDateTime("dataAdmissao"),

                                // Dados da Pessoa
                                IdPessoa = reader.GetInt32("idPessoa"),
                                Nome = reader.GetString("nome"),
                                Cpf = reader.GetString("cpf"),
                                Email = reader.GetString("email"),
                                DataNascimento = reader.GetDateTime("dataNascimento"),
                                Sexo = reader.GetString("sexo"),
                                DataCadastro = reader.GetDateTime("dataCadastro"),
                                Login = reader.GetString("login"),
                                Senha = reader.GetString("senha")
                            };
                        }
                    }
                }
            }
            return voluntario;
        }

        // -----------------------------------------------------------------
        // DELETAR VOLUNTÁRIO
        // -----------------------------------------------------------------
        /// <summary>
        /// Deleta o Voluntário e a Pessoa associada em uma transação.
        /// </summary>
        public void DeletaVoluntario(int idVoluntario)
        {
            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open();
                MySqlTransaction trans = conect.BeginTransaction();

                try
                {
                    // 1) Define a variável de sessão para auditoria
                    int idVoluntarioAtual = SessaoUsuario.IdVoluntarioLogado;
                    if (idVoluntarioAtual > 0)
                    {
                        using (MySqlCommand cmdSessao = new MySqlCommand(
                            $"SET @voluntario_responsavel = {idVoluntarioAtual};", conect, trans))
                        {
                            cmdSessao.ExecuteNonQuery();
                        }
                    }

                    // Passo 1: Obter o idPessoa associado ao idVoluntario
                    int idPessoa = 0;
                    string sqlGetPessoaId = "SELECT idPessoa FROM Voluntario WHERE idVoluntario = @idVoluntario;";
                    using (MySqlCommand cmdGetPessoa = new MySqlCommand(sqlGetPessoaId, conect, trans))
                    {
                        cmdGetPessoa.Parameters.AddWithValue("@idVoluntario", idVoluntario);
                        object result = cmdGetPessoa.ExecuteScalar();
                        if (result != null)
                        {
                            idPessoa = Convert.ToInt32(result);
                        }
                    }

                    if (idPessoa > 0)
                    {
                        // Passo 2: Deletar Voluntario
                        string sqlDeleteVoluntario = "DELETE FROM Voluntario WHERE idVoluntario = @idVoluntario;";
                        using (MySqlCommand cmdVoluntario = new MySqlCommand(sqlDeleteVoluntario, conect, trans))
                        {
                            cmdVoluntario.Parameters.AddWithValue("@idVoluntario", idVoluntario);
                            cmdVoluntario.ExecuteNonQuery();
                        }

                        // Passo 3: Deletar Pessoa
                        string sqlDeletePessoa = "DELETE FROM Pessoa WHERE idPessoa = @idPessoa;";
                        using (MySqlCommand cmdPessoa = new MySqlCommand(sqlDeletePessoa, conect, trans))
                        {
                            cmdPessoa.Parameters.AddWithValue("@idPessoa", idPessoa);
                            cmdPessoa.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        throw new Exception("Voluntário não encontrado ou já deletado.");
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Erro ao deletar voluntário: " + ex.Message);
                }
            }
        }
    }
}