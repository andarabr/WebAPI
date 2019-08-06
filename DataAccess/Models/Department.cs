using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Base;
using DataAccess.ViewModels;

namespace DataAccess.Models
{
    [Table("TB_M_Department")]
    public class Department : BaseModel
    {
        public Department() { }
        public string Name { get; set; }

        public Division Division { get; set; }

        public Department(DepartmentVM departmentVM)
        {
            this.Name = departmentVM.Name;
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public void Update(DepartmentVM departmentVM)
        {
            this.Name = departmentVM.Name;
            this.UpdateDate = DateTime.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDeleted = true;
            this.DeleteDate = DateTime.Now.ToLocalTime();
        }
    }
}