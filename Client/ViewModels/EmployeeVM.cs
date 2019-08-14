namespace BootcampManagement.Client.ViewModels
{
    public class EmployeeVM
    {
        public int Id { get; set; }
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
    }
}