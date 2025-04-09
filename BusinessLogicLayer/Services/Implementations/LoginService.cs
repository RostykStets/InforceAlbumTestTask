using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly IAdminService _adminService;
        private readonly IAuthorizedUserService _authorizedUserService;

        public LoginService(IAdminService adminService, IAuthorizedUserService authorizedUserService)
        {
            _adminService = adminService;
            _authorizedUserService = authorizedUserService;
        }
        public async Task<UserExtendedDto> Login(string login, string password)
        {
            UserExtendedDto userToReturn = new();
            string storedPasswordHash;
            var admin = await _adminService.GetAdminByLogin(login);
            if (admin != null)
            {
                storedPasswordHash = admin.PasswordHash;
                if (BCrypt.Net.BCrypt.EnhancedVerify(password, storedPasswordHash))
                {
                    userToReturn = new UserExtendedDto(admin);
                }
                else
                {
                    userToReturn.ErrorMsg = "Ви ввели неправильний пароль!";
                }
                return userToReturn;
            }
            var user = await _authorizedUserService.GetUserByLogin(login);
            if (user != null)
            {
                storedPasswordHash = user.PasswordHash;
                if (BCrypt.Net.BCrypt.EnhancedVerify(password, storedPasswordHash))
                {
                    userToReturn = new UserExtendedDto(user);
                }
                else
                {
                    userToReturn.ErrorMsg = "Ви ввели неправильний пароль!";
                }
                return userToReturn;
            }

            userToReturn.ErrorMsg = "Користувача з таким логіном не знайдено!";
            return userToReturn;
        }
    }
}
