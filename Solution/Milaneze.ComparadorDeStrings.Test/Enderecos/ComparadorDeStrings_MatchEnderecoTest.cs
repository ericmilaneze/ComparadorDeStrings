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
                Cidade = new Match() { Igual = true },
                Estado = new Match() { Igual = true },
                Logradouro = new Match() { Igual = true },
                Numero = new Match() { Igual = true }
            };

            Assert.IsTrue(matchEndereco.MatchTotal);
        }

        [TestMethod]
        public void ComparadorDeStrings_MatchEndereco_MatchTotal_NaoOk()
        {
            IMatchEndereco matchEndereco = new MatchEndereco()
            {
                Cidade = new Match() { Igual = true },
                Estado = new Match() { Igual = true },
                Logradouro = new Match() { Igual = true },
                Numero = new Match() { Igual = false }
            };

            Assert.IsFalse(matchEndereco.MatchTotal);
        }

        [TestMethod]
        public void ComparadorDeStrings_MatchEndereco_MatchParcial_Ok()
        {
            IMatchEndereco matchEndereco = new MatchEndereco()
            {
                Cidade = new Match() { Igual = true },
                Estado = new Match() { Igual = true },
                Logradouro = new Match() { Igual = true },
                Numero = new Match() { Igual = true }
            };

            Assert.IsTrue(matchEndereco.MatchParcial);
        }

        [TestMethod]
        public void ComparadorDeStrings_MatchEndereco_MatchParcial_OkParcial()
        {
            IMatchEndereco matchEndereco = new MatchEndereco()
            {
                Cidade = new Match() { Igual = true },
                Estado = new Match() { Igual = true },
                Logradouro = new Match() { Igual = true },
                Numero = new Match() { Igual = false }
            };

            Assert.IsTrue(matchEndereco.MatchParcial);
        }

        [TestMethod]
        public void ComparadorDeStrings_MatchEndereco_MatchParcial_NaoOkParcial()
        {
            IMatchEndereco matchEndereco = new MatchEndereco()
            {
                Cidade = new Match() { Igual = true },
                Estado = new Match() { Igual = false },
                Logradouro = new Match() { Igual = true },
                Numero = new Match() { Igual = false }
            };

            Assert.IsFalse(matchEndereco.MatchParcial);
        }
    }
}
