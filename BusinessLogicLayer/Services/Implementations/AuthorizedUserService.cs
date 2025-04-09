using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class AuthorizedUserService : IAuthorizedUserService
    {
        private readonly IAuthorizedUserRepository _authorizedUserRepository;
        public AuthorizedUserService(IAuthorizedUserRepository authorizedUserRepository) 
        {
            _authorizedUserRepository = authorizedUserRepository;
        }

        public async Task<AuthorizedUserDto?> GetUserById(int userId)
        {
            AuthorizedUser? user = await _authorizedUserRepository.GetUserById(userId);
            if (user == null)
            {
                return null;
            }
            return new AuthorizedUserDto(user);
        }

        public async Task<AuthorizedUserDto?> GetUserByLogin(string login)
        {
            AuthorizedUser? user = await _authorizedUserRepository.GetUserByLogin(login);
            if (user == null)
            {
                return null;
            }
            return new AuthorizedUserDto(user);
        }

        public async Task InsertUser(AuthorizedUserDto userDto)
        {
            await _authorizedUserRepository.InsertUser(userDto.DTOToEntity());
        }
    }
}
