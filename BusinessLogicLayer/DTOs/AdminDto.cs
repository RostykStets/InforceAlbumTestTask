using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class AdminDto: UserDto
    {
        public AdminDto()
        {
            this.UserType = UserTypeDto.Admin;
        }

        public AdminDto(Admin admin)
        {
            Id = admin.Id;
            Login = admin.Login;
            PasswordHash = admin.PasswordHash;
            UserType = UserTypeDto.Admin;
        }

        public Admin DTOToEntity()
        {
            return new Admin
            {
                Id = this.Id,
                Login = this.Login,
                PasswordHash = this.PasswordHash,
                UserType = DataAccessLayer.Entities.UserType.Admin
            };
        }
    }
}
