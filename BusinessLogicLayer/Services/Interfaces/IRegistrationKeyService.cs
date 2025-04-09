using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IRegistrationKeyService
    {
        Task<RegistrationKeyDto?> getKeyFirst();
    }
}
