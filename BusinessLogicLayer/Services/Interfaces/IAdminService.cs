using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAdminService
    {
        Task<AdminDto?> GetAdminById(int adminId);
        Task<AdminDto?> GetAdminByLogin(string login);
        Task InsertAdmin(AdminDto adminDto);
    }
}
