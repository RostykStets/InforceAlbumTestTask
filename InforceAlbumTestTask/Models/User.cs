using BusinessLogicLayer.DTOs;

namespace InforceAlbumTestTask.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public UserType UserType { get; set; }

        public User()
        {
            Id = 0;
            Login = string.Empty;
            PasswordHash = string.Empty;
            UserType = UserType.Guest;
        }

        public User(UserDto userDto)
        {
            Id = userDto.Id;
            Login = userDto.Login;
            PasswordHash = userDto.PasswordHash;
            UserType = (UserType)Enum.Parse<UserTypeDto>(userDto.UserType.ToString());
        }

        public User(UserExtendedDto userDto)
        {
            Id = userDto.Id;
            Login = userDto.Login;
            PasswordHash = userDto.PasswordHash;
            UserType = (UserType)Enum.Parse<UserTypeDto>(userDto.UserType.ToString());
        }

        public UserDto ModelToDto()
        {
            return new UserDto
            {
                Id = this.Id,
                Login = this.Login,
                PasswordHash = this.PasswordHash,
                UserType = (UserTypeDto)Enum.Parse<UserType>(this.UserType.ToString())
            };
        }

        public bool IsDefault()
        {
            return Id == 0 && Login == string.Empty && PasswordHash == string.Empty;
        }
    }
}
