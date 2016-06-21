using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Milaneze.ComparadorDeStrings.Comum.Enderecos;
using Milaneze.ComparadorDeStrings.Enderecos;

namespace Milaneze.ComparadorDeStrings.Test.Enderecos
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ComparadorDeStrings_Comum_Endereco
    {
        private static IComparadorEndereco getComparadorEndereco()
        {
            IComparadorEndereco comparadorEndereco = new ComparadorEndereco();
            comparadorEndereco.PorcentagemMinimaMatchLogradouro = 70;
            comparadorEndereco.PorcentagemMinimaMatchCidade = 80;
            comparadorEndereco.SubstituicoesLogradouro = new List<SubstituicaoLogradouro>()
            {
                new SubstituicaoLogradouro(
                    de: "avenida",
                    para: "av"),

                new SubstituicaoLogradouro(
                    de: "praça",
                    para: "pc"),

                new SubstituicaoLogradouro(
                    de: "rua",
                    para: "r"),

                new SubstituicaoLogradouro(
                    de: "engenheiro",
                    para: "eng")
            };

            return comparadorEndereco;
        }

        [TestMethod]
        public void Endereco_Comparar_Ok()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            Endereco endereco1 = new Endereco(
                logradouro: "Praça Amarildo Pereira",
                numero: "8",
                cidade: "São Paulo",
                estado: "SP");

            Endereco endereco2 = new Endereco(
                logradouro: "Pc Amarildo Pereira",
                numero: "08",
                cidade: "sao paulo",
                estado: "sp");

            IMatchEndereco matchEndereco = endereco1.Comparar(endereco2, comparadorEndereco);

            Assert.IsTrue(matchEndereco.MatchParcial && matchEndereco.MatchTotal);
        }

        [TestMethod]
        public void Endereco_Comparar_NaoOk()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            Endereco endereco1 = new Endereco(
                logradouro: "Praça Amarildo Pereira",
                numero: "8",
                cidade: "São Paulo",
                estado: "SP");

            Endereco endereco2 = new Endereco(
                logradouro: "Pc Amarildo Pereira",
                numero: "08",
                cidade: "sao paulo",
                estado: "sp");

            IMatchEndereco matchEndereco = endereco1.Comparar(endereco2, comparadorEndereco);

            Assert.IsTrue(matchEndereco.MatchParcial && matchEndereco.MatchTotal);
        }
    }
}
