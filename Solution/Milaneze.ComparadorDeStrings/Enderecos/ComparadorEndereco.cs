using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milaneze.Helpers;
using Milaneze.ComparadorDeStrings.Comum.Enderecos;
using Milaneze.ComparadorDeStrings.Comum;

namespace Milaneze.ComparadorDeStrings.Enderecos
{
    public class ComparadorEndereco : IComparadorEndereco
    {
        private double _porcentagemMinimaMatchLogradouro = 100;
        private double _porcentagemMinimaMatchCidade = 100;

        public double PorcentagemMinimaMatchLogradouro 
        {
            get
            {
                return _porcentagemMinimaMatchLogradouro;
            }
            set
            {
                _porcentagemMinimaMatchLogradouro = value;
            }
        }

        public double PorcentagemMinimaMatchCidade 
        {
            get
            {
                return _porcentagemMinimaMatchCidade;
            }
            set
            {
                _porcentagemMinimaMatchCidade = value;
            }
        }

        public IList<SubstituicaoLogradouro> SubstituicoesLogradouro { get; set; }

        #region Construtores
        public ComparadorEndereco() 
            : this(100, 100, null)
        {
            
        }

        public ComparadorEndereco(double porcentagemMinimaMatchLogradouro) 
            : this(porcentagemMinimaMatchLogradouro, 100, null)
        {

        }

        public ComparadorEndereco(double porcentagemMinimaMatchLogradouro, double porcentagemMinimaMatchCidade)
            : this(porcentagemMinimaMatchLogradouro, porcentagemMinimaMatchCidade, null)
        {
            
        }

        public ComparadorEndereco(IList<SubstituicaoLogradouro> substituicoesLogradouro)
            : this(100, 100, substituicoesLogradouro)
        {
            
        }

        public ComparadorEndereco(double porcentagemMinimaMatchLogradouro, double porcentagemMinimaMatchCidade, IList<SubstituicaoLogradouro> substituicoesLogradouro)
        {
            _porcentagemMinimaMatchLogradouro = porcentagemMinimaMatchLogradouro;
            _porcentagemMinimaMatchCidade = porcentagemMinimaMatchCidade;
            SubstituicoesLogradouro = substituicoesLogradouro;
        }
        #endregion

        public double CompararLogradouro(string logradouro1, string logradouro2)
        {
            if (string.IsNullOrWhiteSpace(logradouro1) || string.IsNullOrWhiteSpace(logradouro2))
                return 0;

            string logradouro1Substituido = logradouro1.Trim().Replace(".", "").Replace(",", "").RemoverEspacosDuplicados().EscreverNumerosPorExtenso().ToUpper().RemoverAcentos();
            string logradouro2Substituido = logradouro2.Trim().Replace(".", "").Replace(",", "").RemoverEspacosDuplicados().EscreverNumerosPorExtenso().ToUpper().RemoverAcentos();

            if (SubstituicoesLogradouro != null)
                foreach (var substituicao in SubstituicoesLogradouro)
                {
                    logradouro1Substituido = logradouro1Substituido.ReplaceFirst(substituicao.De.ToUpper().RemoverAcentos() + " ", substituicao.Para.ToUpper() + " ");

                    logradouro2Substituido = logradouro2Substituido.ReplaceFirst(substituicao.De.ToUpper().RemoverAcentos() + " ", substituicao.Para.ToUpper() + " ");
                }

            return SimilarityTool.CompareStrings(logradouro1Substituido, logradouro2Substituido) * 100;
        }

        public bool IsLogradouroIgual(string logradouro1, string logradouro2)
        {
            return CompararLogradouro(logradouro1, logradouro2) >= _porcentagemMinimaMatchLogradouro;
        }

        public bool IsLogradouroIgual(string logradouro1, string logradouro2, double porcentagemMinimaMatchLogradouro)
        {
            _porcentagemMinimaMatchLogradouro = porcentagemMinimaMatchLogradouro;

            return IsLogradouroIgual(logradouro1, logradouro2);
        }

