using btg_testes_auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class LucroTest
    {
        [Fact]
        public void Calcular_NumerosValidosMaiorQue20_RetornaValorVenda()
        {
            // Arrange
            Lucro lucro = new Lucro();
            decimal valorProduto = 30M;

            // Act
            decimal resultado = lucro.Calcular(valorProduto);

            // Assert
            Assert.Equal(39M, resultado);
        }

        [Fact]
        public void Calcular_NumerosValidosMenorQue20_RetornaValorVenda()
        {
            // Arrange
            Lucro lucro = new Lucro();
            decimal valorProduto = 15;

            // Act
            decimal resultado = lucro.Calcular(valorProduto);

            // Assert
            Assert.Equal(21.75M, resultado);
        }

        [Fact]
        public void Calcular_NumerosValidosIgualA20_RetornaValorVenda()
        {
            // Arrange
            Lucro lucro = new Lucro();
            decimal valorProduto = 20M;

            // Act
            decimal resultado = lucro.Calcular(valorProduto);

            // Assert
            Assert.Equal(26M, resultado);
        }

    }
}
