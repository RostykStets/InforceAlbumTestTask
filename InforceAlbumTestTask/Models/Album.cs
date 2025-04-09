using BusinessLogicLayer.DTOs;

namespace InforceAlbumTestTask.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Image> Images { get; set; }
        public int UserId { get; set; }

        public Album()
        {
            this.Id = 0;
            this.Title = string.Empty;
            this.Images = new List<Image>();
        }

        public Album(AlbumDto albumDto)
        {
            this.Id = albumDto.Id;
            this.Title = albumDto.Title;
            this.Images = (from imageDto in albumDto.Images
                                         select new Image(imageDto)).ToList();
            this.UserId = albumDto.UserId;
        }

        public AlbumDto ModelToDto()
        {
            return new AlbumDto
            {
                Id = this.Id,
                Title = this.Title,
                Images = (List<ImageDto>)(from image in this.Images
                                          select image.ModelToDto()),
                UserId = this.UserId
            };
        }
    }
}
