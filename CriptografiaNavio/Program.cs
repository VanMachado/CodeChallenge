using System;
using System.Text;
using System.Collections.Generic;

namespace CriptoGrafiaNavio
{
    class Program
    {
        static void Main(string[] args)
        {
            string cripto = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";
            string[] criptoArray = cripto.Split(" ");
            List<string> result = new List<string>();
            List<string> result2 = new List<string>();

            InvertEightBits(criptoArray, result);
            ReorganizeFourBits(result, result2);
            Console.WriteLine(ConvertToText(result2));
        }

        private static List<string> InvertEightBits(string[] array, List<string> list)
        {
            foreach (string a in array)
            {
                string b = "";
                for (int i = 0; i < a.Length; i++)
                {
                    if (i < 6)
                        b += a[i];

                    if (i == 6)
                        b += a[i] == '1' ? "0" : "1";

                    if (i == 7)
                        b += a[i] == '1' ? "0" : "1";
                }
                list.Add(b);
            }

            return list;
        }

        private static List<string> ReorganizeFourBits(List<string> list, List<string> result)
        {
            string c = "";

            foreach (string b in list)
            {
                string aux1 = "";
                string aux2 = "";

                for (int i = 0; i < b.Length; i++)
                {
                    if (i < 4)
                        aux1 += b[i];
                    else
                        aux2 += b[i];
                }
                c = aux2 + aux1;

            result.Add(c);
            }

            return result;
        }

        private static string ConvertToText(List<string> list)
        {
            string message = "";

            foreach (string letra in list)
            {
                char caractere = (char)Convert.ToInt32(letra, 2);
                message += caractere;
            }

            return message;
        }        
    }
}