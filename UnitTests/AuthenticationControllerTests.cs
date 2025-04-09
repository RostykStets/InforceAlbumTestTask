using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using InforceAlbumTestTask.Controllers;
using BusinessLogicLayer.Services.Interfaces;
using InforceAlbumTestTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BusinessLogicLayer.DTOs;

public class AuthenticationControllerTests
{
    [Fact]
    public void Login_Get_Test()
    {
        // Arrange
        var mockLoginService = new Mock<ILoginService>();
        var mockRegisterService = new Mock<IRegisterService>();
        var mockLogger = new Mock<ILogger<AuthenticationController>>();

        var controller = new AuthenticationController(
            mockLoginService.Object,
            mockRegisterService.Object,
            mockLogger.Object
        );

        // Act
        var result = controller.Login();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public async Task Login_Post_WithValidUser_ReturnsRedirect()
    {
        // Arrange
        var mockLoginService = new Mock<ILoginService>();
        var mockRegisterService = new Mock<IRegisterService>();
        var mockLogger = new Mock<ILogger<AuthenticationController>>();

        var loginViewModel = new LoginViewModel { Login = "test", Password = "pass" };

        mockLoginService.Setup(s => s.Login("test", "pass"))
            .ReturnsAsync(new UserExtendedDto { ErrorMsg = "", Login = "test" });

        var controller = new AuthenticationController(
            mockLoginService.Object,
            mockRegisterService.Object,
            mockLogger.Object
        );

        // Act
        var result = await controller.Login(loginViewModel);

        // Assert
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectResult.ActionName);
    }

    [Fact]
    public async Task Login_Post_WithInvalidUser_ReturnsViewWithError()
    {
        // Arrange
        var mockLoginService = new Mock<ILoginService>();
        var mockRegisterService = new Mock<IRegisterService>();
        var mockLogger = new Mock<ILogger<AuthenticationController>>();

        var loginViewModel = new LoginViewModel { Login = "test", Password = "wrongpass" };

        mockLoginService.Setup(s => s.Login("test", "wrongpass"))
            .ReturnsAsync(new UserExtendedDto { ErrorMsg = "Ви ввели неправильний пароль!" });

        var controller = new AuthenticationController(
            mockLoginService.Object,
            mockRegisterService.Object,
            mockLogger.Object
        );

        // Act
        var result = await controller.Login(loginViewModel);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var returnedModel = Assert.IsType<LoginViewModel>(viewResult.Model);
        Assert.Equal("test", returnedModel.Login);
    }

    [Fact]
    public void Register_Get_Test()
    {
        // Arrange
        var mockLoginService = new Mock<ILoginService>();
        var mockRegisterService = new Mock<IRegisterService>();
        var mockLogger = new Mock<ILogger<AuthenticationController>>();

        var controller = new AuthenticationController(
            mockLoginService.Object,
            mockRegisterService.Object,
            mockLogger.Object
        );

        // Act
        var result = controller.Register();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public async Task Register_Post_InvalidModel_ReturnsViewWithModel()
    {
        // Arrange
        var mockLoginService = new Mock<ILoginService>();
        var mockRegisterService = new Mock<IRegisterService>();
        var mockLogger = new Mock<ILogger<AuthenticationController>>();

        var controller = new AuthenticationController(
            mockLoginService.Object,
            mockRegisterService.Object,
            mockLogger.Object
        );

        controller.ModelState.AddModelError("Login", "Required");

        var viewModel = new RegisterViewModel
        {
            Login = "", // invalid
            Password = "123456"
        };

        // Act
        var result = await controller.Register(viewModel);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(viewModel, viewResult.Model);
    }
}
