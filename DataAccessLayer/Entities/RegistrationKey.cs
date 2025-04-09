namespace DataAccessLayer.Entities
{
    public class RegistrationKey
    {
        public int Id { get; set; }
        public string Key { get; set; }

        public RegistrationKey()
        {
            this.Id = 0;
            this.Key = String.Empty;
        }
    }
}
