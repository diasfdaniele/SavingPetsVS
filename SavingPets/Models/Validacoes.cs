using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SavingPets.Models
{
    internal class Validacoes
    {
        public static bool ValidarCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            string s = new string(cpf.Where(char.IsDigit).ToArray());
            if (s.Length != 11) return false;
            if (s.All(c => c == s[0])) return false;

            int[] digits = s.Select(c => c - '0').ToArray();

            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += digits[i] * (10 - i);

            int rem = sum % 11;
            int dv1 = (rem < 2) ? 0 : 11 - rem;
            if (dv1 != digits[9]) return false;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += digits[i] * (11 - i);

            rem = sum % 11;
            int dv2 = (rem < 2) ? 0 : 11 - rem;
            if (dv2 != digits[10]) return false;

            return true;
        }

        public static bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new MailAddress(email);
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidarTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return false;

            //remove tudo que não é número
            string numeros = new string(telefone.Where(char.IsDigit).ToArray());

            //telefone tem que ter 10 ou 11 dígitos
            if (numeros.Length < 10 || numeros.Length > 11)
                return false;

            //não permite números repetidos (telefone = 11111111)
            if (numeros.All(c => c == numeros[0]))
                return false;

            return true;
        }

        public static bool ValidarCEP(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
                return false;

            //remove tudo que não é número
            string numeros = new string(cep.Where(char.IsDigit).ToArray());

            //CEP precisa ter 8 dígitos
            if (numeros.Length != 8)
                return false;

            // não permite número repetidos (cep = 1111111)
            if (numeros.All(c => c == numeros[0]))
                return false;

            return true;
        }
    }
}
