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
        //cria a conexão, usando a Classe Conexão
        Conexao Conect = new Conexao();

        public Controllers.LogAlteracaoController LoginPodeGerar
        {
            get => default;
            set
            {
            }
        }

        public bool Logar(string Login, string Senha)
        {
            using (MySqlConnection Con = Conect.GetConnection())
            {
                try
                {
                    Con.Open();

                    string ComandoSql = "SELECT Voluntario.idVoluntario " +
                                        "FROM Pessoa INNER JOIN Voluntario ON Voluntario.idPessoa = Pessoa.idPessoa " +
                                        "WHERE email=@email AND senha=@senha";

                    MySqlCommand Command = new MySqlCommand(ComandoSql, Con);

                    Command.Parameters.AddWithValue("@email", Login);
                    Command.Parameters.AddWithValue("@senha", Senha);

                    MySqlDataReader LeitorDados = Command.ExecuteReader();

                    if (LeitorDados.Read())
                    {
                        int idVol = Convert.ToInt32(LeitorDados["idVoluntario"]);

                        SessaoUsuario.IdVoluntarioLogado = idVol;

                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro: " + ex.Message);
                }
                finally
                {
                    Con.Close();
                }
            }
        }

        public static class SessaoUsuario
        {
            public static int IdVoluntarioLogado { get; set; }
        }
    }
}
