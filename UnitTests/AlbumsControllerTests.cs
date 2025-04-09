using Moq;
using Microsoft.Extensions.Logging;
using InforceAlbumTestTask.Controllers;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.DTOs;
using InforceAlbumTestTask.Models;

public class AlbumsControllerTests
{
    [Fact]
    public async Task Index_Test()
    {
        // Arrange
        var mockAlbumService = new Mock<IAlbumService>();
        var mockAdminService = new Mock<IAdminService>();
        var mockAuthorizedUserService = new Mock<IAuthorizedUserService>();
        var mockImageService = new Mock<IImageService>();
        var mockLogger = new Mock<ILogger<AlbumsController>>();

        mockAlbumService.Setup(service => service.GetAlbums())
            .ReturnsAsync(new List<AlbumDto>
            {
            new AlbumDto { Id = 1, Title = "Test Album" }
            });

        mockImageService.Setup(service => service.GetImagesByAlbumId(It.IsAny<int>()))
            .ReturnsAsync(new List<ImageDto>());

        var controller = new AlbumsController(
            mockAdminService.Object,
            mockAlbumService.Object,
            mockAuthorizedUserService.Object,
            mockImageService.Object,
            mockLogger.Object
        );

        // Act
        var result = await controller.Index(null);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<Tuple<List<Album>, User>>(viewResult.Model);
        Assert.NotEmpty(model.Item1);
    }

    [Fact]
    public async Task MyAlbums_Test()
    {
        // Arrange
        var mockAlbumService = new Mock<IAlbumService>();
        var mockAdminService = new Mock<IAdminService>();
        var mockAuthorizedUserService = new Mock<IAuthorizedUserService>();
        var mockImageService = new Mock<IImageService>();
        var mockLogger = new Mock<ILogger<AlbumsController>>();

        var user = new User { Id = 1, Login = "testuser" };
        mockAlbumService.Setup(s => s.GetAlbumsByUserId(user.Id)).ReturnsAsync(new List<AlbumDto>());

        var controller = new AlbumsController(
            mockAdminService.Object,
            mockAlbumService.Object,
            mockAuthorizedUserService.Object,
            mockImageService.Object,
            mockLogger.Object
        );

        // Act
        var result = await controller.MyAlbums(user);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.IsType<Tuple<List<Album>, User>>(viewResult.Model);
    }

    [Fact]
    public async Task AlbumView_Test()
    {
        // Arrange
        var mockAlbumService = new Mock<IAlbumService>();
        var mockAdminService = new Mock<IAdminService>();
        var mockAuthorizedUserService = new Mock<IAuthorizedUserService>();
        var mockImageService = new Mock<IImageService>();
        var mockLogger = new Mock<ILogger<AlbumsController>>();

        var album = new Album { Id = 1, Title = "Test Album" };
        var user = new User { Login = "admin" };

        mockImageService.Setup(s => s.GetImagesByAlbumId(album.Id)).ReturnsAsync(new List<ImageDto>());

        var controller = new AlbumsController(
            mockAdminService.Object,
            mockAlbumService.Object,
            mockAuthorizedUserService.Object,
            mockImageService.Object,
            mockLogger.Object
        );

        // Act
        var result = await controller.AlbumView(album, user);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<Tuple<Album, User>>(viewResult.Model);
        Assert.Equal(album.Title, model.Item1.Title);
    }

    [Fact]
    public async Task DeleteAlbum_Test()
    {
        // Arrange
        var mockAlbumService = new Mock<IAlbumService>();
        var mockAdminService = new Mock<IAdminService>();
        var mockAuthorizedUserService = new Mock<IAuthorizedUserService>();
        var mockImageService = new Mock<IImageService>();
        var mockLogger = new Mock<ILogger<AlbumsController>>();

        var user = new User { Login = "testuser" };
        int albumId = 1, currentPage = 1;

        mockAlbumService.Setup(s => s.DeleteAlbum(albumId)).Returns(Task.CompletedTask);

        var controller = new AlbumsController(
            mockAdminService.Object,
            mockAlbumService.Object,
            mockAuthorizedUserService.Object,
            mockImageService.Object,
            mockLogger.Object
        );

        // Act
        var result = await controller.DeleteAlbum(albumId, user, currentPage);

        // Assert
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("MyAlbums", redirect.ActionName);
    }

