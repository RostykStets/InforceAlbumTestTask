using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;


namespace BusinessLogicLayer.Services.Implementations
{
    public class RegisterService : IRegisterService
    {
        private readonly IAdminService _adminService;
        private readonly IAuthorizedUserService _authorizedUserService;
        private readonly IRegistrationKeyService _registrationKeyService;

        public RegisterService(IAdminService adminService, IAuthorizedUserService authorizedUserService, IRegistrationKeyService registrationKeyService)
        {
            _adminService = adminService;
            _authorizedUserService = authorizedUserService;
            _registrationKeyService = registrationKeyService;
        }
        public async Task<UserExtendedDto> Register(RegisterDto userToRegister)
        {
            UserExtendedDto userToReturn = new();

            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(userToRegister.Password);
            if (userToRegister.UserType == UserTypeDto.Admin)
            {
                var registrationKey = await _registrationKeyService.getKeyFirst();
                if (userToRegister.RegistrationKey == String.Empty || userToRegister.RegistrationKey == "")
                {
                    userToReturn.ErrorMsg = "Ви не ввели реєстраційний ключ!";
                    return userToReturn;
                }
                if (!registrationKey.Key.Equals(userToRegister.RegistrationKey))
                {
                    userToReturn.ErrorMsg = "Ви ввели неправильний реєстраційний ключ!";
                    return userToReturn;
                }

                var admin = await _adminService.GetAdminByLogin(userToRegister.Login);
                if (admin == null)
                {
                    admin = new AdminDto();
                    admin.Login = userToRegister.Login;
                    admin.PasswordHash = passwordHash;
                    admin.UserType = UserTypeDto.Admin;
                    await _adminService.InsertAdmin(admin);
                    admin = await _adminService.GetAdminByLogin(admin.Login);
                    userToReturn = new UserExtendedDto(admin);
                    return userToReturn;
                }
                else
                    userToReturn.ErrorMsg = "Адміністратор з таким логіном вже існує!";
            }
            else if (userToRegister.UserType == UserTypeDto.AuthorizedUser)
            {
                var user = await _authorizedUserService.GetUserByLogin(userToRegister.Login);
                if (user == null)
                {
                    user = new AuthorizedUserDto();
                    user.Login = userToRegister.Login;
                    user.PasswordHash = passwordHash;
                    user.UserType = UserTypeDto.AuthorizedUser;
                    await _authorizedUserService.InsertUser(user);
                    user = await _authorizedUserService.GetUserByLogin(user.Login);
                    userToReturn = new UserExtendedDto(user);
                    return userToReturn;
                }
                else
                    userToReturn.ErrorMsg = "Користувач з таким логіном вже існує!";
            }

            return userToReturn;
        }
    }
}
