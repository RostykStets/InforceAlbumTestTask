using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDbContext _context;

        public ImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteImage(int imageId)
        {
            Image? image = await _context.Images.FindAsync(imageId);
            if (image != null)
            {
                _context.Images.Remove(image);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Image> GetImageById(int imageId)
        {
            return await _context.Images.Where(image => image.Id == imageId).SingleAsync();
        }

        public async Task<List<Image>> GetImages()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<List<Image>> GetImagesByAlbumId(int albumId)
        {
           return await _context.Images.Where(image => image.AlbumId == albumId).ToListAsync();
           //return await _context.Images.Where(image => image.AlbumId == albumId).AsNoTracking().ToListAsync();
        }

        public async Task InsertImage(Image image)
        {
            await this._context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateImage(Image image)
        {
            //this._context.Images.Update(image);

            var tracked = _context.Images.Local.FirstOrDefault(e => e.Id == image.Id);
            if (tracked != null)
            {
                _context.Entry(tracked).State = EntityState.Detached;
            }


            _context.Entry(image).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
