using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ILoginService
    {
        Task<UserExtendedDto> Login(string login, string password);
    }
}
