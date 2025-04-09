using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IAuthorizedUserRepository
    {
        Task<AuthorizedUser?> GetUserById(int userId);
        Task<AuthorizedUser?> GetUserByLogin(string login);
        Task InsertUser(AuthorizedUser user);
    }
}
