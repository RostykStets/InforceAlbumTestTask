﻿namespace DataAccessLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public UserType UserType { get; set; }

        public User()
        {
            Id = 0;
            Login = string.Empty;
            PasswordHash = string.Empty;
            UserType = UserType.Guest;
        }

        //public bool IsDefault()
        //{
        //    return Id == 0 && Login == string.Empty && PasswordHash == string.Empty;
        //}
    }
}
