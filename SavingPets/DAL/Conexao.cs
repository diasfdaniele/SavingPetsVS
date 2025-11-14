using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SavingPets.DAL
{
    public class Conexao
    {
        private readonly string conStr = @"server=127.0.0.1;uid=root;pwd=ifsp;database=SavingPets";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(conStr);
        }
    }
}

