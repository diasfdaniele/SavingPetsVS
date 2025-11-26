using MySql.Data.MySqlClient;
using SavingPets.Models;
using System;
using System.Collections.Generic;

namespace SavingPets.DAL
{
    public class BancoDadosAnimal
    {
        private Conexao conexao = new Conexao();

        // Extrai dados do animal (preenche todos os campos do model que salvamos)
        public Animal ExtrairDados(int id)
        {
            Animal animal = null;

            using (MySqlConnection conect = conexao.GetConnection())
            {
                try
                {
                    conect.Open();
                    string sql = @"SELECT idAnimal, nome, especie, raca, sexo, vermifugado, castrado, historicoSaude
                                   FROM Animal
                                   WHERE idAnimal = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conect))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader leitor = cmd.ExecuteReader())
                        {
                            if (leitor.Read())
                            {
                                animal = new Animal();
                                animal.IdAnimal = leitor.GetInt32("idAnimal");
                                animal.NomeAnimal = leitor.GetString("nome");
                                animal.Especie = leitor.GetString("especie");
                                animal.Raca = leitor.GetString("raca");
                                animal.SexoAnimal = leitor.GetString("sexo");

                                // vermifugado e castrado vêm como ENUM('Sim','Não') no banco -> mapear para bool
                                string vermif = leitor.IsDBNull(leitor.GetOrdinal("vermifugado")) ? "Não" : leitor.GetString("vermifugado");
                                animal.Vermifugado = vermif.Equals("Sim", StringComparison.OrdinalIgnoreCase);

                                string castr = leitor.IsDBNull(leitor.GetOrdinal("castrado")) ? "Não" : leitor.GetString("castrado");
                                animal.Castrado = castr.Equals("Sim", StringComparison.OrdinalIgnoreCase);

                                animal.HistoricoDoencas = leitor.IsDBNull(leitor.GetOrdinal("historicoSaude")) ? "" : leitor.GetString("historicoSaude");
                            }
                        }
                    }

                    // Se encontrou o animal, carregar também vacinas
                    if (animal != null)
                    {
                        animal.Vacinas = ObterVacinasDoAnimal(conect, animal.IdAnimal);
                    }

