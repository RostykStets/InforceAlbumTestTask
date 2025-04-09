using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public UserTypeDto UserType { get; set; }

        public UserDto()
        {
            Id = 0;
            Login = string.Empty;
            PasswordHash = string.Empty;
            UserType = UserTypeDto.Guest;
        }

        public UserDto(User user)
        {
            Id = user.Id;
            Login = user.Login;
            PasswordHash = user.PasswordHash;
            UserType = (UserTypeDto)Enum.Parse<UserType>(user.UserType.ToString());
        }

        public User DTOToEntity()
        {
            return new User
            {
                Id = Id,
                Login = Login,
                PasswordHash = PasswordHash,
                UserType = (UserType)Enum.Parse<UserTypeDto>(this.UserType.ToString())
            };
        }
    }
}
