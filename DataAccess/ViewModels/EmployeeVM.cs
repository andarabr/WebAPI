namespace DataAccess.ViewModels
{
    public class EmployeeVM
    {
        //public int Id { get; set; }
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
        public int ManagerId { get; set; }
        public int ReligionId { get; set; }
        public int RoleId { get; set; }
        public int VillageId { get; set; }
        public int DepartmentId { get; set; }
        public EmployeeVM() { }

        public EmployeeVM(string firstname, string lastname, string useremail, string phonenumber, int numofchildreen, bool gender, string address, string bankaccount, int salary, bool maritalstatus, int managerid, int religionid, int roleid, int villageid, int departmentid)
        {
            //this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.UserEmail = useremail;
            this.PhoneNumber = phonenumber;
            this.NumOfChildren = numofchildreen;
            this.Gender = gender;
            this.Address = address;
            this.BankAccount = bankaccount;
            this.Salary = salary;
            this.MaritalStatus = maritalstatus;
            this.ManagerId = managerid;
            this.ReligionId = religionid;
            this.RoleId = roleid;
            this.VillageId = villageid;
            this.DepartmentId = departmentid;
        }

        public void Update(string firstname, string lastname, string useremail, string phonenumber, int numofchildreen, bool gender, string address, string bankaccount, int salary, bool maritalstatus, int managerid, int religionid, int roleid, int villageid, int departmentid)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.UserEmail = useremail;
            this.PhoneNumber = phonenumber;
            this.NumOfChildren = numofchildreen;
            this.Gender = gender;
            this.Address = address;
            this.BankAccount = bankaccount;
            this.Salary = salary;
            this.MaritalStatus = maritalstatus;
            this.ManagerId = managerid;
            this.ReligionId = religionid;
            this.RoleId = roleid;
            this.VillageId = villageid;
            this.DepartmentId = departmentid;
        }
    }
}