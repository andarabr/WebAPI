using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    public class EmployeeRoleVM
    {
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }

        public EmployeeRoleVM() { }

        public EmployeeRoleVM(int EmployeeId, int RoleId)
        {
            this.EmployeeId = EmployeeId;
            this.RoleId = RoleId;
        }

        public void Update(int EmployeeId, int RoleId)
        {
            this.EmployeeId = EmployeeId;
            this.RoleId = RoleId;
        }
    }
}
