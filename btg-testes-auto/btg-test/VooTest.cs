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
    }
}
