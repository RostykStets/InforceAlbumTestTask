using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class AdminService : IAdminService
    {
        public readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<AdminDto?> GetAdminById(int adminId)
        {
            Admin? admin = await _adminRepository.GetAdminById(adminId);
            if (admin == null)
            {
                return null;
            }
            return new AdminDto(admin);
        }

        public async Task<AdminDto?> GetAdminByLogin(string login)
        {
            Admin? admin = await _adminRepository.GetAdminByLogin(login);
            if (admin == null)
            {
                return null;
            }
            return new AdminDto(admin);
        }

        public async Task InsertAdmin(AdminDto adminDto)
        {
            await _adminRepository.InsertAdmin(adminDto.DTOToEntity());
        }
    }
}
