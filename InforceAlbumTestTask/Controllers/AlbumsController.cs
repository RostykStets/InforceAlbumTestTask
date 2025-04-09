using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using InforceAlbumTestTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace InforceAlbumTestTask.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IAlbumService _albumService;
        private readonly IAuthorizedUserService _authorizedUserService;
        private readonly IImageService _imageService;
        private readonly ILogger _logger;
        private const int _pageSize = 5;

        public AlbumsController(IAdminService adminService, IAlbumService albumService, IAuthorizedUserService authorizedUserService, 
            IImageService imageService, ILogger<AlbumsController> logger)
        {
            _adminService = adminService;
            _albumService = albumService;
            _authorizedUserService = authorizedUserService;
            _imageService = imageService;
            _logger = logger;
        }
        public async Task<IActionResult> Index(User? user, int page = 1)
        {
            _logger.Log(LogLevel.Information, "Entering Albums Page at {0}!", DateTime.Now);

            List<AlbumDto> albumDtos = await _albumService.GetAlbums();

            List<Album> albums = (from albumDto in albumDtos
                                  select new Album(albumDto)).ToList();

            foreach (Album album in albums)
            {
                List<ImageDto> imagesDto = await _imageService.GetImagesByAlbumId(album.Id);
                album.Images = (from imageDto in imagesDto
                                select new Image(imageDto)).ToList();
            }

            var albumsPerPage = albums.Skip((page - 1) * _pageSize)
            .Take(_pageSize)
            .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)albums.Count / _pageSize);
            ViewBag.User = user;

            if (TempData != null && !string.IsNullOrEmpty(TempData["ErrorMessage"].ToString()))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }

            var tuple = new Tuple<List<Album>, User?>(albumsPerPage, user);

            return View(tuple);
        }

        public async Task<IActionResult> MyAlbums(User user, int page = 1)
        {
            _logger.Log(LogLevel.Information, "User with login: {0} entered My Albums Page at {1}!", user.Login, DateTime.Now);

            List<AlbumDto> albumDtos = await _albumService.GetAlbumsByUserId(user.Id);

            List<Album> albums = (from albumDto in albumDtos
                                  select new Album(albumDto)).ToList();

            foreach (Album album in albums)
            {
                List<ImageDto> imagesDto = await _imageService.GetImagesByAlbumId(album.Id);
                album.Images = (from imageDto in imagesDto
                                select new Image(imageDto)).ToList();
            }

            var albumsPerPage = albums.Skip((page - 1) * _pageSize)
            .Take(_pageSize)
            .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)albums.Count / _pageSize);
            ViewBag.User = user;

            //if (TempData["ErrorMessage"] != null)
            if (TempData != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }

            var tuple = new Tuple<List<Album>, User?>(albumsPerPage, user);

            return View(tuple);
        }

        public async Task<IActionResult> AlbumView(Album album, User user, int page = 1)
        {
            _logger.Log(LogLevel.Information, "User with login: {0} entered My Albums Page at {1}!", user.Login, DateTime.Now);

            var imagesDto = await _imageService.GetImagesByAlbumId(album.Id);

            album.Images = (from imageDto in imagesDto
                            select new Image(imageDto)).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.User = user;
            ViewBag.TotalPages = (int)Math.Ceiling((double)album.Images.Count / _pageSize);
            var tuple = new Tuple<Album, User>(album, user);
            return View(tuple);
        }

        public async Task<IActionResult> DeleteAlbum(int albumId, User user, int currentPage)
        {
            _logger.Log(LogLevel.Information, "User with login: {0} deleted album {1} at {2}!", user.Login, albumId, DateTime.Now);

            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("user.Id", user.Id);
            routeValues.Add("user.Login", user.Login);
            routeValues.Add("user.PasswordHash", user.PasswordHash);
            routeValues.Add("user.UserType", user.UserType);
            routeValues.Add("page", currentPage);

            try
            {
                await _albumService.DeleteAlbum(albumId);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                if (user.UserType == UserType.Admin)
                {
                    return RedirectToAction("Index", "Albums", routeValues);
                }
                else
                {
                    return RedirectToAction("MyAlbums", "Albums", routeValues);
                }
            }

            if (user.UserType == UserType.Admin)
            {
                return RedirectToAction("Index", "Albums", routeValues);
            }
            else
            {
                return RedirectToAction("MyAlbums", "Albums", routeValues);
            }
            //return RedirectToAction("MyAlbums", "Albums", routeValues);
        }

        public async Task<IActionResult> LikeImage(int imageId, int currentPage)
        {
            ImageDto imageDto = await _imageService.GetImageById(imageId);

            imageDto.LikeCounter++;

            await _imageService.UpdateImage(imageDto);

            AlbumDto albumDto = await _albumService.GetAlbumById(imageDto.AlbumId);

            UserDto? userDto = await _authorizedUserService.GetUserById(albumDto.UserId);

            _logger.Log(LogLevel.Information, "User with login: {0} liked image {1} from album {2} at {3}!", userDto!.Login, imageDto.Id, albumDto.Id, DateTime.Now);

            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("album.Id", albumDto.Id);
            routeValues.Add("album.Title", albumDto.Title);
            routeValues.Add("album.UserId", albumDto.UserId);
            routeValues.Add("user.Id", userDto!.Id);
            routeValues.Add("user.Login", userDto!.Login);
            routeValues.Add("user.PasswordHash", userDto!.PasswordHash);
            routeValues.Add("user.UserType", userDto!.UserType);
            routeValues.Add("page", currentPage);

            return RedirectToAction("AlbumView", "Albums", routeValues);
        }

        public async Task<IActionResult> DislikeImage(int imageId, int currentPage)
        {
            ImageDto imageDto = await _imageService.GetImageById(imageId);

            imageDto.DislikeCounter++;

            await _imageService.UpdateImage(imageDto);

            AlbumDto albumDto = await _albumService.GetAlbumById(imageDto.AlbumId);

            UserDto? userDto = await _authorizedUserService.GetUserById(albumDto.UserId);

            _logger.Log(LogLevel.Information, "User with login: {0} disliked image {1} from album {2} at {3}!", userDto!.Login, imageDto.Id, albumDto.Id, DateTime.Now);

            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("album.Id", albumDto.Id);
            routeValues.Add("album.Title", albumDto.Title);
            routeValues.Add("album.UserId", albumDto.UserId);
            routeValues.Add("user.Id", userDto!.Id);
            routeValues.Add("user.Login", userDto!.Login);
            routeValues.Add("user.PasswordHash", userDto!.PasswordHash);
            routeValues.Add("user.UserType", userDto!.UserType);
            routeValues.Add("page", currentPage);

            return RedirectToAction("AlbumView", "Albums", routeValues);
        }

        public async Task<IActionResult> DeleteImage(int imageId, int currentPage)
        {
            ImageDto imageDto = await _imageService.GetImageById(imageId);

            AlbumDto albumDto = await _albumService.GetAlbumById(imageDto.AlbumId);

            UserDto? userDto = await _authorizedUserService.GetUserById(albumDto.UserId);

            await _imageService.DeleteImage(imageDto.Id);

            _logger.Log(LogLevel.Information, "User with login: {0} deleted image {1} from album {2} at {3}!", userDto!.Login, imageDto.Id, albumDto.Id, DateTime.Now);

            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("album.Id", albumDto.Id);
            routeValues.Add("album.Title", albumDto.Title);
            routeValues.Add("album.UserId", albumDto.UserId);
            routeValues.Add("user.Id", userDto!.Id);
            routeValues.Add("user.Login", userDto!.Login);
            routeValues.Add("user.PasswordHash", userDto!.PasswordHash);
            routeValues.Add("user.UserType", userDto!.UserType);
            routeValues.Add("page", currentPage);

            return RedirectToAction("AlbumView", "Albums", routeValues);
        }
    }
}
