using btg_testes_auto;
using btg_testes_auto.Notification;
using btg_testes_auto.NotificationMessage;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.NotificationMessageTest
{
    public class NotificationMessageServiceTest
    {
        private readonly IMessageService _mockMessageService;
        private NotificationMessageService _service;

        public NotificationMessageServiceTest()
        {
            _mockMessageService = Substitute.For<IMessageService>();
            _service = new(_mockMessageService);
        }

        [Fact]
        public void NotifyUsers_EnvioSucesso_RetornaTrue()
        {
            // Arrange
            List<Notification> notifications = new List<Notification>()
            {
                new Notification { Message = "Oi!", UserId = "01"}
            };

            _mockMessageService.SendMessage("01", "Oi!").Returns(true);

            // Act
            bool resultado = _service.NotifyUsers(notifications);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void NotifyUsers_EnvioFalho_RetornaTrue()
        {
            // Arrange
            List<Notification> notifications = new List<Notification>()
            {
                new Notification { Message = "Oi", UserId = "01"}
            };

            _mockMessageService.SendMessage(Arg.Any<string>(), Arg.Any<string>()).Returns(false);

            // Act
            bool resultado = _service.NotifyUsers(notifications);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void NotifyUsers_EnvioVazio_RetornaFalso()
        {
            List<Notification> notifications = new List<Notification>();

            // Act
            bool resultado = _service.NotifyUsers(notifications);

            // Assert
            Assert.True(resultado);
        }
    }
}
