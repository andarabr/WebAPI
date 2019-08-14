using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Base;
using DataAccess.ViewModels;
using Newtonsoft.Json;

namespace DataAccess.Models
{
    [Table("TB_M_Logins")]
    public class Login
    {
        public Login() { }
        [ForeignKey("Employee")]
        public int Id { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public DateTimeOffset DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Employee Employee { get; set; }

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

        public ICollection<Application> ListApplications { get; set; }
    }
}