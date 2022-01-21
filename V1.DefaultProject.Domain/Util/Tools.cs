using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace V1.DefaultProject.Domain.Util
{
    public static class Tools
    {
        public static string GerarSenhaAleatoria(int? quantidade = 8)
        {
            string senha = "";

            char[] caracters = new char[] {'Q','W','E','R','T','Y','U','I','O','P','A','S','D','F','G','H','J','K','L','Z','X','C','V','B','N','M',
                                           'q','w','e','r','t','y','u','i','o','p','a','s','d','f','g','h','j','k','l','z','x','c','v','b','n','m',
                                           '@','1','2','3','4','5','6','7','8','9','0'};

            Random rndPosition = new Random();

            int i = 0;
            int[] numbPositions = new int[2];

            while (i < 2)
            {
                numbPositions[i] = rndPosition.Next(0, 7);
                i++;
            }

            int upperPosition = rndPosition.Next(0, 7);

            Random r = new Random();

            for (i = 0; i < quantidade; i++)
            {
                char[] temp = caracters;

                if (numbPositions.Contains(i))
                    temp = caracters.Where(c => char.IsNumber(c)).ToArray();

                if (upperPosition == i)
                    temp = caracters.Where(c => char.IsUpper(c)).ToArray();

                senha += temp[r.Next(0, temp.Length)].ToString();
            }

            return senha.Trim();
        }

        public static byte[] StringToByteArray(String hexString)
        {
            byte[] retval = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i += 2)
                retval[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            return retval;
        }

        public static string GetEnumDescription(System.Enum value)
        {
            FieldInfo fi = value?.GetType()?.GetField(value.ToString());
            if (fi != null)
            {
                DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

                if (attributes != null && attributes.Any())
                {
                    return attributes.First().Description;
                }
            }
            return value?.ToString();
        }

        public static string DiferencaEntreDatas(DateTime dataInicio, DateTime? dataFim)
        {
            var duracao = dataFim.HasValue ? dataFim.Value.Subtract(dataInicio) : DateTime.Now.Subtract(dataInicio);

            string duracaoFormatada = "";

            if (duracao.Days > 0) duracaoFormatada += duracao.Days + " dias ";
            if (duracao.Hours > 0) duracaoFormatada += duracao.Hours + " horas ";
            if (duracao.Minutes > 0) duracaoFormatada += duracao.Minutes + " minutos";

            return duracaoFormatada;
        }
        public static string FormatarData(DateTime data)
        {
            return ((data.Day < 10 ? "0" + data.Day.ToString() : data.Day.ToString()) + "/" +
                (data.Month < 10 ? "0" + data.Month.ToString() : data.Month.ToString()) + "/" +
                data.Year.ToString());
        }
        public static string FormatarCPF(string cpf)
        {
            return ((cpf.Length == 11 ? cpf.Substring(0, 3) + "." +
                cpf.Substring(3, 3) + "." + cpf.Substring(6, 3) + "-" +
                cpf.Substring(9, 2) : cpf));
        }

        public static string RetonarMesString(int mes)
        {
            return (mes == 1 ? "Janeiro" : mes == 2 ? "Fevereiro"
                : mes == 3 ? "Março" : mes == 4 ? "Abril"
                : mes == 5 ? "Maio" : mes == 6 ? "Junho"
                : mes == 7 ? "Julho" : mes == 8 ? "Agosto"
                : mes == 9 ? "Setembro" : mes == 10 ? "Outubro"
                : mes == 11 ? "Novembro" : mes == 12 ? "Dezembro" : "");
        }

        /// <summary>
        /// Formata um CNPJ com a máscara 00.000.000/0000-00
        /// </summary>
        /// <param name="cnpj">string Cnpj</param>
        /// <returns></returns>
        public static string ToCNPJFormat(this string cnpj)
        {
            if (!cnpj.IsEmpty())
            {
                cnpj = cnpj.Trim();

                MaskedTextProvider mtpCnpj = new MaskedTextProvider(@"00.000.000/0000-00");
                mtpCnpj.Set(cnpj.PadLeft(14, '0'));
                return mtpCnpj.ToString();
            }

            return null;
        }

        public static bool IsEmpty(this object source)
        {
            bool result = (source == null ||
                               source.Equals(0) ||
                               source.ToString().Equals("0") ||
                               (source is string && source.ToString().Trim().Equals(string.Empty)) ||
                               source.Equals(string.Empty) ||
                               (source is decimal && ((decimal)source).Equals(0)) ||
                               SqlDateTime.MinValue.Equals(source) ||
                               DateTime.MinValue.Equals(source)) ||
                               (source is ICollection && ((ICollection)source).Count == 0) ||
                               TimeSpan.Zero.Equals(source);

            if (!result)
            {
                Type collectionType = source.GetType().GetInterfaces().SingleOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICollection<>));

                result = collectionType != null && ((int)collectionType.GetProperty("Count").GetValue(source, null)) == 0;
            }

            return result;
        }

        public static bool ValidaEmail(string email)
        {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool isValid = Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
            return isValid;
        }
    }
}
