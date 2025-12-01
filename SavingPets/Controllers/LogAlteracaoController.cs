using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SavingPets.DAL;
using SavingPets.Models;

namespace SavingPets.Controllers
{
    public class LogAlteracaoController
    {
        private BancoDadosLogAlteracoes logDados = new BancoDadosLogAlteracoes();

        public List<LogAlteracao> Listar()
        {
            return logDados.ListarLogs();
        }
    }
}