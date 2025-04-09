using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class RegistrationKeyService : IRegistrationKeyService
    {
        private readonly IRegistrationKeyRepository _registrationKeyRepository;
        public RegistrationKeyService(IRegistrationKeyRepository registrationKeyRepository) 
        {
            _registrationKeyRepository = registrationKeyRepository;
        }
        public async Task<RegistrationKeyDto?> getKeyFirst()
        {
            RegistrationKey? registrationKey = await _registrationKeyRepository.getKeyFirst();
            if (registrationKey == null)
            {
                return null;
            }
            return new RegistrationKeyDto(registrationKey);
        }
    }
}
