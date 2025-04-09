namespace DataAccessLayer.Entities
{
    public class Admin : User
    {
        public Admin()
        {
            this.UserType = UserType.Admin;
        }
    }
}
