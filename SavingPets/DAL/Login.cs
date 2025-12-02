using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms; // Mantido para o uso do 'throw new Exception' com a mensagem de erro

namespace SavingPets.DAL
{
    public class Login
    {
        // Cria a conexão, usando a Classe Conexão
        Conexao Conect = new Conexao();


        // -----------------------------------------------------------------
        // CLASSE ESTÁTICA PARA SESSÃO DE USUÁRIO (SessaoUsuario)
        // -----------------------------------------------------------------
        public static class SessaoUsuario
        {
            public static int IdVoluntarioLogado { get; set; }
            public static bool IsAdministradorLogado { get; set; }
        }

        // -----------------------------------------------------------------
        // MÉTODO PRINCIPAL DE LOGAR
        // -----------------------------------------------------------------
        public bool Logar(string email, string senha)
        {
            // Limpa a sessão no início de qualquer tentativa de login
            SessaoUsuario.IdVoluntarioLogado = 0;
            SessaoUsuario.IsAdministradorLogado = false;

            using (MySqlConnection Con = Conect.GetConnection())
            {
                try
                {
                    Con.Open();

                    // SQL 1: Verifica login por email e senha, e busca o idVoluntario.
                    string ComandoSql = "SELECT V.idVoluntario " +
                                        "FROM Pessoa AS P INNER JOIN Voluntario AS V ON V.idPessoa = P.idPessoa " +
                                        "WHERE P.email=@email AND P.senha=@senha"; // Assumindo que o campo é 'login' ou 'email'

                    MySqlCommand Command = new MySqlCommand(ComandoSql, Con);

                    Command.Parameters.AddWithValue("@email", email);
                    Command.Parameters.AddWithValue("@senha", senha);

                    int idVol = 0;
                    using (MySqlDataReader LeitorDados = Command.ExecuteReader())
                    {
                        if (LeitorDados.Read())
                        {
                            // Login bem-sucedido
                            idVol = Convert.ToInt32(LeitorDados["idVoluntario"]);
                        }
                    } // O LeitorDados é fechado e descartado aqui, liberando a conexão

                    if (idVol > 0)
                    {
                        // 2. Chama o método para verificar o status de administrador
                        bool isAdm = VerificarStatusAdministrador(idVol, Con);

                        // 3. Armazena os dados na sessão
                        SessaoUsuario.IdVoluntarioLogado = idVol;
                        SessaoUsuario.IsAdministradorLogado = isAdm;

                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    // Limpa a sessão em caso de erro no banco de dados
                    SessaoUsuario.IdVoluntarioLogado = 0;
                    SessaoUsuario.IsAdministradorLogado = false;
                    throw new Exception("Erro de autenticação ou de conexão com o Banco de Dados: " + ex.Message);
                }
            } // A conexão é fechada e descartada aqui (via `using`)
        }

        // -----------------------------------------------------------------
        // MÉTODO SEPARADO PARA VERIFICAR ADMIN (Como solicitado)
        // -----------------------------------------------------------------
        /// <summary>
        /// Verifica se o idVoluntario está cadastrado na tabela Administrador.
        /// </summary>
        private bool VerificarStatusAdministrador(int idVoluntario, MySqlConnection con)
        {
            if (idVoluntario <= 0) return false;

            // SQL 2: Verifica se o Voluntário tem um registro de Administrador
            string cmdsql = "SELECT COUNT(codAdministrador) FROM Administrador " +
                            "WHERE idVoluntario = @idVoluntario";

            using (MySqlCommand Command2 = new MySqlCommand(cmdsql, con))
            {
                Command2.Parameters.AddWithValue("@idVoluntario", idVoluntario);

                // ExecuteScalar retorna o primeiro valor da primeira linha, que é a contagem (0 ou 1)
                object resultado = Command2.ExecuteScalar();

                // Se a contagem for maior que 0 (ou seja, existe um registro de administrador)
                if (resultado != null && Convert.ToInt32(resultado) > 0)
                {
                    return true;
                }
                return false;
            }
        }

        // -----------------------------------------------------------------
        // MÉTODO PARA ACESSO EXTERNO (Como solicitado)
        // -----------------------------------------------------------------
        public bool IsAdministrador()
        {
            // Retorna o valor armazenado na sessão.
            return SessaoUsuario.IsAdministradorLogado;
        }
    }
}