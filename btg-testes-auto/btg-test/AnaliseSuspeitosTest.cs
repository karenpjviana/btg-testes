using btg_testes_auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class AnaliseSuspeitosTest
    {
        [Theory]
        [InlineData(true, true, false, false, false)]
        [InlineData(true, false, true, false, false)]
        [InlineData(true, false, false, true, false)]
        [InlineData(true, false, false, false, true)]
        [InlineData(false, true, true, false, false)]
        [InlineData(false, true, false, true, false)]
        [InlineData(false, true, false, false, true)]
        [InlineData(false, false, true, true, false)]
        [InlineData(false, false, true, false, true)]
        [InlineData(false, false, false, true, true)]
        public void ExecutarQuestionarioSuspeito_RespostasPositivas_RetornaSupeita(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            // Arrange
            AnaliseSuspeitos analise = new AnaliseSuspeitos();

            // Act
            string resultado = analise.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            // Assert
            Assert.Equal("Suspeita", resultado);
        }

        [Theory]
        [InlineData(true, true, true, false, false)]
        [InlineData(true, false, true, true, false)]
        [InlineData(true, false, false, true, true)]
        [InlineData(true, true, false, true, false)]
        [InlineData(true, true, false, false, true)]
        [InlineData(false, true, true, true, false)]
        [InlineData(false, true, true, false, true)]
        [InlineData(false, false, true, true, true)]
        [InlineData(true, true, true, true, false)]
        [InlineData(false, true, true, true, true)]
        public void ExecutarQuestionarioSuspeito_RespostasPositivas_RetornaCumplice(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            // Arrange
            AnaliseSuspeitos analise = new AnaliseSuspeitos();

            // Act
            string resultado = analise.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            // Assert
            Assert.Equal("Cúmplice", resultado);
        }

        [Theory]
        [InlineData(true, true, true, true, true)]
        public void ExecutarQuestionarioSuspeito_RespostasPositivas_RetornaAssassino(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            // Arrange
            AnaliseSuspeitos analise = new AnaliseSuspeitos();

            // Act
            string resultado = analise.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            // Assert
            Assert.Equal("Assassino", resultado);
        }
        
        [Theory]
        [InlineData(false, false, false, false, false)]
        public void ExecutarQuestionarioSuspeito_RespostasPositivas_RetornaInocente(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            // Arrange
            AnaliseSuspeitos analise = new AnaliseSuspeitos();

            // Act
            string resultado = analise.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            // Assert
            Assert.Equal("Inocente", resultado);
        }
    }
}
