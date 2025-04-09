using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IImageRepository
    {
        Task<List<Image>> GetImages();
        Task<Image> GetImageById(int imageId);
        Task<List<Image>> GetImagesByAlbumId(int albumId);
        Task InsertImage(Image image);
        Task UpdateImage(Image image);
        Task DeleteImage(int imageId);
    }
}
