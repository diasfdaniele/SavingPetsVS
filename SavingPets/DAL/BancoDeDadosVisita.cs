using MySql.Data.MySqlClient;
using SavingPets.Models;
using System;
using System.Collections.Generic;

namespace SavingPets.DAL
{
    public class BancoDadosVisita
    {
        private readonly Conexao conexao = new Conexao();

        // CADASTRO DE VISITAS, INSERE NA TABELA VISITA E OBSERVACOESVISITA
        public bool InserirVisitaCompleta(Visita visita)
        {
            using (MySqlConnection conn = conexao.GetConnection())
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 1) Inserir na tabela Visita
                    string sqlVisita = @"
                        INSERT INTO Visita
                          (idProcessoAdotivo, idVoluntario, dataRealizada, realizada, agendamento, conclusao, orientacoes)
                        VALUES
                          (@idProcessoAdotivo, @idVoluntario, @dataRealizada, @realizada, @agendamento, @conclusao, @orientacoes);
                        SELECT LAST_INSERT_ID();
                    ";

                    using (MySqlCommand cmdVisita = new MySqlCommand(sqlVisita, conn, trans))
                    {
                        cmdVisita.Parameters.AddWithValue("@idProcessoAdotivo", visita.IdProcessoAdotivo);
                        cmdVisita.Parameters.AddWithValue("@idVoluntario", visita.IdVoluntario);
                        cmdVisita.Parameters.AddWithValue("@dataRealizada", visita.DataVisita);
                        cmdVisita.Parameters.AddWithValue("@realizada", string.IsNullOrWhiteSpace(visita.Situacao) ? (object)DBNull.Value : visita.Situacao);
                        cmdVisita.Parameters.AddWithValue("@agendamento", visita.DataAgendada == default ? (object)DBNull.Value : visita.DataAgendada);
                        cmdVisita.Parameters.AddWithValue("@conclusao", string.IsNullOrWhiteSpace(visita.Conclusao) ? (object)DBNull.Value : visita.Conclusao);
                        cmdVisita.Parameters.AddWithValue("@orientacoes", string.IsNullOrWhiteSpace(visita.Orientacoes) ? (object)DBNull.Value : visita.Orientacoes);

                        object scalar = cmdVisita.ExecuteScalar();
                        int idVisitaGerado = Convert.ToInt32(scalar);
                        visita.IdVisita = idVisitaGerado;
                    }

