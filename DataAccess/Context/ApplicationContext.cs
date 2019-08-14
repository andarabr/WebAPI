using System.Data.Entity;
using System.Net.Mime;
using DataAccess.Models;

namespace DataAccess.Context
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext() : base("API") { }

        //Roles dibawah sebagai object
        public DbSet<Role> Role { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Religion> Religion { get; set; }
        public DbSet<Parameter> Parameter { get; set; }
        public DbSet<Login> Login { get; set; }
        //public DbSet<MediaTypeNames.Application> Application { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Regency> Regency { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Village> Village { get; set; }
        public DbSet<Employee> Employee { get; set; }
        //public DbSet<LoginApplication> LoginApplication { get; set; }
        public DbSet<Models.Contract> Contract { get; set; }
        public DbSet<EmployeeRole> EmployeeRole { get; set; }
    }
}