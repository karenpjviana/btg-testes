using btg_testes_auto.CartDiscount;
using FluentAssertions.Common;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.CartDiscountTest
{
    public class CartServiceTest
    {
        private readonly IDiscountService _mockdiscountService;
        private CartService _cartService;

        public CartServiceTest() 
        {
            _mockdiscountService = Substitute.For<IDiscountService>();
            _cartService = new (_mockdiscountService);
        }

        [Fact]
        public void CalculateTotalWithDiscount_CalculaComDesconto_RetornarTotal()
        {
            // Arrange
            var items = new List<CartItem>
            {
                new CartItem { ProductId = "01", Price = 10 },
                new CartItem { ProductId = "02", Price = 30 }
            };

            _mockdiscountService.CalculateDiscount(items).Returns(5);

            // Act
            double resultado = _cartService.CalculateTotalWithDiscount(items);

            // Assert
            Assert.Equal(35, resultado);
        }

        [Fact]
        public void CalculateTotalWithDiscount_CalculaSemDesconto_RetornarTotal()
        {
            // Arrange
            var items = new List<CartItem>
            {
                new CartItem { ProductId = "01", Price = 10 },
                new CartItem { ProductId = "02", Price = 30 }
            };

            //sem desconto pra teste
            _mockdiscountService.CalculateDiscount(items).Returns(0);

            // Act
            double resultado = _cartService.CalculateTotalWithDiscount(items);

            // Assert
            Assert.Equal(40, resultado);
        }
    }
}
