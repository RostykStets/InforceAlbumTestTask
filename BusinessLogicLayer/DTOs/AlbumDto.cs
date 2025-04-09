using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class AlbumDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ImageDto> Images { get; set; }
        public int UserId { get; set; }

        public AlbumDto()
        {
            this.Id = 0;
            this.Title = string.Empty;
            this.Images = new List<ImageDto>();
        }

        public AlbumDto(Album album)
        {
            this.Id = album.Id;
            this.Title = album.Title;
            this.Images = (from image in album.Images
                          select new ImageDto(image)).ToList();
            this.UserId = album.UserId;
        }

        public Album DTOToEntity()
        {
            return new Album
            {
                Id = this.Id,
                Title = this.Title,
                Images = (List<Image>)(from imageDto in this.Images
                         select imageDto.DTOToEntity()),
                UserId = this.UserId
            };
        }
    }
}
