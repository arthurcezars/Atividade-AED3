using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreBinaria
{
    internal class No
    {
		private int _valor;

		public int Valor
		{
			get { return _valor; }
			set { _valor = value; }
		}

		private No _noDireito;

		public No NoDireito
		{
			get { return _noDireito; }
			set { _noDireito = value; }
		}

		private No _noEsquerdo;

		public No NoEsquerdo
		{
			get { return _noEsquerdo; }
			set { _noEsquerdo = value; }
		}

		public No(int valor)
		{
			_valor = valor;	
		}

	}
}
