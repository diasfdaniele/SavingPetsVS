using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingPets.Controllers
{
    public class VisitaController
    {
        // Lista simulada (substituída pelo banco futuramente)
        private static List<Visita> listaVisitas = new List<Visita>();

        // Controle de ID automático
        private static int ultimoId = 0;

        // -----------------------------
        // MÉTODO DE VALIDAÇÃO
        // -----------------------------
        private void Validar(Visita visita)
        {
            if (visita == null)
                throw new ArgumentNullException("visita", "A visita informada é nula.");

            if (visita.Processo == null)
                throw new Exception("ATENÇÃO: É obrigatório selecionar um processo adotivo antes de registrar a visita.");

            // Data da visita não pode ser futura
            if (visita.DataVisita > DateTime.Now)
                throw new Exception("ATENÇÃO: A data da visita não pode ser posterior à data de hoje.");

            // Não pode ser antes da adoção
            if (visita.DataVisita < visita.Processo.DataAdocao)
                throw new Exception("ATENÇÃO: A data da visita não pode ser anterior à data de adoção do processo.");

            // Responsável é obrigatório
            if (string.IsNullOrWhiteSpace(visita.Responsavel))
                throw new Exception("ATENÇÃO: O nome do responsável pela visita é obrigatório.");

            // Status é obrigatório
            if (string.IsNullOrWhiteSpace(visita.Status))
                throw new Exception("ATENÇÃO: É necessário informar o status da visita.");

            // Condição do ambiente obrigatória
            if (string.IsNullOrWhiteSpace(visita.CondicaoAmbiente))
                throw new Exception("ATENÇÃO: Informe a condição do ambiente (Seguro, Adequado ou Inseguro).");

            // Maus-tratos obrigatório
            if (string.IsNullOrWhiteSpace(visita.MausTratos))
                throw new Exception("ATENÇÃO: Informe se há indícios de maus-tratos.");

            // Campos críticos do bem-estar (pode ajustar sua regra)
            if (string.IsNullOrWhiteSpace(visita.CondicaoFisica))
                throw new Exception("ATENÇÃO: Informe a condição física do animal.");

            if (string.IsNullOrWhiteSpace(visita.Comportamento))
                throw new Exception("ATENÇÃO: Informe o comportamento do animal.");
        }

        // -----------------------------
        // CADASTRAR
        // -----------------------------
        public void CadastrarVisita(Visita visita)
        {
            Validar(visita);

            ultimoId++;
            visita.IdVisita = ultimoId;

            listaVisitas.Add(visita);
        }

        // -----------------------------
        // LISTAR
        // -----------------------------
        public List<Visita> ListarVisitas()
        {
            return listaVisitas;
        }

        // -----------------------------
        // BUSCA POR FILTRO
        // -----------------------------
        public List<Visita> BuscarVisitas(string termo, string tipoFiltro)
        {
            termo = termo?.ToLower() ?? "";
            List<Visita> resultados = new List<Visita>();

            foreach (var v in listaVisitas)
            {
                if (tipoFiltro == "NomeTutor" &&
                    v.Processo.NomeTutor.ToLower().Contains(termo))
                    resultados.Add(v);

                else if (tipoFiltro == "NomeAnimal" &&
                    v.Processo.NomeAnimal.ToLower().Contains(termo))
                    resultados.Add(v);

                else if (tipoFiltro == "IdProcesso" &&
                    v.Processo.IdProcesso.ToString() == termo)
                    resultados.Add(v);

                else if (tipoFiltro == "IdVisita" &&
                    v.IdVisita.ToString() == termo)
                    resultados.Add(v);
            }

            return resultados;
        }
    }
}
