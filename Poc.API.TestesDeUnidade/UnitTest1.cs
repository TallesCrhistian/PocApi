using NUnit.Framework;
using PocApi.Negocios;

namespace Poc.API.TestesDeUnidade
{
    public class CalculoNegociosTestes
    {
        private CalculoNegocios _calculoNegocios;

        [SetUp]
        public void Setup()
        {
            _calculoNegocios = new CalculoNegocios();
        }

        [TestCase(1, 2, 3, Description = "Dois números positivos")]
        [TestCase(-1, 2, 1, Description = "Um número negativo e um positivo")]
        [TestCase(-1, -2, -3, Description = "Dois números negativos")]
        public void Soma_DoisNumeros_DeveResultarNaSoma(decimal num1, decimal num2, decimal resultadoEsperado)
        {
            //Arrange  - Preparação dos dados

            //Act - Processamento

            decimal resultado = _calculoNegocios.Soma(num1, num2);

            //Assert - Validação do resultado

            Assert.IsTrue(resultado == resultadoEsperado);
        }
    }
}