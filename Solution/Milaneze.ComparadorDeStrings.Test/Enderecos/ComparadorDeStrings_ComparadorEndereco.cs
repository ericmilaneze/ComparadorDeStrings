using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Milaneze.ComparadorDeStrings.Comum.Enderecos;
using Milaneze.ComparadorDeStrings.Enderecos;
using System.Collections.Generic;
using Milaneze.ComparadorDeStrings.Comum;
using System.Linq;

namespace Milaneze.ComparadorDeStrings.Test.Enderecos
{
    [TestClass]
    public class ComparadorDeStrings_ComparadorEndereco
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
        public void ComparadorDeStrings_111()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = "Rua 24 de Fevereiro";
            string logradouro2 = "R vinte e quatro de Fevereiro";

            double resultado = comparadorEndereco.CompararLogradouro(logradouro1, logradouro2);
            double esperado = 100;

            Assert.AreEqual<double>(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_Construtor01()
        {
            IComparadorEndereco comparadorEndereco = new ComparadorEndereco();

            Assert.IsTrue(
                comparadorEndereco.PorcentagemMinimaMatchCidade == 100 &&
                comparadorEndereco.PorcentagemMinimaMatchLogradouro == 100 &&
                comparadorEndereco.SubstituicoesLogradouro == null
                );
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_Construtor02()
        {
            IComparadorEndereco comparadorEndereco = new ComparadorEndereco(80);

            Assert.IsTrue(
                comparadorEndereco.PorcentagemMinimaMatchCidade == 100 &&
                comparadorEndereco.PorcentagemMinimaMatchLogradouro == 80 &&
                comparadorEndereco.SubstituicoesLogradouro == null
                );
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_Construtor03()
        {
            IComparadorEndereco comparadorEndereco = new ComparadorEndereco(70, 80);

            Assert.IsTrue(
                comparadorEndereco.PorcentagemMinimaMatchCidade == 80 &&
                comparadorEndereco.PorcentagemMinimaMatchLogradouro == 70 &&
                comparadorEndereco.SubstituicoesLogradouro == null
                );
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_Construtor04()
        {
            IComparadorEndereco comparadorEndereco = new ComparadorEndereco(70, 80, new List<SubstituicaoLogradouro>());

            Assert.IsTrue(
                comparadorEndereco.PorcentagemMinimaMatchCidade == 80 &&
                comparadorEndereco.PorcentagemMinimaMatchLogradouro == 70 &&
                comparadorEndereco.SubstituicoesLogradouro != null
                );
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_Construtor05()
        {
            IComparadorEndereco comparadorEndereco = new ComparadorEndereco(new List<SubstituicaoLogradouro>());

            Assert.IsTrue(
                comparadorEndereco.PorcentagemMinimaMatchCidade == 100 &&
                comparadorEndereco.PorcentagemMinimaMatchLogradouro == 100 &&
                comparadorEndereco.SubstituicoesLogradouro != null
                );
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_CompararLogradouro_Ok100Porcento()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = "Praça Amarildo Pereira";
            string logradouro2 = "Pc Amarildo Pereira";

            double resultado = comparadorEndereco.CompararLogradouro(logradouro1, logradouro2);
            double esperado = 100;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_CompararLogradouro_Ok100PorcentoComNumero()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = "Avenida 13 de Maio";
            string logradouro2 = "av treze de maio";

            double resultado = comparadorEndereco.CompararLogradouro(logradouro1, logradouro2);
            double esperado = 100;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_CompararLogradouro_Ok100PorcentoComNumero5()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = "av cento e cinco";
            string logradouro2 = "Avenida 105";

            double resultado = comparadorEndereco.CompararLogradouro(logradouro1, logradouro2);
            double esperado = 100;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_CompararLogradouro_Ok100PorcentoComNumero2()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = "Avenida 9 de Julho";
            string logradouro2 = "av nove de julho";

            double resultado = comparadorEndereco.CompararLogradouro(logradouro1, logradouro2);
            double esperado = 100;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_CompararLogradouro_Ok100PorcentoComNumero3()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = "Avenida 23 de Maio";
            string logradouro2 = "av vinte e três de maio";

            double resultado = comparadorEndereco.CompararLogradouro(logradouro1, logradouro2);
            double esperado = 100;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_CompararLogradouro_Ok100PorcentoComNumero4()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = "Rua João 23";
            string logradouro2 = "r joao vinte e tres";

            double resultado = comparadorEndereco.CompararLogradouro(logradouro1, logradouro2);
            double esperado = 100;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_CompararLogradouro_OkNao100Porcento()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = "Praça Amarildo Pereira";
            string logradouro2 = "Pc Amarildo Perera";

            double resultado = comparadorEndereco.CompararLogradouro(logradouro1, logradouro2);
            double minimoEsperado = 70;

            Assert.IsTrue(resultado >= minimoEsperado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_CompararLogradouro_NaoOk()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = "Praça Amarildo Pereira";
            string logradouro2 = "Pc Amaro Perera";

            double resultado = comparadorEndereco.CompararLogradouro(logradouro1, logradouro2);
            double minimoEsperado = 70;

            Assert.IsFalse(resultado >= minimoEsperado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_CompararLogradouro_Nulo()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = null;
            string logradouro2 = "Pc Franco da Gata";

            double resultado = comparadorEndereco.CompararLogradouro(logradouro1, logradouro2);
            double esperado = 0;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_IsLogradouroIgual_NaoOk()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = "Praça Amarildo Pereira";
            string logradouro2 = "Pc Amaro Perera";

            bool resultado = comparadorEndereco.IsLogradouroIgual(logradouro1, logradouro2);
            bool esperado = false;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_IsLogradouroIgual_OkLogradouroParcial()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = "Praça Amarildo Pereira";
            string logradouro2 = "Pc Amaro Pereira";

            bool resultado = comparadorEndereco.IsLogradouroIgual(logradouro1, logradouro2);
            bool esperado = true;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_IsLogradouroIgual_OkLogradouroComAcento()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = "Praça João Mendes";
            string logradouro2 = "Pc Joao Mendes";

            bool resultado = comparadorEndereco.IsLogradouroIgual(logradouro1, logradouro2);
            bool esperado = true;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_IsLogradouroIgual_Ok()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = "Praça Amarildo Pereira";
            string logradouro2 = "Pc Amarildo Pereira";

            bool resultado = comparadorEndereco.IsLogradouroIgual(logradouro1, logradouro2);
            bool esperado = true;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_IsLogradouroIgual_DefinirPorcentagemMinima_Ok()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = "Praça Amarildo Pereira";
            string logradouro2 = "Pc Amarildo Pereira";

            bool resultado = comparadorEndereco.IsLogradouroIgual(logradouro1, logradouro2, 90);
            bool esperado = true;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_IsLogradouroIgual_DefinirPorcentagemMinima_NaoOk()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = "Praça Amarildo Pereira";
            string logradouro2 = "Pc Amarelinho Pereirinho";

            bool resultado = comparadorEndereco.IsLogradouroIgual(logradouro1, logradouro2, 65);
            bool esperado = false;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_IsNumeroIgual_Nulo()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = null;
            string numero2 = "25";

            bool resultado = comparadorEndereco.IsNumeroIgual(numero1, numero2);
            bool esperado = false;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_IsNumeroIgual_SemNumeroAmbos()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "SN";
            string numero2 = "SN";

            bool resultado = comparadorEndereco.IsNumeroIgual(numero1, numero2);
            bool esperado = true;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_IsNumeroIgual_SemNumeroUmSo()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "SN";
            string numero2 = "25";

            bool resultado = comparadorEndereco.IsNumeroIgual(numero1, numero2);
            bool esperado = false;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_IsNumeroIgual_NaoNumerico1()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "ABC";
            string numero2 = "25";

            bool resultado = comparadorEndereco.IsNumeroIgual(numero1, numero2);
            bool esperado = false;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_IsNumeroIgual_NaoNumerico2()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "25";
            string numero2 = "ABC";

            bool resultado = comparadorEndereco.IsNumeroIgual(numero1, numero2);
            bool esperado = false;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_IsNumeroIgual_NaoNumericoAmbos()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "ABC";
            string numero2 = "ABC";

            bool resultado = comparadorEndereco.IsNumeroIgual(numero1, numero2);
            bool esperado = false;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_IsNumeroIgual_NumerosDiferentes()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "25";
            string numero2 = "26";

            bool resultado = comparadorEndereco.IsNumeroIgual(numero1, numero2);
            bool esperado = false;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_IsNumeroIgual_NumerosIguais()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "25";
            string numero2 = "25";

            bool resultado = comparadorEndereco.IsNumeroIgual(numero1, numero2);
            bool esperado = true;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_CompararCidade_IsNumeroIgual_NumerosIguais()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "25";
            string numero2 = "25";

            bool resultado = comparadorEndereco.IsNumeroIgual(numero1, numero2);
            bool esperado = true;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_CompararCidade_Nulo()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = null;
            string numero2 = "São Paulo";

            double resultado = comparadorEndereco.CompararCidade(numero1, numero2);
            double esperado = 0;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_CompararCidade_Iguais()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "São Paulo";
            string numero2 = "São Paulo";

            double resultado = comparadorEndereco.CompararCidade(numero1, numero2);
            double esperado = 100;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_CompararCidade_IgualComAcentoEMinusculo()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "Sao paulo";
            string numero2 = "São Paulo";

            double resultado = comparadorEndereco.CompararCidade(numero1, numero2);
            double esperado = 100;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_CompararCidade_Parecido()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "Sao paulo";
            string numero2 = "Sam Paulo";

            double resultado = comparadorEndereco.CompararCidade(numero1, numero2);
            double minimoEsperado = 80;

            Assert.IsTrue(resultado >= minimoEsperado);
        }

        [TestMethod]
        public void ComparadorDeStrings_CompararCidade_Diferente()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "Sao paulo";
            string numero2 = "São José";

            double resultado = comparadorEndereco.CompararCidade(numero1, numero2);
            double minimoEsperado = 80;

            Assert.IsFalse(resultado >= minimoEsperado);
        }

        [TestMethod]
        public void ComparadorDeStrings_IsCidadeIgual_Igual()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "sao paulo";
            string numero2 = "São Paulo";

            bool resultado = comparadorEndereco.IsCidadeIgual(numero1, numero2);
            bool esperado = true;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_IsCidadeIgual_Parecido()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "sam paulo";
            string numero2 = "São Paulo";

            bool resultado = comparadorEndereco.IsCidadeIgual(numero1, numero2);
            bool esperado = true;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_IsCidadeIgual_Diferente()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "san jose";
            string numero2 = "São Paulo";

            bool resultado = comparadorEndereco.IsCidadeIgual(numero1, numero2);
            bool esperado = false;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_IsCidadeIgual_ForcandoIgualdade()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "san jose";
            string numero2 = "São Paulo";

            bool resultado = comparadorEndereco.IsCidadeIgual(numero1, numero2, 18);
            bool esperado = true;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_IsEstadoIgual_Igual()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "RJ";
            string numero2 = "RJ";

            bool resultado = comparadorEndereco.IsEstadoIgual(numero1, numero2);
            bool esperado = true;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_IsEstadoIgual_Diferente()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = "RO";
            string numero2 = "RJ";

            bool resultado = comparadorEndereco.IsEstadoIgual(numero1, numero2);
            bool esperado = false;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_IsEstadoIgual_Nulo()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string numero1 = null;
            string numero2 = "RJ";

            bool resultado = comparadorEndereco.IsEstadoIgual(numero1, numero2);
            bool esperado = false;

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ComparadorDeStrings_CompararLogradouroMatch_Igual()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            Match matchEsperado = new Match(
                nome1: "Praça Amarildo Pereira",
                nome2: "pc Amarildo Pereira",
                igual: true,
                porcentagem: 100);

            Match resultado = comparadorEndereco.CompararLogradouroMatch(matchEsperado.Nome1, matchEsperado.Nome2);

            Assert.IsTrue(matchEsperado.Equals(resultado));
        }

        [TestMethod]
        public void ComparadorDeStrings_CompararLogradouroMatch_Diferente()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            Match matchEsperado = new Match(
                nome1: "Praça Amarildo Pereira",
                nome2: "pc chico da garça",
                igual: false,
                porcentagem: 70);

            Match resultado = comparadorEndereco.CompararLogradouroMatch(matchEsperado.Nome1, matchEsperado.Nome2);

            Assert.IsTrue(
                matchEsperado.Nome1 == resultado.Nome1 && 
                matchEsperado.Nome2 == resultado.Nome2 && 
                matchEsperado.Igual == matchEsperado.Igual
                );
        }

        [TestMethod]
        public void ComparadorDeStrings_CompararNumeroMatch_Igual()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            Match matchEsperado = new Match(
                nome1: "25",
                nome2: "25",
                igual: true,
                porcentagem: 100);

            Match resultado = comparadorEndereco.CompararNumeroMatch(matchEsperado.Nome1, matchEsperado.Nome2);

            Assert.IsTrue(matchEsperado.Equals(resultado));
        }

        [TestMethod]
        public void ComparadorDeStrings_CompararNumeroMatch_Diferente()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            Match matchEsperado = new Match(
                nome1: "28",
                nome2: "25",
                igual: false,
                porcentagem: 0);

            Match resultado = comparadorEndereco.CompararNumeroMatch(matchEsperado.Nome1, matchEsperado.Nome2);

            Assert.IsTrue(matchEsperado.Equals(resultado));
        }

        [TestMethod]
        public void ComparadorDeStrings_CompararCidadeMatch_Igual()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            Match matchEsperado = new Match(
                nome1: "Belo Horizonte",
                nome2: "belo horizonte",
                igual: true,
                porcentagem: 100);

            Match resultado = comparadorEndereco.CompararCidadeMatch(matchEsperado.Nome1, matchEsperado.Nome2);

            Assert.IsTrue(matchEsperado.Equals(resultado));
        }

        [TestMethod]
        public void ComparadorDeStrings_CompararCidadeMatch_Diferente()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            Match matchEsperado = new Match(
                nome1: "Belo Horizonte",
                nome2: "Rio de Janeiro",
                igual: false,
                porcentagem: 70);

            Match resultado = comparadorEndereco.CompararCidadeMatch(matchEsperado.Nome1, matchEsperado.Nome2);

            Assert.IsTrue(
                matchEsperado.Nome1 == resultado.Nome1 &&
                matchEsperado.Nome2 == resultado.Nome2 &&
                matchEsperado.Igual == matchEsperado.Igual
                );
        }

