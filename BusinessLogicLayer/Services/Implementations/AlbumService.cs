using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task DeleteAlbum(int albumId)
        {
            await _albumRepository.DeleteAlbum(albumId);
        }

        public async Task<AlbumDto> GetAlbumById(int albumId)
        {
            Album album = await _albumRepository.GetAlbumById(albumId);
            return new AlbumDto(album);
        }

        public async Task<List<AlbumDto>> GetAlbums()
        {
            List<Album> albums = await _albumRepository.GetAlbums();

            return (from album in albums
                    select new AlbumDto(album)).ToList();
        }

        public async Task<List<AlbumDto>> GetAlbumsByUserId(int userId)
        {
            List<Album> albums = await _albumRepository.GetAlbumsByUserId(userId);

            return (from album in albums
                    select new AlbumDto(album)).ToList();
        }

        public async Task InsertAlbum(AlbumDto albumDto)
        {
            await _albumRepository.InsertAlbum(albumDto.DTOToEntity());
        }

        public async Task UpdateAlbum(AlbumDto albumDto)
        {
            await _albumRepository.UpdateAlbum(albumDto.DTOToEntity());
        }
    }
}
