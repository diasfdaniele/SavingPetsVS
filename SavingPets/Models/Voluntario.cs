using System;

namespace SavingPets.Models
{
    public class Voluntario
    {
        // Dados do Voluntário/Pessoa
        public int IdVoluntario { get; set; }
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; } // "M" ou "F"
        public DateTime DataCadastro { get; set; } // Data de entrada como Voluntário

        // Dados de Login (Tabela Pessoa)
        public string Login { get; set; }
        public string Senha { get; set; }

        // Dados de Endereço
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        // Dados de Telefone
        public string TelefoneCompleto { get; set; } // Para receber do Form

        // Propriedade para definir se será Tutor também
        public bool EhTutor { get; set; }

       
    }
}