using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace scadastro.Utils
{
    public static class Helper
    {

        public static bool IsCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                return false;
            }

            cpf = cpf.Replace(".", "").Replace("-", "").Replace("/", "").Replace("_", "").Replace(" ", "").Trim();
            
            if (cpf.Any(c => !IsDigit(c)))
            {
                return false;
            }
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1)
            {
                return false;
            }
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }



        public static string TelefoneSemFormatacao(string telefone)
        {
            if (string.IsNullOrEmpty(telefone))
            {
                return telefone;
            }
            else
            {
                return telefone.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "").Replace("_", "").Trim();
            }
        }



        public static string CpfSemFormatacao(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                return cpf;
            }
            else
            {
                return cpf.Replace(".", "").Replace("-", "").Trim();
            }
        }



        public static string FormatarCPF(string cpf)
        {
            cpf = cpf.Replace("-", "").Replace("/", "").Replace(".", "").Replace("_", "").Replace(" ", "");
            int tamanhoOriginal = cpf.Length;
            //000.000.000-00
            if (tamanhoOriginal > 8)
            {
                cpf = cpf.Insert(9, "-");
            }

            if (tamanhoOriginal > 5)
            {
                cpf = cpf.Insert(6, ".");
            }
            if (tamanhoOriginal > 2)
            {
                cpf = cpf.Insert(3, ".");
            }
            return cpf;
        }


        public static string FormatarTelefone(string telefone)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(telefone))
                {
                    return telefone;
                }
                else if (telefone.Length > 10)
                {
                    return "(" + telefone.Substring(0, 2) + ") " + telefone.Substring(2, 5) + "-" + telefone.Substring(7, 4);
                }
                else
                {
                    return "(" + telefone.Substring(0, 2) + ") " + telefone.Substring(2, 4) + "-" + telefone.Substring(6, 4);
                }
            }
            catch
            {
                return telefone;
            }
        }


        public static string FormatarDataInput(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return data;
            }
            else
            {
                var arrayData = data.Split("/");

                return $"{arrayData[2]}-{arrayData[1]}-{arrayData[0]}";
            }
        }


        public static string FormatarCEP(string cep)
        {
            if (!string.IsNullOrEmpty(cep))
            {
                cep = cep.Replace("-", "");
                if (cep.Count() >= 5)
                {
                    cep = cep.Insert(5, "-");
                }
            }
            return cep;
        }

        public static bool IsEmail(string email)
        {
            bool valido = false;

            if (email != null)
            {
                if (email != string.Empty)
                {
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(email);

                    if (match.Success)
                    {
                        return valido = true;
                    }

                }
            }
            return valido;

        }


        public static string CepSemFormatacao(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
            {
                return cep;
            }
            else
            {
                return cep.Replace("-", "");
            }
        }


        public static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }



    }
}
