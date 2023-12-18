using btg_testes_auto.NotificationMessage;
using btg_testes_auto.ShippingCost;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.ShippingCostTest
{
    public class ShippingServiceTest
    {
        private readonly IDeliveryCostCalculator _mockDeliveryCostCalculator;
        private ShippingService _service;

        public ShippingServiceTest()
        {
            _mockDeliveryCostCalculator = Substitute.For<IDeliveryCostCalculator>();
            _service = new(_mockDeliveryCostCalculator);
        }

        [Fact]
        public void CalculateShippingCost_DeliveryComun_RetornaValorSemDesconto()
        {
            // Arrange
            _mockDeliveryCostCalculator.CalculateCost(100, DeliveryType.Ordinary).Returns(10);

            // Act
            double resultado = _service.CalculateShippingCost(100, DeliveryType.Ordinary);

            // Assert
            Assert.Equal(10, resultado);
        }
        
        [Fact]
        public void CalculateShippingCost_DeliveryExpresso_RetornaValorSemDesconto()
        {
            // Arrange
            _mockDeliveryCostCalculator.CalculateCost(100, DeliveryType.Express).Returns(10);

            // Act
            double resultado = _service.CalculateShippingCost(100, DeliveryType.Express);

            // Assert
            Assert.Equal(10, resultado);
        }

        [Fact]
        public void CalculateShippingCost_DeliveryExpresso_RetornaValorComDesconto()
        {
            // Arrange
            _mockDeliveryCostCalculator.CalculateCost(250, DeliveryType.Express).Returns(10);

            // Act
            double resultado = _service.CalculateShippingCost(250, DeliveryType.Express);

            // Assert
            Assert.Equal(5, resultado);
        }
    }
}
