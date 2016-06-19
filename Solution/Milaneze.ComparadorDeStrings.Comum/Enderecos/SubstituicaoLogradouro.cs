using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milaneze.ComparadorDeStrings.Comum.Enderecos
{
    public class SubstituicaoLogradouro
    {
        public string De { get; private set; }
        public string Para { get; private set; }

        public SubstituicaoLogradouro(string de, string para)
        {
            De = de;
            Para = para;
        }
    }
}