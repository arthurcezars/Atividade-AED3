using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreBinaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] valores = { 12, 15, 21, 27, 29, 31, 2, 7, 9, 1, -7, -2, 13, 10, 8, 6, 5, 4, 3, 14, 40 };
            Arvore arvore = new Arvore();

            foreach (int val in valores)
            {
                arvore.insere(val);
            }

            int[] preOrder = arvore.getVetorOrdenado(1);
            foreach (int val in preOrder)
            {
                Console.Write($"{val}, ");
            }
            Console.WriteLine();

            int[] posOrder = arvore.getVetorOrdenado(2);
            foreach (int val in posOrder)
            {
                Console.Write($"{val}, ");
            }
            Console.WriteLine();

            int[] inOrder = arvore.getVetorOrdenado(3);
            foreach (int val in inOrder)
            {
                Console.Write($"{val}, ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
