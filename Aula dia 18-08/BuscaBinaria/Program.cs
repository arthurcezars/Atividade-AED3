using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaBinaria
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] vetor = new int[100];

            for (int i = 0; i < vetor.Length; i++)
            {
                vetor[i] = i + 1;
            }

            int inicioExecucao = DateTime.Now.Millisecond;

            int qtd_exec = 0;
            BuscaBinaria(vetor, 0, vetor.Length-1, 80, qtd_exec);

            int fimExecucao = DateTime.Now.Millisecond;


            Console.WriteLine(fimExecucao - inicioExecucao);
            Console.ReadKey();
        }

        private static void BuscaBinaria(int[] vetor, int posInicial, int posFinal, int valor, int qtd_exec)
        {
            qtd_exec++;

            if (posInicial == posFinal)
            {
                Console.WriteLine("Não encontrou!");
                return;
            }

            int meio = (posFinal - posInicial) / 2;

            if (vetor[meio] == valor)
            {
                Console.WriteLine("Encontrou!");
                return;
            }

            if (vetor[meio] < valor)
            {
                BuscaBinaria(vetor, posInicial, meio, valor, qtd_exec);
            }
            else
            {
                BuscaBinaria(vetor, meio, posFinal, valor, qtd_exec);

            }


        }
    }
}
