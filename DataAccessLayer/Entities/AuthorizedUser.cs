namespace DataAccessLayer.Entities
{
    public class AuthorizedUser : User
    {
        public AuthorizedUser()
        {
            this.UserType = UserType.AuthorizedUser;
        }
    }
}
