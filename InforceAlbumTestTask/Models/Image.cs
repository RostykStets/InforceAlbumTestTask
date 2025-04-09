using BusinessLogicLayer.DTOs;

namespace InforceAlbumTestTask.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public uint LikeCounter { get; set; }
        public uint DislikeCounter { get; set; }
        public int AlbumId { get; set; }

        public Image()
        {
            this.Id = 0;
            this.Title = string.Empty;
            this.ImageUrl = string.Empty;
            this.LikeCounter = 0;
            this.DislikeCounter = 0;
        }

        public Image(ImageDto imageDto)
        {
            this.Id = imageDto.Id;
            this.Title = imageDto.Title;
            this.ImageUrl = imageDto.ImageUrl;
            this.LikeCounter = imageDto.LikeCounter;
            this.DislikeCounter = imageDto.DislikeCounter;
            this.AlbumId = imageDto.AlbumId;
        }

        public ImageDto ModelToDto()
        {
            return new ImageDto
            {
                Id = this.Id,
                Title = this.Title,
                ImageUrl = this.ImageUrl,
                LikeCounter = this.LikeCounter,
                DislikeCounter = this.DislikeCounter,
                AlbumId = this.AlbumId
            };
        }
    }
}
