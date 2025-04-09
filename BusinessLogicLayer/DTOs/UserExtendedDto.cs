
namespace BusinessLogicLayer.DTOs
{
    public class UserExtendedDto : UserDto
    {
        public string ErrorMsg { get; set; }

        public UserExtendedDto() : base() 
        {
            ErrorMsg = string.Empty;
        }

        public UserExtendedDto(AdminDto adminDto)
        {
            this.Id = adminDto.Id;
            this.Login = adminDto.Login;
            this.PasswordHash = adminDto.PasswordHash;
            this.UserType = adminDto.UserType;
            this.ErrorMsg = string.Empty;
        }

        public UserExtendedDto(AuthorizedUserDto authorizedUserDto)
        {
            this.Id = authorizedUserDto.Id;
            this.Login = authorizedUserDto.Login;
            this.PasswordHash = authorizedUserDto.PasswordHash;
            this.UserType = authorizedUserDto.UserType;
            this.ErrorMsg = String.Empty;
        }
    }
}
