using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milaneze.ComparadorDeStrings.Comum
{
    public class Match : IEqualityComparer<Match>, IEquatable<Match>
    {
        public string Nome1 { get; private set; }
        public string Nome2 { get; private set; }
        public double Porcentagem { get; private set; }
        public bool Igual { get; private set; }

        public Match(string nome1, string nome2, double porcentagem, bool igual)
        {
            Nome1 = nome1;
            Nome2 = nome2;
            Porcentagem = porcentagem;
            Igual = igual;
        }

        public bool Equals(Match x, Match y)
        {
            if (x.Nome1 == y.Nome1)
                if (x.Nome2 == y.Nome2)
                    if (x.Porcentagem == y.Porcentagem)
                        if (x.Igual == y.Igual)
                            return true;

            return false;
        }

        public int GetHashCode(Match obj)
        {
            return obj.GetHashCode();
        }

        public bool Equals(Match other)
        {
            return Equals(this, other);
        }
    }
}
