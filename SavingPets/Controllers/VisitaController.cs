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
        // Lista temporária que simula o banco de dados
        // (BANCO) — será substituída por SELECT no repositório
        private static List<Visita> listaVisitas = new List<Visita>();

        // Controle de ID incremental automático
        // (BANCO) — será substituído por ID AUTO_INCREMENT do MySQL
        private static int ultimoId = 0;

        // MÉTODO DE VALIDAÇÃO
        private void Validar(Visita visita)
        {
            // Verifica se o objeto é nulo
            if (visita == null)
                throw new ArgumentNullException("visita", "A visita informada é nula.");

            // Verifica se o processo adotivo foi informado
            if (visita.Processo == null)
                throw new Exception("ATENÇÃO: É obrigatório selecionar um processo adotivo antes de registrar a visita.");

            // Data da visita não pode ser futura
            if (visita.DataVisita > DateTime.Now)
                throw new Exception("ATENÇÃO: A data da visita não pode ser posterior à data de hoje.");

            // Data da visita não pode ser antes da adoção
            if (visita.DataVisita < visita.Processo.DataAdocao)
                throw new Exception("ATENÇÃO: A data da visita não pode ser anterior à data de adoção do processo.");

            // Campos obrigatórios
            if (string.IsNullOrWhiteSpace(visita.Responsavel))
                throw new Exception("ATENÇÃO: O nome do responsável pela visita é obrigatório.");

            if (string.IsNullOrWhiteSpace(visita.Status))
                throw new Exception("ATENÇÃO: É necessário informar o status da visita.");

            if (string.IsNullOrWhiteSpace(visita.CondicaoAmbiente))
                throw new Exception("ATENÇÃO: Informe a condição do ambiente (Seguro, Adequado ou Inseguro).");

            if (string.IsNullOrWhiteSpace(visita.MausTratos))
                throw new Exception("ATENÇÃO: Informe se há indícios de maus-tratos.");

            if (string.IsNullOrWhiteSpace(visita.CondicaoFisica))
                throw new Exception("ATENÇÃO: Informe a condição física do animal.");

            if (string.IsNullOrWhiteSpace(visita.Comportamento))
                throw new Exception("ATENÇÃO: Informe o comportamento do animal.");
        }


        // CADASTRAR
        public void CadastrarVisita(Visita visita)
        {
            // Valida antes de inserir
            Validar(visita);

            // Gera ID manualmente
            // (BANCO) — esse ID será gerado pelo banco futuramente
            ultimoId++;
            visita.IdVisita = ultimoId;

            // Adiciona na lista simulada
            // (BANCO) — será substituído por INSERT no banco
            listaVisitas.Add(visita);
        }

        // LISTAR
        public List<Visita> ListarVisitas()
        {
            // Apenas retorna a lista simulada
            // (BANCO) — será substituído por SELECT * FROM Visitas
            return listaVisitas;
        }

        // BUSCA POR FILTRO
        public List<Visita> BuscarVisitas(string termo, string tipoFiltro)
        {
            termo = termo?.ToLower() ?? "";
            List<Visita> resultados = new List<Visita>();

            // (BANCO) — toda essa busca será substituída por SELECT com WHERE dinâmico
            foreach (var v in listaVisitas)
            {
                if (tipoFiltro == "NomeTutor" &&
                    v.Processo.Tutor.NomeTutor.ToLower().Contains(termo))
                    resultados.Add(v);

                else if (tipoFiltro == "NomeAnimal" &&
                    v.Processo.Animal.NomeAnimal.ToLower().Contains(termo))
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

        // Buscar visita por ID
        // (BANCO) — será substituído por SELECT WHERE IdVisita = x
        public Visita BuscarPorId(int idVisita)
        {
            return listaVisitas.FirstOrDefault(v => v.IdVisita == idVisita);
        }

        // Editar visita
        public void EditarVisita(Visita visitaAtualizada)
        {
            if (visitaAtualizada == null)
                throw new ArgumentNullException(nameof(visitaAtualizada));

            // Procura visita existente
            // (BANCO) — será SELECT + UPDATE
            var existente = listaVisitas.FirstOrDefault(v => v.IdVisita == visitaAtualizada.IdVisita);
            if (existente == null)
                throw new Exception("Visita não encontrada para edição.");

            // Valida antes de atualizar
            Validar(visitaAtualizada);

            // Remove o item antigo e insere atualizado
            // (BANCO) — será um comando UPDATE
            listaVisitas.Remove(existente);
            listaVisitas.Add(visitaAtualizada);
        }

        // Excluir visita
        public void ExcluirVisita(int idVisita)
        {
            // Procura visita existente
            // (BANCO) — será DELETE FROM Visitas WHERE IdVisita = x
            var existente = listaVisitas.FirstOrDefault(v => v.IdVisita == idVisita);
            if (existente == null)
                throw new Exception("Visita não encontrada para exclusão.");

            // Remove da lista simulada
            // (BANCO) — será substituído por DELETE
            listaVisitas.Remove(existente);
        }
    }
}
