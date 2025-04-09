using BusinessLogicLayer.DTOs;

namespace InforceAlbumTestTask.Models
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

        public RegistrationKey(RegistrationKeyDto registrationKeyDto)
        {
            this.Id = registrationKeyDto.Id;
            this.Key = registrationKeyDto.Key;
        }

        public RegistrationKeyDto ModelToDTO()
        {
            return new RegistrationKeyDto
            {
                Id = this.Id,
                Key = this.Key
            };
        }
    }
}
