using SavingPets.DAL;
using System;
using System.Data;

namespace SavingPets.Controllers
{
    public class RelatorioController
    {
        private BancoDadosRelatorio dal = new BancoDadosRelatorio();

        public DataTable ConsultarPadrao(int tipoIndex, DateTime inicio, DateTime fim)
        {
            if (tipoIndex < 0) throw new Exception("Selecione um tipo de relatório.");
            return dal.GetRelatorioPadrao(tipoIndex, inicio, fim);
        }

        public DataTable ConsultarPersonalizado(bool especie, bool vacina, bool castracao, string ordenar)
        {
            return dal.GetRelatorioPersonalizado(especie, vacina, castracao, ordenar);
        }

        public DataTable ConsultarProcessos(string termo, bool fisico, bool adaptacao, bool status,
                                            bool mausTratos, bool visitas, bool comProcesso,
                                            bool comOcorrencia, string gravidade)
        {
            return dal.GetRelatorioProcessos(termo, fisico, adaptacao, status, mausTratos, visitas, comProcesso, comOcorrencia, gravidade);
        }
    }
}
