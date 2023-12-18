using btg_testes_auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class MotoristaTest
    {
        [Fact]
        public void EncontrarMotoristas_ListaPreenchidaMaior18ComHabilitação_RetornaSucesso()
        {
            // Arrange
            List<Pessoa> pessoas = new List<Pessoa> 
            {
                new Pessoa { Nome = "João", Idade = 20, PossuiHabilitacaoB = true },
                new Pessoa { Nome = "Maria", Idade = 25, PossuiHabilitacaoB = true },
                new Pessoa { Nome = "Carlos", Idade = 16, PossuiHabilitacaoB = false },
                new Pessoa { Nome = "Ana", Idade = 22, PossuiHabilitacaoB = true }
            };
            Motorista motoristas = new Motorista();

            // Act
            string resultado = motoristas.EncontrarMotoristas(pessoas);

            // Assert
            Assert.Equal("Uhuu! Os motoristas são João e Maria", resultado);
        }

        [Fact]
        public void EncontrarMotoristas_ListaPreenchidaMenor18SemHabilitação_RetornaSucesso()
        {
            // Arrange
            List<Pessoa> pessoas = new List<Pessoa>
            {
                new Pessoa { Nome = "João", Idade = 20, PossuiHabilitacaoB = false },
                new Pessoa { Nome = "Carlos", Idade = 16, PossuiHabilitacaoB = false },
            };
            Motorista motoristas = new Motorista();

            // Act
            Action resultado = () => motoristas.EncontrarMotoristas(pessoas);

            // Assert
            Assert.Throws<Exception>(resultado);
        }
    }
}
