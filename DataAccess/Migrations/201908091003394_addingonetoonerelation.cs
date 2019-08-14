namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingonetoonerelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoginApplications", "Login_Id", "dbo.TB_M_Logins");
            DropPrimaryKey("dbo.TB_M_Logins");
            AlterColumn("dbo.TB_M_Logins", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TB_M_Logins", "Id");
            CreateIndex("dbo.TB_M_Logins", "Id");
            AddForeignKey("dbo.TB_M_Logins", "Id", "dbo.TB_M_Employees", "Id");
            AddForeignKey("dbo.LoginApplications", "Login_Id", "dbo.TB_M_Logins", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoginApplications", "Login_Id", "dbo.TB_M_Logins");
            DropForeignKey("dbo.TB_M_Logins", "Id", "dbo.TB_M_Employees");
            DropIndex("dbo.TB_M_Logins", new[] { "Id" });
            DropPrimaryKey("dbo.TB_M_Logins");
            AlterColumn("dbo.TB_M_Logins", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TB_M_Logins", "Id");
            AddForeignKey("dbo.LoginApplications", "Login_Id", "dbo.TB_M_Logins", "Id", cascadeDelete: true);
        }
    }
}
