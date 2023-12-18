using btg_testes_auto.Discount;
using btg_testes_auto.Notification;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.ClienteDiscountTest
{
    public class DiscountServiceTest
    {
        private readonly ICustomerService _mockCustomerService;
        private DiscountService _service;

        public DiscountServiceTest()
        {
            _mockCustomerService = Substitute.For<ICustomerService>();
            _service = new(_mockCustomerService);
        }

        [Fact]
        public void GetDiscount_ClienteRegular_RetornaDescontoDe5PorCento()
        {
            // Arrange
            _mockCustomerService.GetCustomerType(1).Returns(CustomerType.Regular);

            // Act
            double resultado = _service.GetDiscount(1, 100);

            // Assert
            Assert.Equal(5, resultado);
        }

        [Fact]
        public void GetDiscount_ClientePremium_RetornaDescontoDe10PorCento()
        {
            // Arrange
            _mockCustomerService.GetCustomerType(2).Returns(CustomerType.Premium);

            // Act
            double resultado = _service.GetDiscount(2, 100);

            // Assert
            Assert.Equal(10, resultado);
        }

        [Fact]
        public void GetDiscount_Default_RetornaSemDesconto()
        {
            // Arrange
            _mockCustomerService.GetCustomerType(3).Returns(CustomerType.NotClient);

            // Act
            double resultado = _service.GetDiscount(3, 100);

            // Assert
            Assert.Equal(0, resultado);
        }
    }
}
