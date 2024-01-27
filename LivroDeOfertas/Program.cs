using System;
using System.Globalization;

namespace LivroOfertas
{
    class Program
    {
        static void Main(string[] args)
        {
            int qtdModificoes;
            Livro[] livros = new Livro[0];
            qtdModificoes = int.Parse(Console.ReadLine());

            for (int i = 0; i < qtdModificoes; i++)
            {
                string[] notificacao = Console.ReadLine().Split(',');
                int posicao = int.Parse(notificacao[0]);
                int acao = int.Parse(notificacao[1]);
                double valor = double.Parse(notificacao[2], CultureInfo.InvariantCulture);
                int quantidade = int.Parse(notificacao[3]);

                livros = Crud(livros, posicao, acao, valor, quantidade);
            }

            Console.WriteLine("\nrepresentação do resultado");
            for(int i = 0; i < livros.Length; i++)
            {
                if(i < livros.Length - 1)
                    Console.WriteLine(livros[i]);
                else
                    Console.WriteLine($"{livros[i]}\\");
            }
        }

        private static Livro[] Crud(Livro[] livros, int posicao, int acao, double valor, int quantidade)
        {
            if (acao == 0)
            {
                return InserirOferta(livros, posicao, valor, quantidade);
            }
            else if (acao == 1)
            {
                return ModificarOferta(livros, posicao, valor, quantidade);
            }
            else if (acao == 2)
            {
                return RemoverOferta(livros, posicao);
            }
            else
            {
                Console.WriteLine("Ação inválida.");
                return livros;
            }
        }

        private static Livro[] InserirOferta(Livro[] livroDeOfertas, int posicao, double valor, int quantidade)
        {
            if (posicao != 1 && posicao == livroDeOfertas[livroDeOfertas.Length - 1].Posicao)
            {
                ModificarOferta(livroDeOfertas, posicao, valor, quantidade);
                return livroDeOfertas;
            }

            Livro novaOferta = new Livro(posicao, valor, quantidade);

            Array.Resize(ref livroDeOfertas, livroDeOfertas.Length + 1);
            livroDeOfertas[livroDeOfertas.Length - 1] = novaOferta;

            return livroDeOfertas;
        }

        private static Livro[] ModificarOferta(Livro[] livroDeOfertas, int posicao, double valor, int quantidade)
        {
            int index = Array.FindIndex(livroDeOfertas, oferta => oferta.Posicao == posicao);

            if (index != -1)
            {
                if (valor != 0)
                    livroDeOfertas[index].Valor = valor;
                if (quantidade != 0)
                    livroDeOfertas[index].Quantidade = quantidade;
            }

            return livroDeOfertas;
        }

        static Livro[] RemoverOferta(Livro[] livroDeOfertas, int posicao)
        {
            if (posicao != 1 && posicao > livroDeOfertas[livroDeOfertas.Length - 1].Posicao)
            {
                return livroDeOfertas;
            }

            Livro[] novoVetor = new Livro[livroDeOfertas.Length - 1];

            if (posicao == 1)
            {
                for (int i = 1; i <= livroDeOfertas.Length - 1; i++)
                {
                    Livro novaOferta = new Livro(i, livroDeOfertas[i].Valor, livroDeOfertas[i].Quantidade);
                    novoVetor[i - 1] = novaOferta;
                }
            }
            else
            {
                for (int i = 0; i <= posicao - 2; i++)
                {
                    Livro novaOferta = new Livro(i, livroDeOfertas[i].Valor, livroDeOfertas[i].Quantidade);
                    novoVetor[i] = novaOferta;
                }
                for (int i = posicao; i < posicao; i++)
                {
                    Livro novaOferta = new Livro(i, livroDeOfertas[i].Valor, livroDeOfertas[i].Quantidade);
                    novoVetor[i] = novaOferta;
                }
            }

            livroDeOfertas = novoVetor;

            return livroDeOfertas;
        }

        class Livro
        {
            public int Posicao { get; set; }
            public double Valor { get; set; }
            public int Quantidade { get; set; }

            public Livro(int posicao, double valor, int quantidade)
            {
                Posicao = posicao;
                Valor = valor;
                Quantidade = quantidade;
            }

            public override string ToString()
            {
                return $"{Posicao}, {Valor.ToString(CultureInfo.InvariantCulture)}, {Quantidade}";
            }
        }
    }
}