using MySql.Data.MySqlClient;
using Mysqlx.Prepare;
using Org.BouncyCastle.Crypto;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingPets.DAL
{
    public class BancoDadosAnimal
    {
        private Conexao conexao = new Conexao();

        //Pega todos os dados de um animal e guarda num objeto
        public Animal ExtrairDados(int id)
        {
            Animal Animal = new Animal();

            using (MySqlConnection conect = conexao.GetConnection())
            {
                try
                {
                    conect.Open();
                    string sql = @"SELECT * FROM Animal WHERE idAnimal = @id";

                    MySqlCommand Command = new MySqlCommand(sql, conect);

                    Command.Parameters.AddWithValue("@id", id);

                    MySqlDataReader LeitorDados = Command.ExecuteReader();



                    while (LeitorDados.Read())
                    {

                        Animal.IdAnimal = LeitorDados.GetInt32("idAnimal");
                        Animal.NomeAnimal = LeitorDados.GetString("nome");
                        Animal.Especie = LeitorDados.GetString("especie");
                        Animal.Raca = LeitorDados.GetString("raca");
                        Animal.SexoAnimal = LeitorDados.GetString("sexo");
                        Animal.Castrado = LeitorDados.GetBoolean("castrado");
                    }

                    return Animal;

                }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }
        }

        public void SalvaDados(Animal animal)
        {
            using (MySqlConnection conect = conexao.GetConnection())
            {
                try
                {
                    conect.Open();

                    string sql = @"INSERT INTO Animal (nome, sexo, raca, castrado, especie,idTutor) VALUES (@nome, @sexo, @raca, @castrado, @especie, @idTutor)";

                    MySqlCommand Command = new MySqlCommand(sql, conect);

                    Command.Parameters.AddWithValue("@nome", animal.NomeAnimal);
                    Command.Parameters.AddWithValue("@sexo", animal.SexoAnimal);
                    Command.Parameters.AddWithValue("@raca", animal.Raca);
                    Command.Parameters.AddWithValue("@castrado", animal.Castrado);
                    Command.Parameters.AddWithValue("@especie", animal.Especie);
                    Command.Parameters.AddWithValue("@idTutor", 1);

                    Command.ExecuteNonQuery();


                }
                catch
                {

                }
                finally
                {
                    conect.Close();
                }
            }
        }

        public List<int> ListarIds()
        {
            List<int> Ids = new List<int>();

            try
            {
                using (MySqlConnection Conect = conexao.GetConnection())
                {
                    Conect.Open();

                    String ComandoSql = @"SELECT idAnimal FROM Animal";

                    MySqlCommand Comando = new MySqlCommand(ComandoSql, Conect);
                    MySqlDataReader LeitorDados = Comando.ExecuteReader();

                    while (LeitorDados.Read())
                    {
                        Ids.Add(LeitorDados.GetInt32("idAnimal"));
                    }

                }

                return Ids;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao consultar IDs no banco: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao listar IDs: " + ex.Message);
            }
        }

        public Boolean ExcluirDados(int id)
        {

            using (MySqlConnection Conect = conexao.GetConnection())
            {
                try
                {

                    Conect.Open();

                    string ComandoSql = @"DELETE FROM Animal WHERE idAnimal = @id";

                    MySqlCommand Comando = new MySqlCommand(ComandoSql, Conect);
                    Comando.Parameters.AddWithValue("@id", id);

                    int Linhas = Comando.ExecuteNonQuery();//Linhas recebe a quantidade de linhas afetadas


                    //Se retornar 0, é porque nenhuma linha foi afetada (Não existia esse tutor)
                    return Linhas > 0;//Se for mairo do que 0 retorna true se não, falso
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Erro ao excluir animal: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro inesperado: " + ex.Message);
                }
            }
        }

        public bool AlterarDados(Animal animal)
        {
            using (MySqlConnection Conect = conexao.GetConnection())
            {
                try
                {
                    Conect.Open();

                    string ComandoSql = @"UPDATE Animal 
                           SET nome = @nome,
                               sexo = @sexo,
                               raca = @raca,
                               castrado = @castrado,
                               especie = @especie
                           WHERE idAnimal = @id";

                    MySqlCommand Comando = new MySqlCommand(ComandoSql, Conect);

                    Comando.Parameters.AddWithValue("@nome", animal.NomeAnimal);
                    Comando.Parameters.AddWithValue("@sexo", animal.SexoAnimal);
                    Comando.Parameters.AddWithValue("@raca", animal.Raca);
                    Comando.Parameters.AddWithValue("@castrado", animal.Castrado);
                    Comando.Parameters.AddWithValue("@especie", animal.Especie);
                    Comando.Parameters.AddWithValue("@id", animal.IdAnimal);

                    int linhas = Comando.ExecuteNonQuery();

                    return linhas > 0; // true = atualizado, false = id não existe
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Erro no banco ao alterar animal: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro inesperado ao alterar: " + ex.Message);
                }
            }
        }

        public int ExtrairMaiorId()
        {
            int id = 0;

            try
            {
                using (MySqlConnection Conect = conexao.GetConnection())
                {
                    Conect.Open();

                    String ComandoSql = @"SELECT MAX(idAnimal) FROM Animal";

                    MySqlCommand Comando = new MySqlCommand(ComandoSql, Conect);
                    MySqlDataReader LeitorDados = Comando.ExecuteReader();

                    if (LeitorDados.Read() && !LeitorDados.IsDBNull(0))
                    {
                        id = LeitorDados.GetInt32("maiorId");
                    }

                }

                return id;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao consultar IDs no banco: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao extrair ID: " + ex.Message);
            }
        }


    }
}
