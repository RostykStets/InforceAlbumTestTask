using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IImageService
    {
        Task<List<ImageDto>> GetImages();
        Task<ImageDto> GetImageById(int imageId);
        Task<List<ImageDto>> GetImagesByAlbumId(int albumId);
        Task InsertImage(ImageDto imageDto);
        Task UpdateImage(ImageDto imageDto);
        Task DeleteImage(int imageId);
    }
}
