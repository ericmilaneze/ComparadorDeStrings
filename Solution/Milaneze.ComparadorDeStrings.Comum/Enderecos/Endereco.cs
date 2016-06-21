using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milaneze.ComparadorDeStrings.Comum.Enderecos
{
    public class Endereco
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public Endereco(string logradouro, string numero, string cidade, string estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
        }

        public IMatchEndereco Comparar(Endereco endereco2, IComparadorEndereco comparadorEndereco)
        {
            return comparadorEndereco.Comparar(this, endereco2);
        }
    }
}
