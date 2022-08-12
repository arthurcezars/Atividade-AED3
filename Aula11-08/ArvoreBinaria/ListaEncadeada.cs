using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreBinaria
{
    internal class ListaEncadeada
    {
        No headLista = null;
        int tamanhoLista = 0;

        public void insere(int i)
        {
            if (headLista is null)
            {
                headLista = new No(i);
                tamanhoLista++; 
            }
            else
            {
                insereNovoNo(i, headLista);
            }
        }

        private void insereNovoNo(int i, No no)
        {
            if (no.NoDireito is null)
            {
                no.NoDireito = new No(i);
                tamanhoLista++;
            }
            else
            {
                insereNovoNo(i, no.NoDireito);
            }
        }

        public int[] getVetor()
        {
            if (headLista is null)
            {
                throw new Exception("A lista não possui nenhum nó!");
            }
            else
            {
                No noAtual = headLista;
                int[] result = new int[tamanhoLista];

                for (int i = 0; i < tamanhoLista; i++)
                {
                    result[i] = noAtual.Valor;

                    if (noAtual.NoDireito is null)
                    {
                        break;
                    }

                    noAtual = noAtual.NoDireito;
                }

                return result;
            }
        }
    }
}
