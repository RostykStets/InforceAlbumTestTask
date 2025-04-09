
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IAlbumRepository
    {
        Task<List<Album>> GetAlbums();
        Task<Album> GetAlbumById(int albumId);
        Task<List<Album>> GetAlbumsByUserId(int userId);
        Task InsertAlbum(Album album);
        Task UpdateAlbum(Album album);
        Task DeleteAlbum(int albumId);
    }
}
