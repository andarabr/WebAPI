using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Base;
using DataAccess.ViewModels;

namespace DataAccess.Models
{
    [Table("TB_T_EmployeeRole")]
    public class EmployeeRole : BaseModel
    {
        public EmployeeRole() { }

        public EmployeeRole(EmployeeRole employeeRole)
        {
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public void Update(EmployeeRole employeeRole)
        {
            this.UpdateDate = DateTime.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDeleted = true;
            this.DeleteDate = DateTime.Now.ToLocalTime();
        }

        public Employee Employee{ get; set; }
        public Role Role{ get; set; }
    }
}