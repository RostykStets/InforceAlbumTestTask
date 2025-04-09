using BusinessLogicLayer.DTOs;

namespace InforceAlbumTestTask.Models
{
    public class AuthorizedUser : User
    {
        public AuthorizedUser() : base()
        {
            this.UserType = UserType.AuthorizedUser;
        }

        public AuthorizedUser(AuthorizedUserDto authorizedUserDto) : base(authorizedUserDto) { }

        public AuthorizedUserDto ModelToDto()
        {
            return (AuthorizedUserDto) base.ModelToDto();
        }
    }
}
