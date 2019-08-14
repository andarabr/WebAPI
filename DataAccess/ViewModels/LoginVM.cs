using System;

namespace DataAccess.ViewModels
{
    public class LoginVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int ApplicationId { get; set; }

        public LoginVM() { }

        public LoginVM(string email, string password, int applicationid)
        {
            this.Email = email;
            this.Password = password;
            this.ApplicationId = applicationid;
        }
    }
}