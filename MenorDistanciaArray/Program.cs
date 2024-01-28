using System;
using System.Collections.Generic;

namespace MenorDistancia
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<int> array1 = new List<int>();
            List<int> array2 = new List<int>();
            int resultado;

            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 11; i++)
                {
                    Random random = new Random();
                    int numeroAleatorio = random.Next(100);

                    if (j == 0)
                        array1.Add(numeroAleatorio);
                    if (j == 1)
                        array2.Add(numeroAleatorio);
                }
            }

            if (array1[array1.Count - 1] - array2[array2.Count - 1] < 0)
                resultado = array2[array2.Count - 1] - array1[array1.Count - 1];
            else
                resultado = array1[array1.Count - 1] - array2[array2.Count - 1];

            Console.WriteLine(resultado);
        }
    }
}