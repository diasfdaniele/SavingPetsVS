using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingPets.DAL
{
    public class Login
    {
        //cria a conexão, usando a Classe Conexão
        Conexao Conect = new Conexao();

        public bool Logar(string Login, string Senha)
        {
            
                using (MySqlConnection Con = Conect.GetConnection()) //tenta se conectar com o banco
                {
                try
                {
                    Con.Open(); //Abre a conexão

                    string ComandoSql = "SELECT * FROM Pessoa INNER JOIN Voluntario ON Voluntario.idPessoa = Pessoa.idPessoa  WHERE email=@email AND senha=@senha ";//Seleciona os voluntários cadastrados
                    MySqlCommand Command = new MySqlCommand(ComandoSql, Con);

                    Command.Parameters.AddWithValue("@email", Login);
                    Command.Parameters.AddWithValue("@senha", Senha);

                    MySqlDataReader LeitorDados = Command.ExecuteReader();

                    return LeitorDados.HasRows; //retorna a quantidade de linhas encontradas
                                                //como o Email é único, sempre retorna 1
                }
                catch (Exception ex)
                {
                    //lança a exceção para a classe que o chamou
                    throw new Exception("Erro: " + ex.Message); ;
                }
                finally
                {
                    Con.Close();
                }
            }

           
        }
    }
}
