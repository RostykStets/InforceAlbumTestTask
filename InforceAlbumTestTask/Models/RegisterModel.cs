using BusinessLogicLayer.DTOs;

namespace InforceAlbumTestTask.Models
{
    public class RegisterModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string RegistrationKey { get; set; }
        public UserType UserType { get; set; }

        public RegisterModel()
        {
            this.Login = string.Empty;
            this.Password = string.Empty;
            this.RegistrationKey = string.Empty;
            this.UserType = UserType.AuthorizedUser;
        }

        public RegisterDto ModelToDto()
        {
            return new RegisterDto
            {
                Login = this.Login,
                Password = this.Password,
                RegistrationKey = this.RegistrationKey,
                UserType = (UserTypeDto)Enum.Parse<UserType>(this.UserType.ToString())
            };
        }
    }
}
