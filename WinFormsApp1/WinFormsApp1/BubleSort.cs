using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class BubleSort
    {
        public string[] Sortear(string[] vetor)
        {
            bool trocou;
            do
            {
                trocou = false;
                for (int i = 0; i < vetor.Length - 1; i++)
                {
                    string p1 = vetor[i].ToLower();
                    string p2 = vetor[i + 1].ToLower();
                    if (string.Compare(p1, p2) == 1)
                    {
                        vetor[i] = p2;
                        vetor[i + 1] = p1;
                        trocou = true;
                    }
                }
            } while (trocou);
            return vetor;
        }
    }
}
