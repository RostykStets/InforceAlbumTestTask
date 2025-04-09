using BusinessLogicLayer.DTOs;

namespace InforceAlbumTestTask.Models
{
    public class Admin : User
    {
        public Admin(): base() 
        {
            this.UserType = UserType.Admin;
        }

        public Admin(AdminDto adminDto) : base(adminDto) { }

        public AdminDto ModelToDto()
        {
            return (AdminDto) base.ModelToDto();
        }
    }
}
