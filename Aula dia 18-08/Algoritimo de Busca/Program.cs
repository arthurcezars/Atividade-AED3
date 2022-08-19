using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaSequencial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            buscaSequencial(10000000, 999999383);
            Console.ReadKey();
        }

        private static void buscaSequencial(int tam, int pos)
        {
            int[] vetor = new int[tam];

            for (int i = 0; i < vetor.Length; i++)
            {
                vetor[i] = i + 1;
            }

            int inicioExecucao = DateTime.Now.Millisecond;

            int qtd_exec = 0;
            for (int i = 0; i < vetor.Length; i++)
            {
                qtd_exec++;
                if (vetor[i] == pos)
                {
                    break;
                }
            }

            int fimExecucao = DateTime.Now.Millisecond;


            Console.WriteLine(fimExecucao - inicioExecucao);

            Console.WriteLine(qtd_exec);
        }
    }
}
