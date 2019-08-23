using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    class LoginApplicationVM
    {
        public int LoginId { get; set; }
        public int ApplicationId { get; set; }
    
        public LoginApplicationVM() { }

        public LoginApplicationVM(int loginid, int applicationid)
        {
            this.LoginId = loginid;
            this.ApplicationId = applicationid;
        }
    }
}
