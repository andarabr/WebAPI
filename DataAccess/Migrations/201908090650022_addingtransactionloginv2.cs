namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingtransactionloginv2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginApplications",
                c => new
                    {
                        Login_Id = c.Int(nullable: false),
                        Application_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Login_Id, t.Application_Id })
                .ForeignKey("dbo.TB_M_Logins", t => t.Login_Id, cascadeDelete: true)
                .ForeignKey("dbo.TB_M_Applications", t => t.Application_Id, cascadeDelete: true)
                .Index(t => t.Login_Id)
                .Index(t => t.Application_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoginApplications", "Application_Id", "dbo.TB_M_Applications");
            DropForeignKey("dbo.LoginApplications", "Login_Id", "dbo.TB_M_Logins");
            DropIndex("dbo.LoginApplications", new[] { "Application_Id" });
            DropIndex("dbo.LoginApplications", new[] { "Login_Id" });
            DropTable("dbo.LoginApplications");
        }
    }
}
