using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class ShakeSort
    {
        private void Troca(ref string word1, ref string word2)
        {
            var temp = word1;
            word1 = word2; 
            word2 = temp;
        }

        public string[] Sortear(string[] vetor)
        {
            //for (int i = 0; i < vetor.Length / 2; i++)
            //{
            //    bool flagTroca = false;
            //    // passa da esqueda para a direita
            //    for (int j = i; j < vetor.Length - i; j++)
            //    {
            //        if (string.Compare(vetor[j], vetor[j + 1]) > 0)
            //        {
            //            Troca(ref vetor[j], ref vetor[j + 1]);
            //            flagTroca = true;
            //        }
            //    }

            //    // passa da direita para esquerda
            //    for (int j = vetor.Length - 2 - i; j > i; j--)
            //    {
            //        if (string.Compare(vetor[j - 1], vetor[j]) > 0)
            //        {
            //            Troca(ref vetor[j - 1], ref vetor[j]);
            //            flagTroca = true;
            //        }
            //    }

            //    if (!flagTroca)
            //    {
            //        break;
            //    }
            //}

            string atual, prox;
            int inicioLista = 0, finalLista = vetor.Length - 1;
            bool troca = true;
            while (troca)
            {
                for (int i = inicioLista; i < finalLista; i++)
                {
                    if (string.Compare(vetor[i], vetor[i + 1]) > 0)
                    {
                        atual = vetor[i + 1];
                        prox = vetor[i];
                        Console.WriteLine("->->->->->DIREITA->->->->");
                        Console.WriteLine(
                            "atual   prox\n" +
                            $" {atual}       {prox}\n" +
                            "-------------");
                        vetor[i] = atual;
                        vetor[i + 1] = prox;
                    }
                }
                for (int i = finalLista - 1; i > inicioLista; i--)
                {
                    if (string.Compare(vetor[i], vetor[i - 1]) < 0)
                    {
                        atual = vetor[i - 1];
                        prox = vetor[i];
                        Console.WriteLine("<-<-<-<-<-ESQUERDA<-<-<-<-");
                        Console.WriteLine(
                            "anterior   atual\n" +
                            $" {atual}       {prox}\n" +
                            "-------------");
                        vetor[i - 1] = prox;
                        vetor[i] = atual;
                    }
                }
                inicioLista++;
                finalLista--;
                if (inicioLista >= finalLista)
                {
                    Console.Write("[ " + vetor[0]);
                    for (int i = 1; i < vetor.Length; i++)
                    {
                        Console.Write(", " + vetor[i]);
                    }
                    Console.Write(" ]");
                    troca = false;
                }
            }

            return vetor;
        }
    }
}
