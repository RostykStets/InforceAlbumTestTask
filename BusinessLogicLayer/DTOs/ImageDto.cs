using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public uint LikeCounter { get; set; }
        public uint DislikeCounter { get; set; }
        public int AlbumId { get; set; }

        public ImageDto()
        {
            this.Id = 0;
            this.Title = string.Empty;
            this.ImageUrl = string.Empty;
            this.LikeCounter = 0;
            this.DislikeCounter = 0;
        }

        public ImageDto(Image image)
        {
            this.Id = image.Id;
            this.Title = image.Title;
            this.ImageUrl = image.ImageUrl;
            this.LikeCounter = image.LikeCounter;
            this.DislikeCounter = image.DislikeCounter;
            this.AlbumId = image.AlbumId;
        }

        public Image DTOToEntity()
        {
            return new Image
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
