using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<UserExtendedDto> Register(RegisterDto userToRegister);
    }
}
