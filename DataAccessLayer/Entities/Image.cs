namespace DataAccessLayer.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public uint LikeCounter { get; set; }
        public uint DislikeCounter { get; set; }
        public int AlbumId {get; set; }

        public Image() 
        {
            this.Id = 0;
            this.Title = string.Empty;
            this.ImageUrl = String.Empty;
            this.LikeCounter = 0;
            this.DislikeCounter = 0;
        }
    }
}
