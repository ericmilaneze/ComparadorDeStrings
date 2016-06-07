using Milaneze.ComparadorDeStrings.Comum;
using Milaneze.ComparadorDeStrings.Comum.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milaneze.ComparadorDeStrings.Enderecos
{
    public class MatchEndereco : IMatchEndereco
    {
        public Match Logradouro { get; set; }
        public Match Numero { get; set; }
        public Match Cidade { get; set; }
        public Match Estado { get; set; }

        public bool MatchTotal 
        {
            get
            {
                if(Logradouro != null)
                    if(Numero != null)
                        if(Cidade != null)
                            if(Estado != null)
                                if (Logradouro.Igual && Numero.Igual && Cidade.Igual && Estado.Igual)
                                    return true;

                return false;
            }
        }

        public bool MatchParcial
        {
            get
            {
                if (Logradouro != null)
                    if(Cidade != null)
                        if(Estado != null)
                            if (Logradouro.Igual)
                                if(Cidade.Igual)
                                    if(Estado.Igual)
                                        return true;

                return false;
            }
        }
    }
}