                    return animal;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao extrair animal: " + ex.Message);
                }
            }
        }

        // Obter lista de vacinas para um animal (usa a mesma conexão aberta)
        private List<string> ObterVacinasDoAnimal(MySqlConnection conexaoAberta, int idAnimal)
        {
            List<string> vacs = new List<string>();

            string sql = @"SELECT nome FROM Vacina WHERE idAnimal = @idAnimal";

            using (MySqlCommand cmd = new MySqlCommand(sql, conexaoAberta))
            {
                cmd.Parameters.AddWithValue("@idAnimal", idAnimal);
                using (MySqlDataReader leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        vacs.Add(leitor.GetString("nome"));
                    }
                }
            }

            return vacs;
        }

        // Salvar animal e vacinas (usa transação)
        public void SalvaDados(Animal animal)
        {
            using (MySqlConnection conect = conexao.GetConnection())
            {
                conect.Open();
                MySqlTransaction trans = conect.BeginTransaction();

                try
                {
                    // 1) Inserir animal (idTutor NULL)
                    string sqlInsert = @"
                        INSERT INTO Animal (nome, sexo, raca, castrado, vermifugado, historicoSaude, especie, idTutor)
                        VALUES (@nome, @sexo, @raca, @castrado, @vermifugado, @historicoSaude, @especie, @idTutor);";

                    using (MySqlCommand cmd = new MySqlCommand(sqlInsert, conect, trans))
                    {
                        cmd.Parameters.AddWithValue("@nome", animal.NomeAnimal);
                        cmd.Parameters.AddWithValue("@sexo", animal.SexoAnimal);
                        cmd.Parameters.AddWithValue("@raca", animal.Raca);
                        // salvar castrado/vermifugado como "Sim"/"Não" para compatibilidade com ENUM do BD
                        cmd.Parameters.AddWithValue("@castrado", animal.Castrado ? "Sim" : "Não");
                        cmd.Parameters.AddWithValue("@vermifugado", animal.Vermifugado ? "Sim" : "Não");
                        cmd.Parameters.AddWithValue("@historicoSaude", string.IsNullOrEmpty(animal.HistoricoDoencas) ? (object)DBNull.Value : animal.HistoricoDoencas);
                        cmd.Parameters.AddWithValue("@especie", animal.Especie);
                        cmd.Parameters.AddWithValue("@idTutor", DBNull.Value); // ainda sem tutor

                        cmd.ExecuteNonQuery();
                    }

                    // pegar id gerado
                    int novoIdAnimal;
                    using (MySqlCommand cmdId = new MySqlCommand("SELECT LAST_INSERT_ID();", conect, trans))
                    {
                        novoIdAnimal = Convert.ToInt32(cmdId.ExecuteScalar());
                    }

                    // 2) Inserir vacinas (se houver)
                    if (animal.Vacinas != null && animal.Vacinas.Count > 0)
                    {
                        string sqlVac = @"INSERT INTO Vacina (nome, dataAplicacao, idAnimal) VALUES (@nome, @dataAplicacao, @idAnimal)";
                        using (MySqlCommand cmdVac = new MySqlCommand(sqlVac, conect, trans))
                        {
                            cmdVac.Parameters.Add("@nome", MySqlDbType.VarChar);
                            cmdVac.Parameters.Add("@dataAplicacao", MySqlDbType.Date);
                            cmdVac.Parameters.Add("@idAnimal", MySqlDbType.Int32);

                            foreach (var vac in animal.Vacinas)
                            {
                                cmdVac.Parameters["@nome"].Value = vac;
                                cmdVac.Parameters["@dataAplicacao"].Value = DateTime.Now.Date; // usar data atual
                                cmdVac.Parameters["@idAnimal"].Value = novoIdAnimal;
                                cmdVac.ExecuteNonQuery();
                            }
                        }
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    try { trans.Rollback(); } catch { }
                    throw new Exception("Erro ao salvar animal: " + ex.Message);
                }
            }
        }

        // Listar todos os ids existentes
        public List<int> ListarIds()
        {
            List<int> Ids = new List<int>();

            try
            {
                using (MySqlConnection Conect = conexao.GetConnection())
                {
                    Conect.Open();

                    string ComandoSql = @"SELECT idAnimal FROM Animal";

                    using (MySqlCommand Comando = new MySqlCommand(ComandoSql, Conect))
                    using (MySqlDataReader LeitorDados = Comando.ExecuteReader())
                    {
                        while (LeitorDados.Read())
                        {
                            Ids.Add(LeitorDados.GetInt32("idAnimal"));
                        }
                    }
                }

                return Ids;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar IDs: " + ex.Message);
            }
        }

        public bool ExcluirDados(int id)
        {
            using (MySqlConnection Conect = conexao.GetConnection())
            {
                Conect.Open();
                MySqlTransaction trans = Conect.BeginTransaction();
                try
                {
                    // Excluir vacinas (FK se configurada com cascade pode não ser necessário; aqui removemos explicitamente)
                    using (MySqlCommand cmdVac = new MySqlCommand("DELETE FROM Vacina WHERE idAnimal = @id", Conect, trans))
                    {
                        cmdVac.Parameters.AddWithValue("@id", id);
                        cmdVac.ExecuteNonQuery();
                    }

                    // Excluir animal
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Animal WHERE idAnimal = @id", Conect, trans))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int linhas = cmd.ExecuteNonQuery();
                        trans.Commit();
                        return linhas > 0;
                    }
                }
                catch (Exception ex)
                {
                    try { trans.Rollback(); } catch { }
                    throw new Exception("Erro ao excluir animal: " + ex.Message);
                }
            }
        }

        public bool AlterarDados(Animal animal)
        {
            using (MySqlConnection Conect = conexao.GetConnection())
            {
                Conect.Open();
                MySqlTransaction trans = Conect.BeginTransaction();
                try
                {
                    string ComandoSql = @"
                        UPDATE Animal 
                        SET nome = @nome,
                            sexo = @sexo,
                            raca = @raca,
                            castrado = @castrado,
                            vermifugado = @vermifugado,
                            historicoSaude = @historicoSaude,
                            especie = @especie
                        WHERE idAnimal = @id";

                    using (MySqlCommand Comando = new MySqlCommand(ComandoSql, Conect, trans))
                    {
                        Comando.Parameters.AddWithValue("@nome", animal.NomeAnimal);
                        Comando.Parameters.AddWithValue("@sexo", animal.SexoAnimal);
                        Comando.Parameters.AddWithValue("@raca", animal.Raca);
                        Comando.Parameters.AddWithValue("@castrado", animal.Castrado ? "Sim" : "Não");
                        Comando.Parameters.AddWithValue("@vermifugado", animal.Vermifugado ? "Sim" : "Não");
                        Comando.Parameters.AddWithValue("@historicoSaude", string.IsNullOrEmpty(animal.HistoricoDoencas) ? (object)DBNull.Value : animal.HistoricoDoencas);
                        Comando.Parameters.AddWithValue("@especie", animal.Especie);
                        Comando.Parameters.AddWithValue("@id", animal.IdAnimal);

                        int linhas = Comando.ExecuteNonQuery();

                        // Atualizar vacinas: remover as anteriores e inserir as novas
                        using (MySqlCommand cmdDelVac = new MySqlCommand("DELETE FROM Vacina WHERE idAnimal = @id", Conect, trans))
                        {
                            cmdDelVac.Parameters.AddWithValue("@id", animal.IdAnimal);
                            cmdDelVac.ExecuteNonQuery();
                        }

                        if (animal.Vacinas != null && animal.Vacinas.Count > 0)
                        {
                            using (MySqlCommand cmdVac = new MySqlCommand("INSERT INTO Vacina (nome, dataAplicacao, idAnimal) VALUES (@nome, @dataAplicacao, @idAnimal)", Conect, trans))
                            {
                                cmdVac.Parameters.Add("@nome", MySqlDbType.VarChar);
                                cmdVac.Parameters.Add("@dataAplicacao", MySqlDbType.Date);
                                cmdVac.Parameters.Add("@idAnimal", MySqlDbType.Int32);

                                foreach (var vac in animal.Vacinas)
                                {
                                    cmdVac.Parameters["@nome"].Value = vac;
                                    cmdVac.Parameters["@dataAplicacao"].Value = DateTime.Now.Date;
                                    cmdVac.Parameters["@idAnimal"].Value = animal.IdAnimal;
                                    cmdVac.ExecuteNonQuery();
                                }
                            }
                        }

                        trans.Commit();
                        return linhas > 0;
                    }
                }
                catch (Exception ex)
                {
                    try { trans.Rollback(); } catch { }
                    throw new Exception("Erro ao alterar animal: " + ex.Message);
                }
            }
        }

        // Extrai o maior id; se não houver, retorna 0
        public int ExtrairMaiorId()
        {
            try
            {
                using (MySqlConnection Conect = conexao.GetConnection())
                {
                    Conect.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT MAX(idAnimal) FROM Animal", Conect))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result == DBNull.Value || result == null)
                            return 0;
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar maior ID: " + ex.Message);
            }
        }
    }
}