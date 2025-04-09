using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<Admin?> GetAdminById(int adminId);
        Task<Admin?> GetAdminByLogin(string login);
        Task InsertAdmin(Admin admin);
    }
}
