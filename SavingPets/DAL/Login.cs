using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingPets.DAL
{
    public class LoginDAL
    {
        Conexao conexao = new Conexao();

        public bool Logar(string login, string senha)
        {
            try
            {
                using (MySqlConnection con = conexao.GetConnection())
                {
                    con.Open();

                    string sql = "SELECT * FROM Pessoa WHERE login=@login AND senha=@senha";
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    return dr.HasRows;
                }
            }
            
            catch (Exception ex)
            {

            }
        }
    }

}