    [Fact]
    public async Task LikeImage_Test()
    {
        var mockAlbumService = new Mock<IAlbumService>();
        var mockAdminService = new Mock<IAdminService>();
        var mockAuthorizedUserService = new Mock<IAuthorizedUserService>();
        var mockImageService = new Mock<IImageService>();
        var mockLogger = new Mock<ILogger<AlbumsController>>();

        mockImageService.Setup(s => s.GetImageById(It.IsAny<int>()))
        .ReturnsAsync(new ImageDto
        {
            Id = 1,
            DislikeCounter = 0,
            AlbumId = 1
        });

        mockAlbumService.Setup(s => s.GetAlbumById(It.IsAny<int>()))
            .ReturnsAsync(new AlbumDto
            {
                Id = 1,
                Title = "Test Album",
                UserId = 1
            });

        mockImageService.Setup(s => s.UpdateImage(It.IsAny<ImageDto>()))
            .Returns(Task.CompletedTask);

        mockAuthorizedUserService.Setup(s => s.GetUserById(It.IsAny<int>()))
            .ReturnsAsync(new AuthorizedUserDto
            {
                Id = 1,
                Login = "testuser",
                UserType = UserTypeDto.AuthorizedUser
            });

        var controller = new AlbumsController(
            mockAdminService.Object,
            mockAlbumService.Object,
            mockAuthorizedUserService.Object,
            mockImageService.Object,
            mockLogger.Object
        );

        var result = await controller.LikeImage(1, 1);

        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("AlbumView", redirect.ActionName);
    }

    [Fact]
    public async Task DislikeImage_Test()
    {
        var mockAlbumService = new Mock<IAlbumService>();
        var mockAdminService = new Mock<IAdminService>();
        var mockAuthorizedUserService = new Mock<IAuthorizedUserService>();
        var mockImageService = new Mock<IImageService>();
        var mockLogger = new Mock<ILogger<AlbumsController>>();

        mockImageService.Setup(s => s.GetImageById(It.IsAny<int>()))
        .ReturnsAsync(new ImageDto
        {
            Id = 1,
            DislikeCounter = 0,
            AlbumId = 1
        });

        mockAlbumService.Setup(s => s.GetAlbumById(It.IsAny<int>()))
            .ReturnsAsync(new AlbumDto
            {
                Id = 1,
                Title = "Test Album",
                UserId = 1
            });

        mockImageService.Setup(s => s.UpdateImage(It.IsAny<ImageDto>()))
            .Returns(Task.CompletedTask);

        mockAuthorizedUserService.Setup(s => s.GetUserById(It.IsAny<int>()))
            .ReturnsAsync(new AuthorizedUserDto 
            { 
                Id = 1, 
                Login = "testuser", 
                UserType = UserTypeDto.AuthorizedUser 
            });

        var controller = new AlbumsController(
            mockAdminService.Object,
            mockAlbumService.Object,
            mockAuthorizedUserService.Object,
            mockImageService.Object,
            mockLogger.Object
        );

        var result = await controller.DislikeImage(1, 1);

        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("AlbumView", redirect.ActionName);
    }

    [Fact]
    public async Task DeleteImage_Test()
    {
        var mockAlbumService = new Mock<IAlbumService>();
        var mockAdminService = new Mock<IAdminService>();
        var mockAuthorizedUserService = new Mock<IAuthorizedUserService>();
        var mockImageService = new Mock<IImageService>();
        var mockLogger = new Mock<ILogger<AlbumsController>>();

        mockImageService.Setup(s => s.GetImageById(It.IsAny<int>()))
        .ReturnsAsync(new ImageDto
        {
            Id = 1,
            DislikeCounter = 0,
            AlbumId = 1
        });

        mockAlbumService.Setup(s => s.GetAlbumById(It.IsAny<int>()))
            .ReturnsAsync(new AlbumDto
            {
                Id = 1,
                Title = "Test Album",
                UserId = 1
            });

        mockImageService.Setup(s => s.DeleteImage(It.IsAny<int>())).Returns(Task.CompletedTask);

        mockAuthorizedUserService.Setup(s => s.GetUserById(It.IsAny<int>()))
            .ReturnsAsync(new AuthorizedUserDto
            {
                Id = 1,
                Login = "testuser",
                UserType = UserTypeDto.AuthorizedUser
            });

        var controller = new AlbumsController(
            mockAdminService.Object,
            mockAlbumService.Object,
            mockAuthorizedUserService.Object,
            mockImageService.Object,
            mockLogger.Object
        );

        var result = await controller.DeleteImage(1, 1);

        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("AlbumView", redirect.ActionName);
    }

}