                    // 2) Inserir ObservacoesVisita 
                    if (visita.ObservacoesDetalhadas != null)
                    {
                        // concatena lista simples de observacoes para o campo observacoes
                        string observacoesConcatenadas = null;
                        if (visita.Observacoes != null && visita.Observacoes.Count > 0)
                        {
                            observacoesConcatenadas = string.Join(" | ", visita.Observacoes);
                        }
                        // usa o objeto ObservacoesDetalhadas e garante que IdVisita esteja preenchido
                        visita.ObservacoesDetalhadas.IdVisita = visita.IdVisita;
                        visita.ObservacoesDetalhadas.ObservacoesLivres =
                            string.IsNullOrWhiteSpace(visita.ObservacoesDetalhadas.ObservacoesLivres)
                            ? observacoesConcatenadas
                            : (string.IsNullOrWhiteSpace(observacoesConcatenadas) ? visita.ObservacoesDetalhadas.ObservacoesLivres
                                : visita.ObservacoesDetalhadas.ObservacoesLivres + " | " + observacoesConcatenadas);

                        string sqlObs = @"
                            INSERT INTO ObservacoesVisita
                              (idVisita, condicao_fisica, comportamento, aparencia_saudavel,
                               condicoes_higiene, vacinado, acompanhamento, condicoes_ambiente,
                               indicio_maustratos, adaptacao, relacao_tutor, alteracoes, observacoes)
                            VALUES
                              (@idVisita, @condicao_fisica, @comportamento, @aparencia_saudavel,
                               @condicoes_higiene, @vacinado, @acompanhamento, @condicoes_ambiente,
                               @indicio_maustratos, @adaptacao, @relacao_tutor, @alteracoes, @observacoes);
                        ";

                        using (MySqlCommand cmdObs = new MySqlCommand(sqlObs, conn, trans))
                        {
                            cmdObs.Parameters.AddWithValue("@idVisita", visita.ObservacoesDetalhadas.IdVisita);
                            cmdObs.Parameters.AddWithValue("@condicao_fisica", string.IsNullOrWhiteSpace(visita.ObservacoesDetalhadas.CondicaoFisica) ? (object)DBNull.Value : visita.ObservacoesDetalhadas.CondicaoFisica);
                            cmdObs.Parameters.AddWithValue("@comportamento", string.IsNullOrWhiteSpace(visita.ObservacoesDetalhadas.Comportamento) ? (object)DBNull.Value : visita.ObservacoesDetalhadas.Comportamento);
                            cmdObs.Parameters.AddWithValue("@aparencia_saudavel", string.IsNullOrWhiteSpace(visita.ObservacoesDetalhadas.AparenciaSaudavel) ? (object)DBNull.Value : visita.ObservacoesDetalhadas.AparenciaSaudavel);
                            cmdObs.Parameters.AddWithValue("@condicoes_higiene", string.IsNullOrWhiteSpace(visita.ObservacoesDetalhadas.CondicoesHigiene) ? (object)DBNull.Value : visita.ObservacoesDetalhadas.CondicoesHigiene);
                            cmdObs.Parameters.AddWithValue("@vacinado", string.IsNullOrWhiteSpace(visita.ObservacoesDetalhadas.Vacinado) ? (object)DBNull.Value : visita.ObservacoesDetalhadas.Vacinado);
                            cmdObs.Parameters.AddWithValue("@acompanhamento", string.IsNullOrWhiteSpace(visita.ObservacoesDetalhadas.Acompanhamento) ? (object)DBNull.Value : visita.ObservacoesDetalhadas.Acompanhamento);
                            cmdObs.Parameters.AddWithValue("@condicoes_ambiente", string.IsNullOrWhiteSpace(visita.ObservacoesDetalhadas.CondicoesAmbiente) ? (object)DBNull.Value : visita.ObservacoesDetalhadas.CondicoesAmbiente);
                            cmdObs.Parameters.AddWithValue("@indicio_maustratos", string.IsNullOrWhiteSpace(visita.ObservacoesDetalhadas.IndicioMaustratos) ? (object)DBNull.Value : visita.ObservacoesDetalhadas.IndicioMaustratos);
                            cmdObs.Parameters.AddWithValue("@adaptacao", string.IsNullOrWhiteSpace(visita.ObservacoesDetalhadas.Adaptacao) ? (object)DBNull.Value : visita.ObservacoesDetalhadas.Adaptacao);
                            cmdObs.Parameters.AddWithValue("@relacao_tutor", string.IsNullOrWhiteSpace(visita.ObservacoesDetalhadas.RelacaoTutor) ? (object)DBNull.Value : visita.ObservacoesDetalhadas.RelacaoTutor);
                            cmdObs.Parameters.AddWithValue("@alteracoes", string.IsNullOrWhiteSpace(visita.ObservacoesDetalhadas.Alteracoes) ? (object)DBNull.Value : visita.ObservacoesDetalhadas.Alteracoes);
                            cmdObs.Parameters.AddWithValue("@observacoes", string.IsNullOrWhiteSpace(visita.ObservacoesDetalhadas.ObservacoesLivres) ? (object)DBNull.Value : visita.ObservacoesDetalhadas.ObservacoesLivres);

                            cmdObs.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Se não houve ObservacoesDetalhadas, mas há lista simples, grava uma linha mínima apenas com 'observacoes'
                        if (visita.Observacoes != null && visita.Observacoes.Count > 0)
                        {
                            string observacoesConc = string.Join(" | ", visita.Observacoes);
                            string sqlObsMinimal = @"
                                INSERT INTO ObservacoesVisita (idVisita, observacoes)
                                VALUES (@idVisita, @observacoes);
                            ";
                            using (MySqlCommand cmdObsMin = new MySqlCommand(sqlObsMinimal, conn, trans))
                            {
                                cmdObsMin.Parameters.AddWithValue("@idVisita", visita.IdVisita);
                                cmdObsMin.Parameters.AddWithValue("@observacoes", observacoesConc);
                                cmdObsMin.ExecuteNonQuery();
                            }
                        }
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception)
                {
                    try { trans.Rollback(); } catch { }
                    return false;
                }
            }
        }

