using MySql.Data.MySqlClient;
using SavingPets.Models;
using System;
using System.Collections.Generic;
using static SavingPets.DAL.Login; // Para acessar SessaoUsuario

namespace SavingPets.DAL
{
    public class BancoDadosVisita
    {
        private readonly Conexao conexao = new Conexao();

        // -----------------------------------------------------------
        // CONFIGURA A VARIÁVEL DE SESSÃO PARA AS TRIGGERS DE LOG
        // -----------------------------------------------------------
        private void ConfigurarSessao(MySqlConnection conn, MySqlTransaction trans)
        {
            int idVol = SessaoUsuario.IdVoluntarioLogado;
            // Se não houver ninguém logado (0), define como 1 (Admin padrão) ou deixa NULL dependendo da regra
            if (idVol <= 0) idVol = 1;

            string sql = $"SET @voluntario_responsavel = {idVol};";
            using (MySqlCommand cmd = new MySqlCommand(sql, conn, trans))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // -----------------------------------------------------------
        // BUSCAR NOME DO VOLUNTÁRIO LOGADO
        // -----------------------------------------------------------
        public string ObterNomeVoluntarioLogado()
        {
            int idVol = SessaoUsuario.IdVoluntarioLogado;
            if (idVol <= 0) return "Desconhecido";

            string nome = "";
            using (MySqlConnection conn = conexao.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Busca o nome na tabela Pessoa via JOIN com Voluntario
                    string sql = @"SELECT P.nome 
                                   FROM Pessoa P 
                                   INNER JOIN Voluntario V ON P.idPessoa = V.idPessoa 
                                   WHERE V.idVoluntario = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idVol);
                        object result = cmd.ExecuteScalar();
                        if (result != null) nome = result.ToString();
                    }
                }
                catch { return "Erro ao buscar nome"; }
            }
            return nome;
        }

        // CADASTRO DE VISITAS
        public bool InserirVisitaCompleta(Visita visita)
        {
            using (MySqlConnection conn = conexao.GetConnection())
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 🔥 1. Configura a sessão para o LOG
                    ConfigurarSessao(conn, trans);

                    // 2) Inserir na tabela Visita
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
                        // Usa o ID do voluntário logado se o objeto vier zerado
                        int idVol = visita.IdVoluntario > 0 ? visita.IdVoluntario : SessaoUsuario.IdVoluntarioLogado;
                        cmdVisita.Parameters.AddWithValue("@idVoluntario", idVol);

                        cmdVisita.Parameters.AddWithValue("@dataRealizada", visita.DataVisita);
                        cmdVisita.Parameters.AddWithValue("@realizada", string.IsNullOrWhiteSpace(visita.Situacao) ? (object)DBNull.Value : visita.Situacao);
                        cmdVisita.Parameters.AddWithValue("@agendamento", visita.DataAgendada == default ? (object)DBNull.Value : visita.DataAgendada);
                        cmdVisita.Parameters.AddWithValue("@conclusao", string.IsNullOrWhiteSpace(visita.Conclusao) ? (object)DBNull.Value : visita.Conclusao);
                        cmdVisita.Parameters.AddWithValue("@orientacoes", string.IsNullOrWhiteSpace(visita.Orientacoes) ? (object)DBNull.Value : visita.Orientacoes);

                        object scalar = cmdVisita.ExecuteScalar();
                        int idVisitaGerado = Convert.ToInt32(scalar);
                        visita.IdVisita = idVisitaGerado;
                    }

                    // 3) Inserir ObservacoesVisita 
                    if (visita.ObservacoesDetalhadas != null)
                    {
                        string observacoesConcatenadas = null;
                        if (visita.Observacoes != null && visita.Observacoes.Count > 0)
                        {
                            observacoesConcatenadas = string.Join(" | ", visita.Observacoes);
                        }
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

        // LISTAR TODAS AS VISITAS
        public List<Visita> ListarVisitas()
        {
            List<Visita> lista = new List<Visita>();

            using (MySqlConnection conn = conexao.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        v.idVisita, v.idProcessoAdotivo, v.idVoluntario, v.dataRealizada, v.realizada,
                        v.agendamento, v.conclusao, v.orientacoes,
                        ov.idObservacoesVisita, ov.condicao_fisica, ov.comportamento, ov.aparencia_saudavel,
                        ov.condicoes_higiene, ov.vacinado, ov.acompanhamento, ov.condicoes_ambiente,
                        ov.indicio_maustratos, ov.adaptacao, ov.relacao_tutor, ov.alteracoes,
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
                        Visita visita = MapearVisita(dr);
                        lista.Add(visita);
                    }
                }
            }
            return lista;
        }

        // BUSCAR POR ID
        public Visita BuscarVisita(int idVisita)
        {
            Visita visita = null;
            using (MySqlConnection conn = conexao.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT * FROM Visita v LEFT JOIN ObservacoesVisita ov ON ov.idVisita = v.idVisita WHERE v.idVisita = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idVisita);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) visita = MapearVisita(dr);
                    }
                }
            }
            return visita;
        }

        // FILTRO
        public List<Visita> BuscarVisitasPorFiltro(string filtro)
        {
            List<Visita> lista = new List<Visita>();
            using (MySqlConnection conn = conexao.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT * FROM Visita v LEFT JOIN ObservacoesVisita ov ON ov.idVisita = v.idVisita
                    WHERE CAST(v.idVisita AS CHAR) LIKE @filtro OR CAST(v.idProcessoAdotivo AS CHAR) LIKE @filtro
                    OR v.realizada LIKE @filtro OR v.conclusao LIKE @filtro
                    ORDER BY v.idVisita DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) lista.Add(MapearVisita(dr));
                    }
                }
            }
            return lista;
        }

        // EXCLUIR
        public bool ExcluirVisita(int idVisita)
        {
            using (MySqlConnection conn = conexao.GetConnection())
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 🔥 Configura a sessão para o LOG
                    ConfigurarSessao(conn, trans);

                    new MySqlCommand("DELETE FROM ObservacoesVisita WHERE idVisita = @id", conn, trans) { Parameters = { new MySqlParameter("@id", idVisita) } }.ExecuteNonQuery();
                    new MySqlCommand("DELETE FROM Visita WHERE idVisita = @id", conn, trans) { Parameters = { new MySqlParameter("@id", idVisita) } }.ExecuteNonQuery();
                    trans.Commit();
                    return true;
                }
                catch { try { trans.Rollback(); } catch { } return false; }
            }
        }

        // OBTER PRÓXIMO ID
        public int ObterProximoId()
        {
            int nextId = 1;
            using (MySqlConnection conn = conexao.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = $"SELECT AUTO_INCREMENT FROM information_schema.TABLES WHERE TABLE_SCHEMA = '{conn.Database}' AND TABLE_NAME = 'Visita'";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value) nextId = Convert.ToInt32(result);
                    }
                }
                catch { return 1; }
            }
            return nextId;
        }

        // --- MÉTODOS AUXILIARES ---
        private Visita MapearVisita(MySqlDataReader dr)
        {
            Visita v = new Visita
            {
                IdVisita = dr.GetInt32("idVisita"),
                IdProcessoAdotivo = dr.GetInt32("idProcessoAdotivo"),
                IdVoluntario = dr.IsDBNull(dr.GetOrdinal("idVoluntario")) ? 0 : dr.GetInt32("idVoluntario"),
                DataVisita = dr.IsDBNull(dr.GetOrdinal("dataRealizada")) ? DateTime.MinValue : dr.GetDateTime("dataRealizada"),
                Situacao = dr.IsDBNull(dr.GetOrdinal("realizada")) ? "" : dr.GetString("realizada"),
                DataAgendada = dr.IsDBNull(dr.GetOrdinal("agendamento")) ? DateTime.MinValue : dr.GetDateTime("agendamento"),
                Conclusao = dr.IsDBNull(dr.GetOrdinal("conclusao")) ? "" : dr.GetString("conclusao"),
                Orientacoes = dr.IsDBNull(dr.GetOrdinal("orientacoes")) ? "" : dr.GetString("orientacoes"),
                ObservacoesDetalhadas = new ObservacoesVisita(),
                Observacoes = new List<string>()
            };

            if (!dr.IsDBNull(dr.GetOrdinal("idObservacoesVisita")))
            {
                var o = v.ObservacoesDetalhadas;
                o.IdObservacoesVisita = dr.GetInt32("idObservacoesVisita");
                o.IdVisita = v.IdVisita;
                o.CondicaoFisica = dr.IsDBNull(dr.GetOrdinal("condicao_fisica")) ? null : dr.GetString("condicao_fisica");
                o.Comportamento = dr.IsDBNull(dr.GetOrdinal("comportamento")) ? null : dr.GetString("comportamento");
                o.AparenciaSaudavel = dr.IsDBNull(dr.GetOrdinal("aparencia_saudavel")) ? null : dr.GetString("aparencia_saudavel");
                o.CondicoesHigiene = dr.IsDBNull(dr.GetOrdinal("condicoes_higiene")) ? null : dr.GetString("condicoes_higiene");
                o.Vacinado = dr.IsDBNull(dr.GetOrdinal("vacinado")) ? null : dr.GetString("vacinado");
                o.Acompanhamento = dr.IsDBNull(dr.GetOrdinal("acompanhamento")) ? null : dr.GetString("acompanhamento");
                o.CondicoesAmbiente = dr.IsDBNull(dr.GetOrdinal("condicoes_ambiente")) ? null : dr.GetString("condicoes_ambiente");
                o.IndicioMaustratos = dr.IsDBNull(dr.GetOrdinal("indicio_maustratos")) ? null : dr.GetString("indicio_maustratos");
                o.Adaptacao = dr.IsDBNull(dr.GetOrdinal("adaptacao")) ? null : dr.GetString("adaptacao");
                o.RelacaoTutor = dr.IsDBNull(dr.GetOrdinal("relacao_tutor")) ? null : dr.GetString("relacao_tutor");
                o.Alteracoes = dr.IsDBNull(dr.GetOrdinal("alteracoes")) ? null : dr.GetString("alteracoes");
                o.ObservacoesLivres = dr.IsDBNull(dr.GetOrdinal("observacoes_livres")) ? null : dr.GetString("observacoes_livres");

                if (!string.IsNullOrWhiteSpace(o.ObservacoesLivres))
                    v.Observacoes = new List<string>(o.ObservacoesLivres.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries));
            }
            return v;
        }

        private List<string> MontarObservacoes(ObservacoesVisita od) { /* simplificado */ return new List<string>(); }
    }
}