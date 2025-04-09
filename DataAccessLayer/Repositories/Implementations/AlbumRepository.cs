using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly AppDbContext _context;
        public AlbumRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task DeleteAlbum(int albumId)
        {
            Album? album = await _context.Albums.FindAsync(albumId);
            if (album != null)
            {
                _context.Albums.Remove(album);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Album> GetAlbumById(int albumId)
        {
            return await _context.Albums
                .Include(album => album.Images)
                .FirstAsync(album => album.Id == albumId);
        }

        public async Task<List<Album>> GetAlbums()
        {
            return await _context.Albums.ToListAsync();
        }

        public async Task<List<Album>> GetAlbumsByUserId(int userId)
        {
            return await _context.Albums.Where(album => album.UserId == userId).ToListAsync();
        }

        public async Task InsertAlbum(Album album)
        {
            await this._context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAlbum(Album album)
        {
            this._context.Albums.Update(album);
            await _context.SaveChangesAsync();
        }
    }
}
