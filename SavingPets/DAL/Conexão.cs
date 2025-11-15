using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingPets.DAL
{
    public class Conexao
    {
        //Cria a conexão com o Banco de Dados
        //Não esqueça de colocar as informações certas na string
        private readonly string ConStr = @"server=127.0.0.1;uid=root;pwd=;database=SavingPets";

        public MySqlConnection GetConnection()
        {
            //Retorna a conexão estabelecida
            return new MySqlConnection(ConStr);

        }
    }
}
