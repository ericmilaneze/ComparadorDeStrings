using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milaneze.ComparadorDeStrings.Comum
{
    public class Match : IEqualityComparer<Match>, IEquatable<Match>
    {
        public string Nome1 { get; set; }
        public string Nome2 { get; set; }
        public double Porcentagem { get; set; }
        public bool Igual { get; set; }

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
