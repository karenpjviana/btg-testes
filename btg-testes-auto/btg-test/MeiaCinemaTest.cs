using btg_testes_auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class MeiaCinemaTest
    {
        [Theory]
        [InlineData(true, false, false, false)]
        [InlineData(false, true, false, false)]
        [InlineData(false, false, true, true)]
        public void VerificarMeiaCinema_DisponibilizaMeia_RetornaTrue(bool estudante, bool doadorDeSangue, bool trabalhadorPrefeitura, bool contratoPrefeitura)
        {
            // Arrange
            MeiaCinema cinema = new MeiaCinema();

            // Act
            bool resultado = cinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            // Assert
            Assert.True(resultado);
        }

        [Theory]
        [InlineData(false, false, false, false)]
        [InlineData(false, false, true, false)]
        [InlineData(false, false, false, true)]
        public void VerificarMeiaCinema_NãoDisponibilizaMeia_RetornaFalse(bool estudante, bool doadorDeSangue, bool trabalhadorPrefeitura, bool contratoPrefeitura)
        {
            // Arrange
            MeiaCinema cinema = new MeiaCinema();

            // Act
            bool resultado = cinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            // Assert
            Assert.False(resultado);
        }
    }
}
