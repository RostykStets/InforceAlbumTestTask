using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthorizedUserService
    {
        Task<AuthorizedUserDto?> GetUserById(int userId);
        Task<AuthorizedUserDto?> GetUserByLogin(string login);
        Task InsertUser(AuthorizedUserDto userDto);
    }
}
