namespace DataAccessLayer.Entities
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
    }
}
