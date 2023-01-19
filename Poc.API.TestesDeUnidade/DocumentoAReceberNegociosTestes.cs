using AutoMapper;
using Moq;
using NUnit.Framework;
using PocApi.Data.Interfaces;
using PocApi.Negocios;
using PocApi.Negocios.Interfaces;
using System.Collections.Generic;

namespace Poc.API.TestesDeUnidade
{
    public class DocumentoAReceberNegociosTestes
    {
        private IDocumentoAReceberNegocios _documentoAReceberNegocios;

        private List<decimal> parcelasDivisaoNaoExatas = new List<decimal> { 3.33M, 3.33M, 3.34M };

        [SetUp]
        public void Setup()
        {
            Mock<IMapper> mapper = new Mock<IMapper>();
            Mock<IDocumentoAReceberRepositorio> documentoAReceberRepositorio = new Mock<IDocumentoAReceberRepositorio>();
            _documentoAReceberNegocios = new DocumentoAReceberNegocios(documentoAReceberRepositorio.Object, mapper.Object);
        }

        [Test]
        public void RatearParcela_DivisaoExata_RetornaParcelasDivididasIgualmente()
        {
            //Arrange
            int quantidadeParcelas = 3;
            decimal valorTotalParcelas = 9.99M;
            List<decimal> parcelasDivisaoExatas = new List<decimal> { 3.33M, 3.33M, 3.33M };

            //Act

            List<decimal> resultado = _documentoAReceberNegocios.RatearParcela(quantidadeParcelas, valorTotalParcelas);

            //Assert

            Assert.That(resultado.Count == parcelasDivisaoExatas.Count);
            Assert.That(parcelasDivisaoExatas[0] == resultado[0]);
            Assert.That(parcelasDivisaoExatas[1] == resultado[1]);
            Assert.That(parcelasDivisaoExatas[2] == resultado[2]);
        }

        [Test]
        public void RatearParcela_DivisaoExata_RetornaParcelasDivididasIgualmenteAtribuiRestanteNaUltimaParcela()
        {
            //Arrange
            int quantidadeParcelas = 3;
            decimal valorTotalParcelas = 10.00M;
            List<decimal> parcelasDivisaoExatas = new List<decimal> { 3.33M, 3.33M, 3.34M };

            //Act

            List<decimal> resultado = _documentoAReceberNegocios.RatearParcela(quantidadeParcelas, valorTotalParcelas);

            //Assert

            Assert.That(resultado.Count == parcelasDivisaoExatas.Count);
            Assert.That(parcelasDivisaoExatas[0] == resultado[0]);
            Assert.That(parcelasDivisaoExatas[1] == resultado[1]);
            Assert.That(parcelasDivisaoExatas[2] == resultado[2]);
        }
    }
}