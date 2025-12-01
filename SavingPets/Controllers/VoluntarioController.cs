using SavingPets.DAL;
using SavingPets.Models;
using System;

namespace SavingPets.Controllers
{
    internal class VoluntarioController
    {
        private BancoDeDadosVoluntario dal;

        public VoluntarioController()
        {
            dal = new BancoDeDadosVoluntario();
        }

        public Voluntario DependenciaVoluntario
        {
            get => default;
            set
            {
            }
        }

        public void Cadastrar(Voluntario voluntario)
        {
            // Validações básicas (igual ao anterior)
            if (string.IsNullOrEmpty(voluntario.Nome))
                throw new Exception("O nome é obrigatório.");
            // ... (Outras validações)

            dal.SalvaDados(voluntario);
        }

        /*public int BuscarProximoId()
        {
            return dal.ObterProximoId();
        }*/
    }
}