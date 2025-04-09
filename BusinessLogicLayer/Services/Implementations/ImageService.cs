using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task DeleteImage(int imageId)
        {
            await _imageRepository.DeleteImage(imageId);
        }

        public async Task<ImageDto> GetImageById(int imageId)
        {
            Image image = await _imageRepository.GetImageById(imageId);
            return new ImageDto(image);
        }

        public async Task<List<ImageDto>> GetImages()
        {
            List<Image> images = await _imageRepository.GetImages();

            return (from image in images
                    select new ImageDto(image)).ToList();
        }

        public async Task<List<ImageDto>> GetImagesByAlbumId(int albumId)
        {
            List<Image> images = await _imageRepository.GetImagesByAlbumId(albumId);

            return (from image in images
                    select new ImageDto(image)).ToList();
        }

        public async Task InsertImage(ImageDto imageDto)
        {
            await _imageRepository.InsertImage(imageDto.DTOToEntity());
        }

        public async Task UpdateImage(ImageDto imageDto)
        {
            await _imageRepository.UpdateImage(imageDto.DTOToEntity());
        }
    }
}
