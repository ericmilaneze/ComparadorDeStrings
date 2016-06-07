using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Milaneze.Helpers;

namespace Milaneze.ComparadorDeStrings.Test
{
    [TestClass]
    public class SimilarityToolTest
    {
        [TestMethod]
        [TestCategory("SimilarityTool_CompareStrings")]
        public void SimilarityTool_CompareStrings_Parecidas()
        {
            string string1 = "Praça dos Passarinhos";
            string string2 = "Pç. dos Passarinhos";

            double resultado = SimilarityTool.CompareStrings(string1, string2);
            double resultadoMinimoEsperado = 0.7;

            Assert.IsTrue(resultado >= resultadoMinimoEsperado);
        }

        [TestMethod]
        [TestCategory("SimilarityTool_CompareStrings")]
        public void SimilarityTool_CompareStrings_ParecidasMasDiferente()
        {
            string string1 = "Praça dos Passarinhos";
            string string2 = "Pç. dos Periquitos";

            double resultado = SimilarityTool.CompareStrings(string1, string2);
            double resultadoMinimoEsperado = 0.7;

            Assert.IsFalse(resultado >= resultadoMinimoEsperado);
        }

        [TestMethod]
        [TestCategory("SimilarityTool_CompareStrings")]
        public void SimilarityTool_CompareStrings_Iguais()
        {
            string string1 = "Praça dos Passarinhos";
            string string2 = "Praça dos Passarinhos";

            double resultado = SimilarityTool.CompareStrings(string1, string2);
            double resultadoEsperado = 1;

            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        [TestCategory("SimilarityTool_CompareStrings")]
        public void SimilarityTool_CompareStrings_Diferentes()
        {
            string string1 = "Praça dos Passarinhos";
            string string2 = "Avenida Cangaíba";
            
            double resultado = SimilarityTool.CompareStrings(string1, string2);
            double resultadoEsperado = 0;

            Assert.AreEqual(resultadoEsperado, resultado);
        }
    }
}