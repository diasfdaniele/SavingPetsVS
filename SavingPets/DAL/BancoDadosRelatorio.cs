using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SavingPets.DAL
{
    public class BancoDadosRelatorio
    {
        private Conexao conexao = new Conexao();

        // =============================================================
        // 1. CONSULTA PADRÃO (Baseada nas Queries 5.1 a 5.5 do PDF)
        // =============================================================
        public DataTable GetRelatorioPadrao(int tipoRelatorio, DateTime inicio, DateTime fim)
        {
            DataTable dt = new DataTable();
            string sql = "";

            // O switch baseia-se na ordem dos itens do ComboBox
            switch (tipoRelatorio)
            {
                case 0: // Quantidade de animais por espécie
                    sql = @"SELECT especie, COUNT(*) as Quantidade 
                            FROM Animal 
                            GROUP BY especie";
                    break;

                case 1: // Ocorrências por gravidade (Query 5.3 Adaptada)
                    sql = @"SELECT O.tipoOcorrencia, A.nome AS NomeAnimal, COUNT(O.idOcorrencia) AS Qtd
                            FROM Ocorrencia O
                            JOIN ProcessoAdotivo PA ON PA.idProcessoAdotivo = O.idProcessoAdotivo
                            JOIN Animal A ON A.idAnimal = PA.idAnimal
                            WHERE O.dataOcorrencia BETWEEN @inicio AND @fim
                            GROUP BY O.tipoOcorrencia, A.nome";
                    break;

                case 2: // Total de visitas por voluntário (Query 5.2)
                    sql = @"SELECT P.nome AS Voluntario, COUNT(V.idVisita) AS TotalVisitas
                            FROM Voluntario Vo
                            JOIN Pessoa P ON P.idPessoa = Vo.idPessoa
                            JOIN Visita V ON V.idVoluntario = Vo.idVoluntario
                            WHERE V.dataRealizada BETWEEN @inicio AND @fim
                            GROUP BY P.nome";
                    break;

                case 3: // Relatório geral de visita por animal (Query 5.5)
                    sql = @"SELECT P.nome AS Voluntario, A.nome AS Animal, V.dataRealizada, OV.condicao_fisica
                            FROM Visita V
                            JOIN Voluntario Vo ON Vo.idVoluntario = V.idVoluntario
                            JOIN Pessoa P ON P.idPessoa = Vo.idPessoa
                            JOIN ObservacoesVisita OV ON OV.idVisita = V.idVisita
                            JOIN ProcessoAdotivo PA ON PA.idProcessoAdotivo = V.idProcessoAdotivo
                            JOIN Animal A ON A.idAnimal = PA.idAnimal
                            WHERE V.dataRealizada BETWEEN @inicio AND @fim
                            ORDER BY V.dataRealizada DESC";
                    break;

                case 4: // Status de visitas
                    sql = @"SELECT realizada AS Status, COUNT(*) AS Quantidade
                            FROM Visita
                            WHERE dataRealizada BETWEEN @inicio AND @fim
                            GROUP BY realizada";
                    break;

                default:
                    return dt;
            }

            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conect))
                {
                    // Adiciona parâmetros de data se a query usar
                    if (sql.Contains("@inicio"))
                    {
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fim", fim);
                    }

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // =============================================================
        // 2. CONSULTA PERSONALIZADA (Foco em Animal/Tutor)
        // =============================================================
        public DataTable GetRelatorioPersonalizado(bool especie, bool vacina, bool castracao, string ordenarPor)
        {
            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();

            sql.Append(@"SELECT A.idAnimal, A.nome, A.especie, A.raca, A.sexo, 
                                A.castrado, A.vermifugado, 
                                (SELECT GROUP_CONCAT(nome) FROM Vacina V WHERE V.idAnimal = A.idAnimal) as Vacinas
                         FROM Animal A 
                         WHERE 1=1 ");

            // Aplica filtros dinâmicos
            // Nota: Como são checkboxes booleanos sem valor específico inputado, 
            // assumimos que se marcado, o usuário quer filtrar quem TEM aquela característica positiva.

            if (castracao)
                sql.Append(" AND A.castrado = 'Sim' ");

            // Filtro de espécie genérico (Ex: se marcado, agrupa ou traz todos, mantive simples pois não há combo de seleção)
            if (especie)
                sql.Append(" AND A.especie IS NOT NULL ");

            if (vacina)
                sql.Append(" AND EXISTS (SELECT 1 FROM Vacina V WHERE V.idAnimal = A.idAnimal) ");

            // Ordenação
            if (!string.IsNullOrEmpty(ordenarPor))
            {
                if (ordenarPor == "Nome")
                    sql.Append(" ORDER BY A.nome ASC");
                else if (ordenarPor == "Data")
                    sql.Append(" ORDER BY A.idAnimal DESC"); // Simulação de data cadastro via ID
            }

            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(sql.ToString(), conect))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // =============================================================
        // 3. CONSULTA DE PROCESSOS E OCORRÊNCIAS
        // =============================================================
        public DataTable GetRelatorioProcessos(string termo, bool fisico, bool adaptacao, bool statusVisita,
                                               bool mausTratos, bool visitasAgendadas,
                                               bool comProcesso, bool comOcorrencia,
                                               string gravidadeOcorrencia)
        {
            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();

            // Query base juntando Processo, Tutor, Animal e Ocorrências
            sql.Append(@"SELECT PA.idProcessoAdotivo, 
                                T.idTutor, P.nome as NomeTutor, 
                                A.nome as NomeAnimal, 
                                PA.dataAdocao,
                                O.tipoOcorrencia, O.descricao as DescricaoOcorrencia,
                                OV.condicao_fisica, OV.adaptacao
                         FROM ProcessoAdotivo PA
                         INNER JOIN Tutor T ON PA.idTutor = T.idTutor
                         INNER JOIN Pessoa P ON T.idPessoa = P.idPessoa
                         INNER JOIN Animal A ON PA.idAnimal = A.idAnimal
                         LEFT JOIN Ocorrencia O ON PA.idProcessoAdotivo = O.idProcessoAdotivo
                         LEFT JOIN Visita V ON PA.idProcessoAdotivo = V.idProcessoAdotivo
                         LEFT JOIN ObservacoesVisita OV ON V.idVisita = OV.idVisita
                         WHERE 1=1 ");

            // Filtro de Texto (Nome do Tutor ou Animal)
            if (!string.IsNullOrEmpty(termo))
            {
                sql.Append($" AND (P.nome LIKE '%{termo}%' OR A.nome LIKE '%{termo}%') ");
            }

            // Filtros Checkbox
            if (fisico)
                sql.Append(" AND OV.condicao_fisica IS NOT NULL "); // Traz apenas quem tem avaliação física registrada

            if (adaptacao)
                sql.Append(" AND OV.adaptacao = 'Não' "); // Exemplo: Filtrar quem não se adaptou

            if (mausTratos)
                sql.Append(" AND OV.indicio_maustratos = 'Sim' ");

            if (visitasAgendadas)
                sql.Append(" AND V.realizada = 'Reagendada' ");

            if (comOcorrencia)
                sql.Append(" AND O.idOcorrencia IS NOT NULL ");

            // Filtro de Gravidade (Radio Buttons)
            if (!string.IsNullOrEmpty(gravidadeOcorrencia) && gravidadeOcorrencia != "Todas")
            {
                sql.Append($" AND O.tipoOcorrencia = '{gravidadeOcorrencia}' ");
            }

            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(sql.ToString(), conect))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}