        public bool IsNumeroIgual(string numero1, string numero2)
        {
            if (string.IsNullOrWhiteSpace(numero1) || string.IsNullOrWhiteSpace(numero2))
                return false;

            if (numero1.Trim().ToUpper() == "SN")
                if (numero1.Trim().ToUpper() == numero2.Trim().ToUpper())
                    return true;

            int intNumero1;
            int intNumero2;

            if (!int.TryParse(numero1.Trim(), out intNumero1))
                return false;

            if (!int.TryParse(numero2.Trim(), out intNumero2))
                return false;

            return intNumero1 == intNumero2 && intNumero1 != 0 && intNumero2 != 0;
        }

        public double CompararCidade(string cidade1, string cidade2)
        {
            if (string.IsNullOrWhiteSpace(cidade1) || string.IsNullOrWhiteSpace(cidade2))
                return 0;

            return SimilarityTool.CompareStrings(cidade1.ToUpper().RemoverAcentos(), cidade2.ToUpper().RemoverAcentos()) * 100;
        }

        public bool IsCidadeIgual(string cidade1, string cidade2)
        {
            return CompararCidade(cidade1, cidade2) >= _porcentagemMinimaMatchCidade;
        }

        public bool IsCidadeIgual(string cidade1, string cidade2, double porcentagemMinimaMatchCidade)
        {
            _porcentagemMinimaMatchCidade = porcentagemMinimaMatchCidade;

            return IsCidadeIgual(cidade1, cidade2);
        }

        public bool IsEstadoIgual(string estado1, string estado2)
        {
            if (string.IsNullOrWhiteSpace(estado1) || string.IsNullOrWhiteSpace(estado2))
                return false;

            return estado1.ToUpper() == estado2.ToUpper();
        }

        public Match CompararLogradouroMatch(string logradouro1, string logradouro2)
        {
            return new Match(
                nome1: logradouro1,
                nome2: logradouro2,
                porcentagem: CompararLogradouro(logradouro1, logradouro2),
                igual: IsLogradouroIgual(logradouro1, logradouro2));
        }

        public Match CompararNumeroMatch(string numero1, string numero2)
        {
            return new Match(
                nome1: numero1,
                nome2: numero2,
                porcentagem: IsNumeroIgual(numero1, numero2) ? 100 : 0,
                igual: IsNumeroIgual(numero1, numero2));
        }

        public Match CompararCidadeMatch(string cidade1, string cidade2)
        {
            return new Match(
                nome1: cidade1,
                nome2: cidade2,
                porcentagem: CompararCidade(cidade1, cidade2),
                igual: IsCidadeIgual(cidade1, cidade2));
        }

        public Match CompararEstadoMatch(string estado1, string estado2)
        {
            return new Match(
                nome1: estado1,
                nome2: estado2,
                porcentagem: IsEstadoIgual(estado1, estado2) ? 100 : 0,
                igual: IsEstadoIgual(estado1, estado2));
        }

        public void Comparar(Endereco endereco1, Endereco endereco2, IMatchEndereco matchEndereco)
        {
            matchEndereco.Logradouro = CompararLogradouroMatch(endereco1.Logradouro, endereco2.Logradouro);
            matchEndereco.Numero = CompararNumeroMatch(endereco1.Numero, endereco2.Numero);
            matchEndereco.Cidade = CompararCidadeMatch(endereco1.Cidade, endereco2.Cidade);
            matchEndereco.Estado = CompararEstadoMatch(endereco1.Estado, endereco2.Estado);
        }

        public IMatchEndereco Comparar(Endereco endereco1, Endereco endereco2)
        {
            IMatchEndereco matchEndereco = new MatchEndereco();

            Comparar(endereco1, endereco2, matchEndereco);

            return matchEndereco;
        }
    }
}