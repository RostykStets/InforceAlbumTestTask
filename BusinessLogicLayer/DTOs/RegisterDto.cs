namespace BusinessLogicLayer.DTOs
{
    public class RegisterDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string RegistrationKey { get; set; }
        public UserTypeDto UserType { get; set; }
    }
}
