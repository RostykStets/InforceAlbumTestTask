using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IRegistrationKeyRepository
    {
        Task<RegistrationKey?> getKeyFirst();
    }
}
