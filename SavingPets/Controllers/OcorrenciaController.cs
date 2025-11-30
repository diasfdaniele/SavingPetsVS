using SavingPets.DAL;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static SavingPets.FrmGerenciarOcorrencias;

namespace SavingPets.Controllers
{
    public class OcorrenciaController
    {
        private BancoDadosOcorrencia dal = new BancoDadosOcorrencia();

        private void Validar(Ocorrencia ocorrencia)
        {
            if (ocorrencia == null) throw new ArgumentNullException(nameof(ocorrencia));
            if (ocorrencia.Processo == null && ocorrencia.IdProcessoAdotivo <= 0)
                throw new Exception("ATENÇÃO: É obrigatório selecionar um processo adotivo antes de prosseguir.");
            if (string.IsNullOrWhiteSpace(ocorrencia.Descricao))
                throw new Exception("ATENÇÃO: A descrição do ocorrido é campo de preenchimento obrigatório.");
            var grav = (ocorrencia.Gravidade ?? "").ToLower();
            if (!(grav == "baixa" || grav == "media" || grav == "média" || grav == "alta"))
                throw new Exception("ATENÇÃO: Informe a gravidade da ocorrência (Baixa, Média ou Alta).");
            if (ocorrencia.DataOcorrencia > DateTime.Now)
                throw new Exception("ATENÇÃO: A data informada não pode ser posterior à data de hoje.");
            if (ocorrencia.Processo != null && ocorrencia.DataOcorrencia < ocorrencia.Processo.DataAdocao)
                throw new Exception("ATENÇÃO: A data do ocorrido não pode ser anterior à data de adoção do processo.");
        }

        public void CadastrarOcorrencia(Ocorrencia ocorr)
        {
            Validar(ocorr);

            // garante que IdProcessoAdotivo esteja preenchido (pode vir do Processo selecionado na UI)
            if (ocorr.Processo != null && ocorr.IdProcessoAdotivo <= 0)
                ocorr.IdProcessoAdotivo = ocorr.Processo.IdProcesso;
            ;

            dal.SalvarDados(ocorr);
        }

        // método para buscar ocorrências de um processo (para exibir em grid, por exemplo)
        public List<OcorrenciaView> BuscarPorProcesso(int idProc)
        {
            return dal.BuscarPorProcesso(idProc);
        }

        public List<OcorrenciaView> BuscarPorNomeTutor(string nome)
        {
            return dal.BuscarPorNomeTutor(nome);
        }

        public List<OcorrenciaView> BuscarPorNomeAnimal(string nome)
        {
            return dal.BuscarPorNomeAnimal(nome);
        }

        public List<Ocorrencia> BuscarTodos()
        {
            return dal.BuscarTodos();
        }

        public List<OcorrenciaView> BuscarPorIdProcesso(int id)
        {
            return dal.BuscarPorProcesso(id);
        }

        public OcorrenciaView BuscarPorId(int idOc)
        {
            return dal.BuscarPorId(idOc);
        }
    }
}
