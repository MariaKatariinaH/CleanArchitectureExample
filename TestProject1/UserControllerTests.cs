using CleanArchitectureExample.Application.Interfaces;
using CleanArchitectureExample.WebAPI.Controllers;
using CleanArchitectureExample.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestProject
{
    public class UserControllerTests
    {
        [Fact]
        public async Task RegisterUserAsync_ReturnsCreatedResult_WhenRegistrationSucceeds()
        {
            //Arrange
            //mockataan IUserRegistrationService-rajapinnan RegisterUserAsync-metodi
            var mockService = new Mock<IUserRegistrationService>();

            //Simuloi rekisteröintiä, joka onnistuu
            mockService.Setup(service => service.RegisterUserAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(true); //Simuloi onnistunutta rekisteröintiä

            //Luo UsersController-olio ja anna sille mockattu IUserRegistrationService-olio
            var controller = new UsersController(mockService.Object);

            //Act
            var result = await controller.RegisterUserAsync(new UserRegistrationRequest { Name = "Testi", Email = "testi@test.com" });

            //Assert
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task RegisterUserAsync_ReturnsBadRequest_WhenRegistrationFails()
        {
            //Arrange
            var mockService = new Mock<IUserRegistrationService>();

            //Simuloi rekisteröintiä, joka epäonnistuu
            mockService.Setup(service => service.RegisterUserAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(false); //Simuloio epäonnistunutta rekisteröintiä

            var controller = new UsersController(mockService.Object);

            //Act
            var result = await controller.RegisterUserAsync(new UserRegistrationRequest { Name = "Testi", Email = "fail@test.com" });

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

    }
}
