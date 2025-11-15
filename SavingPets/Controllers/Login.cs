using MySql.Data.MySqlClient;
using SavingPets.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingPets.Controllers
{
    public class Login
    {
        //cria a conexão, usando a Classe Conexão
        Conexao conexao = new Conexao();

        public bool Logar(string login, string senha)
        {
            try
            {
                using (MySqlConnection con = conexao.GetConnection()) //tenta se conectar com o banco
                {
                    con.Open(); //Abre a conexão

                    string sql = "SELECT * FROM Pessoa INNER JOIN Voluntario ON Voluntario.idPessoa = Pessoa.idPessoa  WHERE email=@email AND senha=@senha ";//Seleciona os voluntários cadastrados
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@email", login);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    return dr.HasRows; //retorna a quantidade de linhas encontradas
                                       //como o Email é único, sempre retorna 1
                }
            }

            catch (Exception ex)
            {
                //lança a exceção para a classe que o chamou
                throw new Exception("Erro: " + ex.Message); ;
            }
        }
    }
}
