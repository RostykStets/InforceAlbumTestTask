using BusinessLogicLayer.Services.Interfaces;
using InforceAlbumTestTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace InforceAlbumTestTask.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        private readonly ILogger _logger;

        public AuthenticationController(ILoginService loginService, IRegisterService registerService, ILogger<AuthenticationController> logger)
        {
            _loginService = loginService;
            _registerService = registerService;
            _logger = logger;
        }

        public IActionResult Login()
        {
            _logger.Log(LogLevel.Information, "Entering Login Page at {0}!", DateTime.Now);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            _logger.Log(LogLevel.Information, "User with login:{0} tries to login at {1}!", loginViewModel.Login, DateTime.Now);
            var user = await _loginService.Login(loginViewModel.Login, loginViewModel.Password);
            if (!user.ErrorMsg.Equals(""))
            {
                if(TempData != null)
                {
                    TempData["ErrorMessage"] = user.ErrorMsg;
                }
                _logger.Log(LogLevel.Error, "LoginVew error at {0}: {1}", DateTime.Now, user.ErrorMsg);
                return View(loginViewModel);
            }
            _logger.Log(LogLevel.Information, "User with login:{0} logged in at {1}!", loginViewModel.Login, DateTime.Now);
            return RedirectToAction("Index", "Albums", new User(user));
        }

        public IActionResult Register()
        {
            _logger.Log(LogLevel.Information, "Entering Register Page at {0}!", DateTime.Now);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            _logger.Log(LogLevel.Information, "User with login:{0} tries to register at {1}!", registerViewModel.Login, DateTime.Now);
            if (!registerViewModel.Password.Equals(registerViewModel.ConfirmPassword))
            {
                //TempData["ErrorMessage"] = "Паролі не співпадають!";
                if(TempData != null)
                {
                    TempData["ErrorMessage"] = "Паролі не співпадають!";
                }
                _logger.Log(LogLevel.Error, "Register view error at {0}: Passwords do not match!", DateTime.Now);
                return View(registerViewModel);
            }

            RegisterModel model = new RegisterModel();
            model.Login = registerViewModel.Login;
            model.Password = registerViewModel.Password;
            model.UserType = registerViewModel.UserType;
            model.RegistrationKey = registerViewModel.RegistrationKey;

            var user = await _registerService.Register(model.ModelToDto());

            if (!user.ErrorMsg.Equals(""))
            {
                //TempData["ErrorMessage"] = user.ErrorMsg;
                if (TempData != null)
                {
                    TempData["ErrorMessage"] = user.ErrorMsg;
                }
                _logger.Log(LogLevel.Error, "Register view error at {0}: {1}", DateTime.Now, user.ErrorMsg);
                return View(registerViewModel);
            }

            _logger.Log(LogLevel.Information, "User with login: {0} registered successfully at {1}", user.Login, DateTime.Now);

            return RedirectToAction("Index", "Albums", user);
        }
    }
}
