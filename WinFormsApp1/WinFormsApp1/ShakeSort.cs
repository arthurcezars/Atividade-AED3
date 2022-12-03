using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class ShakeSort
    {
        public string[] Sortear(string[] vetor)
        {
            string atual, prox;
            int inicioLista = 0, finalLista = vetor.Length - 1;
            bool trocou = true;
            while (trocou)
            {
                trocou = false;
                for (int i = inicioLista; i < finalLista; i++)
                {
                    if (string.Compare(vetor[i], vetor[i + 1]) > 0)
                    {
                        atual = vetor[i + 1];
                        prox = vetor[i];
                        vetor[i] = atual;
                        vetor[i + 1] = prox;
                        trocou = true;
                    }
                }
                for (int i = finalLista - 1; i > inicioLista; i--)
                {
                    if (string.Compare(vetor[i], vetor[i - 1]) < 0)
                    {
                        atual = vetor[i - 1];
                        prox = vetor[i];
                        vetor[i - 1] = prox;
                        vetor[i] = atual;
                        trocou = true;
                    }
                }

                if (!trocou)
                {
                    Console.Write("[ " + vetor[0]);
                    for (int i = 1; i < vetor.Length; i++)
                    {
                        Console.Write(", " + vetor[i]);
                    }
                    Console.Write(" ]");
                    break;
                }

                finalLista--;
                inicioLista++;
            }

            return vetor;
        }
    }
}
