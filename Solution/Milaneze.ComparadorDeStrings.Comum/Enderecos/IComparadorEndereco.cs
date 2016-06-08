using System;
using System.Collections.Generic;

namespace Milaneze.ComparadorDeStrings.Comum.Enderecos
{
    public interface IComparadorEndereco
    {
        /// <summary>
        /// Porcentagem mínima para considerar o match das cidades.
        /// </summary>
        double PorcentagemMinimaMatchCidade { get; set; }

        /// <summary>
        /// Porcentagem mínima para considerar o match dos logradouros.
        /// </summary>
        double PorcentagemMinimaMatchLogradouro { get; set; }

        /// <summary>
        /// Lista de substituições para os logradouros.
        /// Exemplo: "Doutor" para "Dr."
        /// </summary>
        IList<SubstituicaoLogradouro> SubstituicoesLogradouro { get; set; }

        /// <summary>
        /// Compara dois endereços.
        /// </summary>
        /// <param name="endereco1">Endereço 1.</param>
        /// <param name="endereco2">Endereço 2.</param>
        /// <param name="matchEndereco">Resultado da comparação entre ambos.</param>
        void Comparar(Endereco endereco1, Endereco endereco2, IMatchEndereco matchEndereco);

        /// <summary>
        /// Compara dois nomes de cidades.
        /// </summary>
        /// <param name="cidade1">Cidade 1.</param>
        /// <param name="cidade2">Cidade 2.</param>
        /// <returns>Porcentagem de match.</returns>
        double CompararCidade(string cidade1, string cidade2);

        /// <summary>
        /// Compara dois nomes de cidades.
        /// </summary>
        /// <param name="cidade1">Cidade 1.</param>
        /// <param name="cidade2">Cidade 2.</param>
        Match CompararCidadeMatch(string cidade1, string cidade2);

        /// <summary>
        /// Compara dois nomes de estados.
        /// </summary>
        /// <param name="estado1">Estado 1.</param>
        /// <param name="estado2">Estado 2.</param>
        Match CompararEstadoMatch(string estado1, string estado2);

        /// <summary>
        /// Compara dois logradouros.
        /// </summary>
        /// <param name="logradouro1">Logradouro 1.</param>
        /// <param name="logradouro2">Logradouro 2.</param>
        /// <returns>Porcentagem de match.</returns>
        double CompararLogradouro(string logradouro1, string logradouro2);

        /// <summary>
        /// Compara dois logradouros.
        /// </summary>
        /// <param name="logradouro1">Logradouro 1.</param>
        /// <param name="logradouro2">Logradouro 2.</param>
        Match CompararLogradouroMatch(string logradouro1, string logradouro2);

        /// <summary>
        /// Compara dois números de logradouro.
        /// </summary>
        /// <param name="numero1">Número 1.</param>
        /// <param name="numero2">Número 2.</param>
        Match CompararNumeroMatch(string numero1, string numero2);

        /// <summary>
        /// As duas cidades são a mesma?
        /// </summary>
        /// <param name="cidade1">Cidade 1.</param>
        /// <param name="cidade2">Cidade 2.</param>
        bool IsCidadeIgual(string cidade1, string cidade2);

        /// <summary>
        /// As duas cidades são a mesma?
        /// </summary>
        /// <param name="cidade1">Cidade 1.</param>
        /// <param name="cidade2">Cidade 2.</param>
        /// <param name="porcentagemMinimaMatchCidade">Porcentagem mínima para que seja considerado match.</param>
        bool IsCidadeIgual(string cidade1, string cidade2, double porcentagemMinimaMatchCidade);

        /// <summary>
        /// Os dois estados são o mesmo?
        /// </summary>
        /// <param name="estado1">Estado 1.</param>
        /// <param name="estado2">Estado 2.</param>
        bool IsEstadoIgual(string estado1, string estado2);

        /// <summary>
        /// Os dois logradouros são o mesmo?
        /// </summary>
        /// <param name="logradouro1">Logradouro 1.</param>
        /// <param name="logradouro2">Logradouro 2.</param>
        bool IsLogradouroIgual(string logradouro1, string logradouro2);

        /// <summary>
        /// Os dois logradouros são o mesmo?
        /// </summary>
        /// <param name="logradouro1">Logradouro 1.</param>
        /// <param name="logradouro2">Logradouro 2.</param>
        /// <param name="porcentagemMinimaMatchCidade">Porcentagem mínima para que seja considerado match.</param>
        bool IsLogradouroIgual(string logradouro1, string logradouro2, double porcentagemMinimaMatchLogradouro);

        /// <summary>
        /// Os dois números são o mesmo?
        /// </summary>
        /// <param name="numero1">Número 1.</param>
        /// <param name="numero2">Número 2.</param>
        bool IsNumeroIgual(string numero1, string numero2);
    }
}