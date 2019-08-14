using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Base;
using DataAccess.ViewModels;

namespace DataAccess.Models
{
    [Table("TB_T_LoginApplications")]
    public class LoginApplication : BaseModel
    {
        public LoginApplication() { }

        public LoginApplication(LoginApplicationVM loginApplicationVM)
        {
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public void Update(LoginApplicationVM loginApplicationVM)
        {
            this.UpdateDate = DateTime.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDeleted = true;
            this.DeleteDate = DateTime.Now.ToLocalTime();
        }

        public Login Login { get; set; }
        public Application Application { get; set; }


    }
}