        [TestMethod]
        public void ComparadorDeStrings_CompararEstadoMatch_Igual()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            Match matchEsperado = new Match(
                nome1: "MG",
                nome2: "mg",
                igual: true,
                porcentagem: 100);

            Match resultado = comparadorEndereco.CompararEstadoMatch(matchEsperado.Nome1, matchEsperado.Nome2);

            Assert.IsTrue(matchEsperado.Equals(resultado));
        }

        [TestMethod]
        public void ComparadorDeStrings_CompararEstadoMatch_Diferente()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            Match matchEsperado = new Match(
                nome1: "MG",
                nome2: "rj",
                igual: false,
                porcentagem: 0);

            Match resultado = comparadorEndereco.CompararEstadoMatch(matchEsperado.Nome1, matchEsperado.Nome2);

            Assert.IsTrue(matchEsperado.Equals(resultado));
        }

        [TestMethod]
        public void ComparadorDeStrings_Comparar_Igual()
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

            IMatchEndereco matchEndereco = new MatchEndereco();
            
            comparadorEndereco.Comparar(endereco1, endereco2, matchEndereco);

            Assert.IsTrue(matchEndereco.MatchParcial && matchEndereco.MatchTotal);
        }

        [TestMethod]
        public void ComparadorDeStrings_Comparar_Parcial()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            Endereco endereco1 = new Endereco(
                logradouro: "Praça Amarildo Pereira",
                numero: "8",
                cidade: "São Paulo",
                estado: "SP");

            Endereco endereco2 = new Endereco(
                logradouro: "Pc Amarildo Pereira",
                numero: "12",
                cidade: "sao paulo",
                estado: "sp");

            IMatchEndereco matchEndereco = new MatchEndereco();
            
            comparadorEndereco.Comparar(endereco1, endereco2, matchEndereco);

            Assert.IsTrue(matchEndereco.MatchParcial && !matchEndereco.MatchTotal);
        }

        [TestMethod]
        public void ComparadorDeStrings_Comparar_NaoOk()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            Endereco endereco1 = new Endereco(
                logradouro: "Praça Amarildo Pereira",
                numero: "8",
                cidade: "São Paulo",
                estado: "SP");

            Endereco endereco2 = new Endereco(
                logradouro: "Avenida Treze de Maio",
                numero: "12",
                cidade: "sao paulo",
                estado: "sp");

            IMatchEndereco matchEndereco = new MatchEndereco();

            comparadorEndereco.Comparar(endereco1, endereco2, matchEndereco);

            Assert.IsTrue(!matchEndereco.MatchParcial && !matchEndereco.MatchTotal);
        }

        [TestMethod]
        public void ComparadorDeStrings_ComparadorEndereco_CompararLogradouro_Avulso001()
        {
            IComparadorEndereco comparadorEndereco = getComparadorEndereco();

            string logradouro1 = "Rua Engenheiro Veloso";
            string logradouro2 = "R Eng Veloso";

            double resultado = comparadorEndereco.CompararLogradouro(logradouro1, logradouro2);
            double esperado = 100;

            Assert.AreEqual<double>(esperado, resultado);
        }

        
    }
}