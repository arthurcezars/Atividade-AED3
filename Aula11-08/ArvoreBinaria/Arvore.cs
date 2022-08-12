using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreBinaria
{
    internal class Arvore
    {
        No raiz = null;
        int tamanhoArvore = 0;

        public void insere(int i)
        {
            if (raiz is null)
            {
                raiz = new No(i);
                tamanhoArvore++;
            } 
            else
            {
                insereSubArvore(i, raiz);
            }
        }

        private void insereSubArvore(int i, No no)
        {
            if (i > no.Valor)
            {
                if (no.NoDireito is null)
                {
                    no.NoDireito = new No(i);
                    tamanhoArvore++;
                }
                else
                {
                    insereSubArvore(i, no.NoDireito);
                }
            }
            else
            {
                if (no.NoEsquerdo is null)
                {
                    no.NoEsquerdo = new No(i);
                    tamanhoArvore++;
                }
                else
                {
                    insereSubArvore(i, no.NoEsquerdo);
                }
            }
        }

        public int[] getVetorOrdenado(int tipoOrdenacao)
        {
            ListaEncadeada lista = new ListaEncadeada();

            switch (tipoOrdenacao)
            {
                case 1:
                    preOrder(lista, raiz);
                    break;
                case 2:
                    posOrder(lista, raiz);
                    break;
                case 3:
                    inOrder(lista, raiz);
                    break;
                default:
                    throw new Exception("O tipo de ordenação escolhido não existe!");
                    break;
            }

            return lista.getVetor();
        }

        private void preOrder(ListaEncadeada lista, No no)
        {
            lista.insere(no.Valor);

            if (no.NoEsquerdo != null)
            {
                preOrder(lista, no.NoEsquerdo);
            }
            
            if (no.NoDireito != null)
            {
                preOrder(lista, no.NoDireito);
            }
        }

        private void posOrder(ListaEncadeada lista, No no)
        {
            if (no.NoEsquerdo != null)
            {
                posOrder(lista, no.NoEsquerdo);
            }
            
            if (no.NoDireito != null)
            {
                posOrder(lista, no.NoDireito);
            }

            lista.insere(no.Valor);
        }

        private void inOrder(ListaEncadeada lista, No no)
        {
            if (no.NoEsquerdo != null)
            {
                inOrder(lista, no.NoEsquerdo);
            }

            lista.insere(no.Valor);

            if (no.NoDireito != null)
            {
                inOrder(lista, no.NoDireito);
            }
        }
    }
}
