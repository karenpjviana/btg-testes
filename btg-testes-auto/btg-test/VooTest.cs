using btg_testes_auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class VooTest
    {
        [Fact]
        public void ProximoLivre_TemAssentosLivres_RetornaPosicaoDoAssento()
        {
            // Arrange
            Voo voo = new Voo(
                "K27", 
                "01",
                DateTime.Now);

            // Act
            int assento = voo.ProximoLivre();

            // Assert
            Assert.Equal(1, assento);
        }

        [Fact]
        public void ProximoLivre_NaoTemAssentosLivres_RetornaPosicaoDoAssento()
        {
            // Arrange
            Voo voo = new Voo(
                "K27",
                "01",
                DateTime.Now);

            // Act
            for (int i = 0; i <= 100; i++)
            {
                voo.OcupaAssento(i);
            }
            int retorno = voo.ProximoLivre();

            // Assert
            Assert.Equal(0, retorno);
        }

        [Fact]
        public void AssentoDisponivel_AssentoVazio_RetornaTrue()
        {
            // Arrange
            Voo voo = new Voo(
                "K27",
                "01",
                DateTime.Now);

            // Act
            bool retorno = voo.AssentoDisponivel(10);

            // Assert
            Assert.True(retorno);
        }

        [Fact]
        public void AssentoDisponivel_AssentoOcupado_RetornaFalse()
        {
            // Arrange
            Voo voo = new Voo(
                "K27",
                "01",
                DateTime.Now);

            // Act
            voo.OcupaAssento(10);
            bool retorno = voo.AssentoDisponivel(10);

            // Assert
            Assert.False(retorno);
        }

        [Fact]
        public void OcupaAssento_AssentoVazio_RetornaTrue()
        {
            // Arrange
            Voo voo = new Voo(
                "K27",
                "01",
                DateTime.Now);

            // Act
            bool retorno = voo.OcupaAssento(10);

            // Assert
            Assert.True(retorno);
        }

        [Fact]
        public void OcupaAssento_AcentoOcupado_RetornaFalse()
        {
            // Arrange
            Voo voo = new Voo(
                "K27",
                "01",
                DateTime.Now);

            // Act
            voo.OcupaAssento(10);
            bool retorno = voo.OcupaAssento(10);

            // Assert
            Assert.False(retorno);
        }

        [Fact]
        public void QuantidadeVagasDisponivel_VooVazio_Retorna100()
        {
            // Arrange
            Voo voo = new Voo(
                "K27",
                "01",
                DateTime.Now);

            // Act
            int retorno = voo.QuantidadeVagasDisponivel();

            // Assert
            Assert.Equal(100, retorno);
        }

        [Fact]
        public void QuantidadeVagasDisponivel_VooCheio_Retorna0()
        {
            // Arrange
            Voo voo = new Voo(
                "K27",
                "01",
                DateTime.Now);

            // Act
            for (int i = 0; i <= 100; i++)
            {
                voo.OcupaAssento(i);
            }
            int retorno = voo.QuantidadeVagasDisponivel();

            // Assert
            Assert.Equal(0, retorno);
        }

        [Fact]
        public void ExibeInformacoesVoo_RetornaInformacoes()
        {
            // Arrange
            Voo voo = new Voo(
                "K27",
                "01",
                Convert.ToDateTime("17/12/2023"));

            string retorno = voo.ExibeInformacoesVoo();

            Assert.Equal("Aeronave K27 registrada sob voo de número 01 para o dia e hora 17/12/2023 00:00:00", retorno);
        }       
    }
}

