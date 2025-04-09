using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAlbumService
    {
        Task<List<AlbumDto>> GetAlbums();
        Task<AlbumDto> GetAlbumById(int albumId);
        Task<List<AlbumDto>> GetAlbumsByUserId(int userId);
        Task InsertAlbum(AlbumDto albumDto);
        Task UpdateAlbum(AlbumDto albumDto);
        Task DeleteAlbum(int albumId);
    }
}
