using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Base;
using DataAccess.ViewModels;

namespace DataAccess.Models
{
    [Table("TB_M_Employees")]
    public class Employee : BaseModel
    {
        public Employee() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string PhoneNumber { get; set; }
        public int NumOfChildren { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string BankAccount { get; set; }
        public int Salary { get; set; }
        public bool MaritalStatus { get; set; }
        public Employee Manager { get; set; }
        public Religion Religion { get; set; }
        public Role Role { get; set; }
        public Village Village { get; set; }
        public Department Department { get; set; }
        public virtual Login Login { get; set; }




        public Employee(EmployeeVM employeeVM)
        {
            this.FirstName = employeeVM.FirstName;
            this.LastName = employeeVM.LastName;
            this.UserEmail = employeeVM.UserEmail;
            this.PhoneNumber = employeeVM.PhoneNumber;
            this.NumOfChildren = employeeVM.NumOfChildren;
            this.Gender = employeeVM.Gender;
            this.Address = employeeVM.Address;
            this.BankAccount = employeeVM.BankAccount;
            this.Salary = employeeVM.Salary;
            this.MaritalStatus = employeeVM.MaritalStatus;
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public void Update(EmployeeVM employeeVM)
        {
            this.FirstName = employeeVM.FirstName;
            this.LastName = employeeVM.LastName;
            this.UserEmail = employeeVM.UserEmail;
            this.PhoneNumber = employeeVM.PhoneNumber;
            this.NumOfChildren = employeeVM.NumOfChildren;
            this.Gender = employeeVM.Gender;
            this.Address = employeeVM.Address;
            this.BankAccount = employeeVM.BankAccount;
            this.Salary = employeeVM.Salary;
            this.MaritalStatus = employeeVM.MaritalStatus;
            this.UpdateDate = DateTime.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDeleted = true;
            this.DeleteDate = DateTime.Now.ToLocalTime();
        }
    }
}