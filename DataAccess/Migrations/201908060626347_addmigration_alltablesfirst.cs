namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigration_alltablesfirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_T_Contract",
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
                .ForeignKey("dbo.TB_M_Employee", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.TB_M_Employee",
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
                .ForeignKey("dbo.TB_M_Department", t => t.Department_Id)
                .ForeignKey("dbo.TB_M_Employee", t => t.Manager_Id)
                .ForeignKey("dbo.TB_M_Religion", t => t.Religion_Id)
                .ForeignKey("dbo.TB_M_Role", t => t.Role_Id)
                .ForeignKey("dbo.TB_M_Village", t => t.Village_Id)
                .Index(t => t.Department_Id)
                .Index(t => t.Manager_Id)
                .Index(t => t.Religion_Id)
                .Index(t => t.Role_Id)
                .Index(t => t.Village_Id);
            
            CreateTable(
                "dbo.TB_M_Department",
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
                .ForeignKey("dbo.TB_M_Division", t => t.Division_Id)
                .Index(t => t.Division_Id);
            
            CreateTable(
                "dbo.TB_M_Division",
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
                "dbo.TB_M_Religion",
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
                "dbo.TB_M_Role",
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
                "dbo.TB_M_Village",
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
                .ForeignKey("dbo.TB_M_District", t => t.District_Id)
                .Index(t => t.District_Id);
            
            CreateTable(
                "dbo.TB_M_District",
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
                .ForeignKey("dbo.Regencies", t => t.Regency_Id)
                .Index(t => t.Regency_Id);
            
            CreateTable(
                "dbo.Regencies",
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
                .ForeignKey("dbo.TB_M_Province", t => t.Province_Id)
                .Index(t => t.Province_Id);
            
            CreateTable(
                "dbo.TB_M_Province",
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
                "dbo.TB_T_EmployeeRole",
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
                .ForeignKey("dbo.TB_M_Employee", t => t.Employee_Id)
                .ForeignKey("dbo.TB_M_Role", t => t.Role_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.TB_M_Login",
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
                "dbo.TB_T_LoginApplication",
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
                .ForeignKey("dbo.TB_M_Application", t => t.Application_Id)
                .ForeignKey("dbo.TB_M_Login", t => t.Login_Id)
                .Index(t => t.Application_Id)
                .Index(t => t.Login_Id);
            
            CreateTable(
                "dbo.TB_M_Application",
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
                "dbo.TB_M_Parameter",
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
            DropForeignKey("dbo.TB_T_LoginApplication", "Login_Id", "dbo.TB_M_Login");
            DropForeignKey("dbo.TB_T_LoginApplication", "Application_Id", "dbo.TB_M_Application");
            DropForeignKey("dbo.TB_T_EmployeeRole", "Role_Id", "dbo.TB_M_Role");
            DropForeignKey("dbo.TB_T_EmployeeRole", "Employee_Id", "dbo.TB_M_Employee");
            DropForeignKey("dbo.TB_T_Contract", "Employee_Id", "dbo.TB_M_Employee");
            DropForeignKey("dbo.TB_M_Employee", "Village_Id", "dbo.TB_M_Village");
            DropForeignKey("dbo.TB_M_Village", "District_Id", "dbo.TB_M_District");
            DropForeignKey("dbo.TB_M_District", "Regency_Id", "dbo.Regencies");
            DropForeignKey("dbo.Regencies", "Province_Id", "dbo.TB_M_Province");
            DropForeignKey("dbo.TB_M_Employee", "Role_Id", "dbo.TB_M_Role");
            DropForeignKey("dbo.TB_M_Employee", "Religion_Id", "dbo.TB_M_Religion");
            DropForeignKey("dbo.TB_M_Employee", "Manager_Id", "dbo.TB_M_Employee");
            DropForeignKey("dbo.TB_M_Employee", "Department_Id", "dbo.TB_M_Department");
            DropForeignKey("dbo.TB_M_Department", "Division_Id", "dbo.TB_M_Division");
            DropIndex("dbo.TB_T_LoginApplication", new[] { "Login_Id" });
            DropIndex("dbo.TB_T_LoginApplication", new[] { "Application_Id" });
            DropIndex("dbo.TB_T_EmployeeRole", new[] { "Role_Id" });
            DropIndex("dbo.TB_T_EmployeeRole", new[] { "Employee_Id" });
            DropIndex("dbo.Regencies", new[] { "Province_Id" });
            DropIndex("dbo.TB_M_District", new[] { "Regency_Id" });
            DropIndex("dbo.TB_M_Village", new[] { "District_Id" });
            DropIndex("dbo.TB_M_Department", new[] { "Division_Id" });
            DropIndex("dbo.TB_M_Employee", new[] { "Village_Id" });
            DropIndex("dbo.TB_M_Employee", new[] { "Role_Id" });
            DropIndex("dbo.TB_M_Employee", new[] { "Religion_Id" });
            DropIndex("dbo.TB_M_Employee", new[] { "Manager_Id" });
            DropIndex("dbo.TB_M_Employee", new[] { "Department_Id" });
            DropIndex("dbo.TB_T_Contract", new[] { "Employee_Id" });
            DropTable("dbo.TB_M_Parameter");
            DropTable("dbo.TB_M_Application");
            DropTable("dbo.TB_T_LoginApplication");
            DropTable("dbo.TB_M_Login");
            DropTable("dbo.TB_T_EmployeeRole");
            DropTable("dbo.TB_M_Province");
            DropTable("dbo.Regencies");
            DropTable("dbo.TB_M_District");
            DropTable("dbo.TB_M_Village");
            DropTable("dbo.TB_M_Role");
            DropTable("dbo.TB_M_Religion");
            DropTable("dbo.TB_M_Division");
            DropTable("dbo.TB_M_Department");
            DropTable("dbo.TB_M_Employee");
            DropTable("dbo.TB_T_Contract");
        }
    }
}
