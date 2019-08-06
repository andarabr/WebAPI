using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Base;
using DataAccess.ViewModels;

namespace DataAccess.Models
{
    [Table("TB_M_Login")]
    public class Login : BaseModel
    {
        public Login() { }

        public Login(LoginVM loginVM)
        {
            this.Email = loginVM.Email;
            this.Password = loginVM.Password;
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public void Update(LoginVM loginVM)
        {
            this.Email = loginVM.Email;
            this.Password = loginVM.Password;
            this.UpdateDate = DateTime.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDeleted = true;
            this.DeleteDate = DateTime.Now.ToLocalTime();
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}