        // LISTAR TODAS AS VISITAS (traz observacoes se existirem)
        public List<Visita> ListarVisitas()
        {
            List<Visita> lista = new List<Visita>();

            using (MySqlConnection conn = conexao.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        v.idVisita,
                        v.idProcessoAdotivo,
                        v.idVoluntario,
                        v.dataRealizada,
                        v.realizada,
                        v.agendamento,
                        v.conclusao,
                        v.orientacoes,
                        ov.idObservacoesVisita,
                        ov.condicao_fisica,
                        ov.comportamento,
                        ov.aparencia_saudavel,
                        ov.condicoes_higiene,
                        ov.vacinado,
                        ov.acompanhamento,
                        ov.condicoes_ambiente,
                        ov.indicio_maustratos,
                        ov.adaptacao,
                        ov.relacao_tutor,
                        ov.alteracoes,
                        ov.observacoes AS observacoes_livres
                    FROM Visita v
                    LEFT JOIN ObservacoesVisita ov ON ov.idVisita = v.idVisita
                    ORDER BY v.idVisita DESC;
                ";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Visita visita = new Visita
                        {
                            IdVisita = dr.GetInt32("idVisita"),
                            IdProcessoAdotivo = dr.GetInt32("idProcessoAdotivo"),
                            IdVoluntario = dr.IsDBNull(dr.GetOrdinal("idVoluntario")) ? 0 : dr.GetInt32("idVoluntario"),
                            DataVisita = dr.IsDBNull(dr.GetOrdinal("dataRealizada")) ? DateTime.MinValue : dr.GetDateTime("dataRealizada"),
                            Situacao = dr.IsDBNull(dr.GetOrdinal("realizada")) ? "" : dr.GetString("realizada"),
                            DataAgendada = dr.IsDBNull(dr.GetOrdinal("agendamento")) ? DateTime.MinValue : dr.GetDateTime("agendamento"),
                            Conclusao = dr.IsDBNull(dr.GetOrdinal("conclusao")) ? "" : dr.GetString("conclusao"),
                            Orientacoes = dr.IsDBNull(dr.GetOrdinal("orientacoes")) ? "" : dr.GetString("orientacoes"),
                            ObservacoesDetalhadas = null, // será preenchido abaixo se existir
                            Observacoes = new List<string>()
                        };

                        // preencher objeto ObservacoesVisita se houver
                        if (!dr.IsDBNull(dr.GetOrdinal("idObservacoesVisita")))
                        {
                            var obs = new ObservacoesVisita
                            {
                                IdObservacoesVisita = dr.GetInt32("idObservacoesVisita"),
                                IdVisita = visita.IdVisita,
                                CondicaoFisica = dr.IsDBNull(dr.GetOrdinal("condicao_fisica")) ? null : dr.GetString("condicao_fisica"),
                                Comportamento = dr.IsDBNull(dr.GetOrdinal("comportamento")) ? null : dr.GetString("comportamento"),
                                AparenciaSaudavel = dr.IsDBNull(dr.GetOrdinal("aparencia_saudavel")) ? null : dr.GetString("aparencia_saudavel"),
                                CondicoesHigiene = dr.IsDBNull(dr.GetOrdinal("condicoes_higiene")) ? null : dr.GetString("condicoes_higiene"),
                                Vacinado = dr.IsDBNull(dr.GetOrdinal("vacinado")) ? null : dr.GetString("vacinado"),
                                Acompanhamento = dr.IsDBNull(dr.GetOrdinal("acompanhamento")) ? null : dr.GetString("acompanhamento"),
                                CondicoesAmbiente = dr.IsDBNull(dr.GetOrdinal("condicoes_ambiente")) ? null : dr.GetString("condicoes_ambiente"),
                                IndicioMaustratos = dr.IsDBNull(dr.GetOrdinal("indicio_maustratos")) ? null : dr.GetString("indicio_maustratos"),
                                Adaptacao = dr.IsDBNull(dr.GetOrdinal("adaptacao")) ? null : dr.GetString("adaptacao"),
                                RelacaoTutor = dr.IsDBNull(dr.GetOrdinal("relacao_tutor")) ? null : dr.GetString("relacao_tutor"),
                                Alteracoes = dr.IsDBNull(dr.GetOrdinal("alteracoes")) ? null : dr.GetString("alteracoes"),
                                ObservacoesLivres = dr.IsDBNull(dr.GetOrdinal("observacoes_livres")) ? null : dr.GetString("observacoes_livres")
                            };

                            visita.ObservacoesDetalhadas = obs;

                            // monta a lista de observacoes (itens descritivos + observacoes livres)
                            visita.Observacoes = MontarObservacoes(obs);
                        }
                        else
                        {
                            // garante lista vazia (evita null no UI)
                            visita.Observacoes = new List<string>();
                            visita.ObservacoesDetalhadas = new ObservacoesVisita(); // opcional, evita null ao acessar propriedades
                        }

                        lista.Add(visita);
                    }
                }
            }

            return lista;
        }

        // BUSCAR VISITAS POR FILTRO
        public List<Visita> BuscarVisitasPorFiltro(string filtro)
        {
            List<Visita> lista = new List<Visita>();

            using (MySqlConnection conn = conexao.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        v.idVisita,
                        v.idProcessoAdotivo,
                        v.idVoluntario,
                        v.dataRealizada,
                        v.realizada,
                        v.agendamento,
                        v.conclusao,
                        v.orientacoes,
                        ov.idObservacoesVisita,
                        ov.observacoes AS observacoes_livres
                    FROM Visita v
                    LEFT JOIN ObservacoesVisita ov ON ov.idVisita = v.idVisita
                    WHERE
                        CAST(v.idVisita AS CHAR) LIKE @filtro
                        OR CAST(v.idProcessoAdotivo AS CHAR) LIKE @filtro
                        OR v.realizada LIKE @filtro
                        OR v.conclusao LIKE @filtro
                    ORDER BY v.idVisita DESC;
                ";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Visita visita = new Visita
                            {
                                IdVisita = dr.GetInt32("idVisita"),
                                IdProcessoAdotivo = dr.GetInt32("idProcessoAdotivo"),
                                IdVoluntario = dr.IsDBNull(dr.GetOrdinal("idVoluntario")) ? 0 : dr.GetInt32("idVoluntario"),
                                DataVisita = dr.IsDBNull(dr.GetOrdinal("dataRealizada")) ? DateTime.MinValue : dr.GetDateTime("dataRealizada"),
                                Situacao = dr.IsDBNull(dr.GetOrdinal("realizada")) ? "" : dr.GetString("realizada"),
                                DataAgendada = dr.IsDBNull(dr.GetOrdinal("agendamento")) ? DateTime.MinValue : dr.GetDateTime("agendamento"),
                                Conclusao = dr.IsDBNull(dr.GetOrdinal("conclusao")) ? "" : dr.GetString("conclusao"),
                                Orientacoes = dr.IsDBNull(dr.GetOrdinal("orientacoes")) ? "" : dr.GetString("orientacoes"),
                                ObservacoesDetalhadas = new ObservacoesVisita()
                            };

                            if (!dr.IsDBNull(dr.GetOrdinal("observacoes_livres")))
                            {
                                visita.ObservacoesDetalhadas.ObservacoesLivres = dr.GetString("observacoes_livres");
                                visita.Observacoes = new List<string>(visita.ObservacoesDetalhadas.ObservacoesLivres.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries));
                            }
                            else
                            {
                                visita.Observacoes = new List<string>();
                            }

                            lista.Add(visita);
                        }
                    }
                }
            }

            return lista;
        }

        // BUSCAR VISITA POR ID (inclui observacoes)
        public Visita BuscarVisita(int idVisita)
        {
            Visita visita = null;

            using (MySqlConnection conn = conexao.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        v.idVisita,
                        v.idProcessoAdotivo,
                        v.idVoluntario,
                        v.dataRealizada,
                        v.realizada,
                        v.agendamento,
                        v.conclusao,
                        v.orientacoes,
                        ov.idObservacoesVisita,
                        ov.condicao_fisica,
                        ov.comportamento,
                        ov.aparencia_saudavel,
                        ov.condicoes_higiene,
                        ov.vacinado,
                        ov.acompanhamento,
                        ov.condicoes_ambiente,
                        ov.indicio_maustratos,
                        ov.adaptacao,
                        ov.relacao_tutor,
                        ov.alteracoes,
                        ov.observacoes AS observacoes_livres
                    FROM Visita v
                    LEFT JOIN ObservacoesVisita ov ON ov.idVisita = v.idVisita
                    WHERE v.idVisita = @id;
                ";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idVisita);

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            visita = new Visita
                            {
                                IdVisita = dr.GetInt32("idVisita"),
                                IdProcessoAdotivo = dr.GetInt32("idProcessoAdotivo"),
                                IdVoluntario = dr.IsDBNull(dr.GetOrdinal("idVoluntario")) ? 0 : dr.GetInt32("idVoluntario"),
                                DataVisita = dr.IsDBNull(dr.GetOrdinal("dataRealizada")) ? DateTime.MinValue : dr.GetDateTime("dataRealizada"),
                                Situacao = dr.IsDBNull(dr.GetOrdinal("realizada")) ? "" : dr.GetString("realizada"),
                                DataAgendada = dr.IsDBNull(dr.GetOrdinal("agendamento")) ? DateTime.MinValue : dr.GetDateTime("agendamento"),
                                Conclusao = dr.IsDBNull(dr.GetOrdinal("conclusao")) ? "" : dr.GetString("conclusao"),
                                Orientacoes = dr.IsDBNull(dr.GetOrdinal("orientacoes")) ? "" : dr.GetString("orientacoes"),
                                ObservacoesDetalhadas = new ObservacoesVisita()
                            };

                            if (!dr.IsDBNull(dr.GetOrdinal("idObservacoesVisita")))
                            {
                                visita.ObservacoesDetalhadas.IdObservacoesVisita = dr.GetInt32("idObservacoesVisita");
                                visita.ObservacoesDetalhadas.IdVisita = visita.IdVisita;
                                visita.ObservacoesDetalhadas.CondicaoFisica = dr.IsDBNull(dr.GetOrdinal("condicao_fisica")) ? null : dr.GetString("condicao_fisica");
                                visita.ObservacoesDetalhadas.Comportamento = dr.IsDBNull(dr.GetOrdinal("comportamento")) ? null : dr.GetString("comportamento");
                                visita.ObservacoesDetalhadas.AparenciaSaudavel = dr.IsDBNull(dr.GetOrdinal("aparencia_saudavel")) ? null : dr.GetString("aparencia_saudavel");
                                visita.ObservacoesDetalhadas.CondicoesHigiene = dr.IsDBNull(dr.GetOrdinal("condicoes_higiene")) ? null : dr.GetString("condicoes_higiene");
                                visita.ObservacoesDetalhadas.Vacinado = dr.IsDBNull(dr.GetOrdinal("vacinado")) ? null : dr.GetString("vacinado");
                                visita.ObservacoesDetalhadas.Acompanhamento = dr.IsDBNull(dr.GetOrdinal("acompanhamento")) ? null : dr.GetString("acompanhamento");
                                visita.ObservacoesDetalhadas.CondicoesAmbiente = dr.IsDBNull(dr.GetOrdinal("condicoes_ambiente")) ? null : dr.GetString("condicoes_ambiente");
                                visita.ObservacoesDetalhadas.IndicioMaustratos = dr.IsDBNull(dr.GetOrdinal("indicio_maustratos")) ? null : dr.GetString("indicio_maustratos");
                                visita.ObservacoesDetalhadas.Adaptacao = dr.IsDBNull(dr.GetOrdinal("adaptacao")) ? null : dr.GetString("adaptacao");
                                visita.ObservacoesDetalhadas.RelacaoTutor = dr.IsDBNull(dr.GetOrdinal("relacao_tutor")) ? null : dr.GetString("relacao_tutor");
                                visita.ObservacoesDetalhadas.Alteracoes = dr.IsDBNull(dr.GetOrdinal("alteracoes")) ? null : dr.GetString("alteracoes");
                                visita.ObservacoesDetalhadas.ObservacoesLivres = dr.IsDBNull(dr.GetOrdinal("observacoes_livres")) ? null : dr.GetString("observacoes_livres");

                                if (!string.IsNullOrWhiteSpace(visita.ObservacoesDetalhadas.ObservacoesLivres))
                                {
                                    visita.Observacoes = new List<string>(visita.ObservacoesDetalhadas.ObservacoesLivres.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries));
                                }
                            }
                        }
                    }
                }
            }

            return visita;
        }

        // REMOVER VISITA + OBSERVACOES
        public bool ExcluirVisita(int idVisita)
        {
            using (MySqlConnection conn = conexao.GetConnection())
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // excluir observacoes (se existir)
                    string sqlObs = "DELETE FROM ObservacoesVisita WHERE idVisita = @id;";
                    using (MySqlCommand cmd1 = new MySqlCommand(sqlObs, conn, trans))
                    {
                        cmd1.Parameters.AddWithValue("@id", idVisita);
                        cmd1.ExecuteNonQuery();
                    }

                    // excluir visita
                    string sqlVisita = "DELETE FROM Visita WHERE idVisita = @id;";
                    using (MySqlCommand cmd2 = new MySqlCommand(sqlVisita, conn, trans))
                    {
                        cmd2.Parameters.AddWithValue("@id", idVisita);
                        cmd2.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch
                {
                    try { trans.Rollback(); } catch { }
                    return false;
                }
            }
        }

        // monta uma lista de observações a partir do objeto ObservacoesVisita
        private List<string> MontarObservacoes(ObservacoesVisita od)
        {
            var lista = new List<string>();
            if (od == null) return lista;

            void AddIfNotEmpty(string titulo, string valor)
            {
                if (!string.IsNullOrWhiteSpace(valor))
                    lista.Add($"{titulo}: {valor}");
            }

            AddIfNotEmpty("Condição Física", od.CondicaoFisica);
            AddIfNotEmpty("Comportamento", od.Comportamento);
            AddIfNotEmpty("Aparência Saudável", od.AparenciaSaudavel);
            AddIfNotEmpty("Condições de Higiene", od.CondicoesHigiene);
            AddIfNotEmpty("Vacinado", od.Vacinado);
            AddIfNotEmpty("Acompanhamento", od.Acompanhamento);
            AddIfNotEmpty("Condições do Ambiente", od.CondicoesAmbiente);
            AddIfNotEmpty("Indício de Maus Tratos", od.IndicioMaustratos);
            AddIfNotEmpty("Adaptação", od.Adaptacao);
            AddIfNotEmpty("Relação com Tutor", od.RelacaoTutor);
            AddIfNotEmpty("Alterações", od.Alteracoes);

            // adiciona observações livres (se houver), separadas por " | "
            if (!string.IsNullOrWhiteSpace(od.ObservacoesLivres))
            {
                var partes = od.ObservacoesLivres.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var p in partes)
                    if (!string.IsNullOrWhiteSpace(p))
                        lista.Add(p.Trim());
            }

            return lista;
        }

        // LISTAR APENAS O CAMPO 'observacoes' COMO LISTA (útil para UI)
        public List<string> ListarObservacoesPorVisita(int idVisita)
        {
            var visita = BuscarVisita(idVisita);
            if (visita == null) return new List<string>();
            return visita.Observacoes ?? new List<string>();
        }
    }
}
