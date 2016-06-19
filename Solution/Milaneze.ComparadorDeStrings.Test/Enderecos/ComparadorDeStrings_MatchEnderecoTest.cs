using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Milaneze.ComparadorDeStrings.Comum.Enderecos;
using Milaneze.ComparadorDeStrings.Enderecos;
using Milaneze.ComparadorDeStrings.Comum;

namespace Milaneze.ComparadorDeStrings.Test.Enderecos
{
    [TestClass]
    public class ComparadorDeStrings_MatchEnderecoTest
    {
        [TestMethod]
        public void ComparadorDeStrings_MatchEndereco_MatchTotal_Ok()
        {
            IMatchEndereco matchEndereco = new MatchEndereco()
            {
                Cidade = new Match(nome1: null, nome2: null, porcentagem: 0, igual: true),
                Estado = new Match(nome1: null, nome2: null, porcentagem: 0, igual: true),
                Logradouro = new Match(nome1: null, nome2: null, porcentagem: 0, igual: true),
                Numero = new Match(nome1: null, nome2: null, porcentagem: 0, igual: true)
            };

            Assert.IsTrue(matchEndereco.MatchTotal);
        }

        [TestMethod]
        public void ComparadorDeStrings_MatchEndereco_MatchTotal_NaoOk()
        {
            IMatchEndereco matchEndereco = new MatchEndereco()
            {
                Cidade = new Match(nome1: null, nome2: null, porcentagem: 0, igual: true),
                Estado = new Match(nome1: null, nome2: null, porcentagem: 0, igual: true),
                Logradouro = new Match(nome1: null, nome2: null, porcentagem: 0, igual: true),
                Numero = new Match(nome1: null, nome2: null, porcentagem: 0, igual: false)
            };

            Assert.IsFalse(matchEndereco.MatchTotal);
        }

        [TestMethod]
        public void ComparadorDeStrings_MatchEndereco_MatchParcial_Ok()
        {
            IMatchEndereco matchEndereco = new MatchEndereco()
            {
                Cidade = new Match(nome1: null, nome2: null, porcentagem: 0, igual: true),
                Estado = new Match(nome1: null, nome2: null, porcentagem: 0, igual: true),
                Logradouro = new Match(nome1: null, nome2: null, porcentagem: 0, igual: true),
                Numero = new Match(nome1: null, nome2: null, porcentagem: 0, igual: true)
            };

            Assert.IsTrue(matchEndereco.MatchParcial);
        }

        [TestMethod]
        public void ComparadorDeStrings_MatchEndereco_MatchParcial_OkParcial()
        {
            IMatchEndereco matchEndereco = new MatchEndereco()
            {
                Cidade = new Match(nome1: null, nome2: null, porcentagem: 0, igual: true),
                Estado = new Match(nome1: null, nome2: null, porcentagem: 0, igual: true),
                Logradouro = new Match(nome1: null, nome2: null, porcentagem: 0, igual: true),
                Numero = new Match(nome1: null, nome2: null, porcentagem: 0, igual: false)
            };

            Assert.IsTrue(matchEndereco.MatchParcial);
        }

        [TestMethod]
        public void ComparadorDeStrings_MatchEndereco_MatchParcial_NaoOkParcial()
        {
            IMatchEndereco matchEndereco = new MatchEndereco()
            {
                Cidade = new Match(nome1: null, nome2: null, porcentagem: 0, igual: true),
                Estado = new Match(nome1: null, nome2: null, porcentagem: 0, igual: false),
                Logradouro = new Match(nome1: null, nome2: null, porcentagem: 0, igual: true),
                Numero = new Match(nome1: null, nome2: null, porcentagem: 0, igual: false)
            };

            Assert.IsFalse(matchEndereco.MatchParcial);
        }
    }
}
