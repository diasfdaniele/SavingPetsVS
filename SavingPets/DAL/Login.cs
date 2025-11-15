using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavingPets.DAL
{
    public class Login
    {
        Conexao conexao = new Conexao();

        public bool Logar(string login, string senha)
        {
            try
            {
                using (MySqlConnection con = conexao.GetConnection())
                {
                    con.Open();

                    string sql = "SELECT * FROM Pessoa INNER JOIN Voluntario ON Voluntario.idPessoa = Pessoa.idPessoa  WHERE email=@email AND senha=@senha ";
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@email", login);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    return dr.HasRows;
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message); ;
            }
        }
    }

}
