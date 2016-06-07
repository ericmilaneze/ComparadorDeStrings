using Milaneze.ComparadorDeStrings.Comum;
using System;
namespace Milaneze.ComparadorDeStrings.Comum.Enderecos
{
    public interface IMatchEndereco
    {
        /// <summary>
        /// Match da cidade.
        /// </summary>
        Match Cidade { get; set; }

        /// <summary>
        /// Match do estado.
        /// </summary>
        Match Estado { get; set; }

        /// <summary>
        /// Match do logradouro.
        /// </summary>
        Match Logradouro { get; set; }

        /// <summary>
        /// Match parcial do endereço?
        /// </summary>
        bool MatchParcial { get; }

        /// <summary>
        /// Match total do endereço?
        /// </summary>
        bool MatchTotal { get; }

        /// <summary>
        /// Match do número.
        /// </summary>
        Match Numero { get; set; }
    }
}
