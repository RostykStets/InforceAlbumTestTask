using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class RegistrationKeyDto
    {
        public int Id { get; set; }
        public string Key { get; set; }

        public RegistrationKeyDto() 
        {
            this.Id = 0;
            this.Key = String.Empty;
        }

        public RegistrationKeyDto(RegistrationKey registrationKey)
        {
            this.Id = registrationKey.Id;
            this.Key = registrationKey.Key;
        }
    }
}
