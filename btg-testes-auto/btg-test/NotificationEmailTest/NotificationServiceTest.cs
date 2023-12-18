using btg_testes_auto.Notification;
using btg_testes_auto.Order;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.NotificationEmailTest
{
    public class NotificationServiceTest
    {
        private readonly IEmailService _mockEmailService;
        private NotificationService _service;

        public NotificationServiceTest()
        {
            _mockEmailService = Substitute.For<IEmailService>();
            _service = new(_mockEmailService);
        }

        [Fact]
        public void SendNotification_EnvioSucesso_RetornaVerdadeiro()
        {
            // Arrange
            _mockEmailService.SendEmail("email@email.com", "Notification", "Sucesso").Returns(true);

            //Act
            bool resultado = _service.SendNotification("email@email.com", "Sucesso");

            //Assert
            Assert.True(resultado);
        }

        [Fact]
        public void SendNotification_EnvioFalho_RetornaFalso()
        {
            // Arrange
            _mockEmailService.SendEmail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(false);

            //Act
            bool resultado = _service.SendNotification("email@email.com", "Falha");

            //Assert
            Assert.False(resultado);
        }

        [Fact]
        public void SendNotification_MsgVazia_RetornaFalso()
        {
            //Act
            bool resultado = _service.SendNotification("email@email.com", "");

            //Assert
            Assert.False(resultado);
        }

        [Fact]
        public void SendNotification_Excecao_RetornaFalso()
        {
            // Arrange
            _mockEmailService.SendEmail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Throws(new Exception("Exceção"));

            //Act
            bool resultado = _service.SendNotification("email@email.com", "Sucesso");

            //Assert
            Assert.False(resultado);
        }
    }
}
