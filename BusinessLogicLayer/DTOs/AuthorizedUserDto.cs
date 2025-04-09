using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class AuthorizedUserDto : UserDto
    {
        public AuthorizedUserDto()
        {
            this.UserType = UserTypeDto.AuthorizedUser;
        }

        public AuthorizedUserDto(AuthorizedUser user)
        {
            Id = user.Id;
            Login = user.Login;
            PasswordHash = user.PasswordHash;
            UserType = UserTypeDto.AuthorizedUser;
        }

        public AuthorizedUser DTOToEntity()
        {
            return new AuthorizedUser
            {
                Id = this.Id,
                Login = this.Login,
                PasswordHash = this.PasswordHash,
                UserType = DataAccessLayer.Entities.UserType.AuthorizedUser
            };
        }
    }
}
