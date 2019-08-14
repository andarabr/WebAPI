namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migratetonewdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_M_Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_T_Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JoinDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        StatusContract = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_M_Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.TB_M_Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserEmail = c.String(),
                        PhoneNumber = c.String(),
                        NumOfChildren = c.Int(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        Address = c.String(),
                        BankAccount = c.String(),
                        Salary = c.Int(nullable: false),
                        MaritalStatus = c.Boolean(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                        Department_Id = c.Int(),
                        Manager_Id = c.Int(),
                        Religion_Id = c.Int(),
                        Role_Id = c.Int(),
                        Village_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_M_Departments", t => t.Department_Id)
                .ForeignKey("dbo.TB_M_Employees", t => t.Manager_Id)
                .ForeignKey("dbo.TB_M_Religions", t => t.Religion_Id)
                .ForeignKey("dbo.TB_M_Roles", t => t.Role_Id)
                .ForeignKey("dbo.TB_M_Villages", t => t.Village_Id)
                .Index(t => t.Department_Id)
                .Index(t => t.Manager_Id)
                .Index(t => t.Religion_Id)
                .Index(t => t.Role_Id)
                .Index(t => t.Village_Id);
            
            CreateTable(
                "dbo.TB_M_Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                        Division_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_M_Divisions", t => t.Division_Id)
                .Index(t => t.Division_Id);
            
            CreateTable(
                "dbo.TB_M_Divisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_M_Religions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_M_Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_M_Villages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                        District_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_M_Districts", t => t.District_Id)
                .Index(t => t.District_Id);
            
            CreateTable(
                "dbo.TB_M_Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                        Regency_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_M_Regencies", t => t.Regency_Id)
                .Index(t => t.Regency_Id);
            
            CreateTable(
                "dbo.TB_M_Regencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                        Province_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_M_Provinces", t => t.Province_Id)
                .Index(t => t.Province_Id);
            
            CreateTable(
                "dbo.TB_M_Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_T_EmployeeRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                        Employee_Id = c.Int(),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_M_Employees", t => t.Employee_Id)
                .ForeignKey("dbo.TB_M_Roles", t => t.Role_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.TB_M_Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_T_LoginApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                        Application_Id = c.Int(),
                        Login_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_M_Applications", t => t.Application_Id)
                .ForeignKey("dbo.TB_M_Logins", t => t.Login_Id)
                .Index(t => t.Application_Id)
                .Index(t => t.Login_Id);
            
            CreateTable(
                "dbo.TB_M_Parameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_T_LoginApplications", "Login_Id", "dbo.TB_M_Logins");
            DropForeignKey("dbo.TB_T_LoginApplications", "Application_Id", "dbo.TB_M_Applications");
            DropForeignKey("dbo.TB_T_EmployeeRoles", "Role_Id", "dbo.TB_M_Roles");
            DropForeignKey("dbo.TB_T_EmployeeRoles", "Employee_Id", "dbo.TB_M_Employees");
            DropForeignKey("dbo.TB_T_Contracts", "Employee_Id", "dbo.TB_M_Employees");
            DropForeignKey("dbo.TB_M_Employees", "Village_Id", "dbo.TB_M_Villages");
            DropForeignKey("dbo.TB_M_Villages", "District_Id", "dbo.TB_M_Districts");
            DropForeignKey("dbo.TB_M_Districts", "Regency_Id", "dbo.TB_M_Regencies");
            DropForeignKey("dbo.TB_M_Regencies", "Province_Id", "dbo.TB_M_Provinces");
            DropForeignKey("dbo.TB_M_Employees", "Role_Id", "dbo.TB_M_Roles");
            DropForeignKey("dbo.TB_M_Employees", "Religion_Id", "dbo.TB_M_Religions");
            DropForeignKey("dbo.TB_M_Employees", "Manager_Id", "dbo.TB_M_Employees");
            DropForeignKey("dbo.TB_M_Employees", "Department_Id", "dbo.TB_M_Departments");
            DropForeignKey("dbo.TB_M_Departments", "Division_Id", "dbo.TB_M_Divisions");
            DropIndex("dbo.TB_T_LoginApplications", new[] { "Login_Id" });
            DropIndex("dbo.TB_T_LoginApplications", new[] { "Application_Id" });
            DropIndex("dbo.TB_T_EmployeeRoles", new[] { "Role_Id" });
            DropIndex("dbo.TB_T_EmployeeRoles", new[] { "Employee_Id" });
            DropIndex("dbo.TB_M_Regencies", new[] { "Province_Id" });
            DropIndex("dbo.TB_M_Districts", new[] { "Regency_Id" });
            DropIndex("dbo.TB_M_Villages", new[] { "District_Id" });
            DropIndex("dbo.TB_M_Departments", new[] { "Division_Id" });
            DropIndex("dbo.TB_M_Employees", new[] { "Village_Id" });
            DropIndex("dbo.TB_M_Employees", new[] { "Role_Id" });
            DropIndex("dbo.TB_M_Employees", new[] { "Religion_Id" });
            DropIndex("dbo.TB_M_Employees", new[] { "Manager_Id" });
            DropIndex("dbo.TB_M_Employees", new[] { "Department_Id" });
            DropIndex("dbo.TB_T_Contracts", new[] { "Employee_Id" });
            DropTable("dbo.TB_M_Parameters");
            DropTable("dbo.TB_T_LoginApplications");
            DropTable("dbo.TB_M_Logins");
            DropTable("dbo.TB_T_EmployeeRoles");
            DropTable("dbo.TB_M_Provinces");
            DropTable("dbo.TB_M_Regencies");
            DropTable("dbo.TB_M_Districts");
            DropTable("dbo.TB_M_Villages");
            DropTable("dbo.TB_M_Roles");
            DropTable("dbo.TB_M_Religions");
            DropTable("dbo.TB_M_Divisions");
            DropTable("dbo.TB_M_Departments");
            DropTable("dbo.TB_M_Employees");
            DropTable("dbo.TB_T_Contracts");
            DropTable("dbo.TB_M_Applications");
        }
    }
}
