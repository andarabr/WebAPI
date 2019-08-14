namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingtransactionlogin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_T_LoginApplications", "Application_Id", "dbo.TB_M_Applications");
            DropForeignKey("dbo.TB_T_LoginApplications", "Login_Id", "dbo.TB_M_Logins");
            DropIndex("dbo.TB_T_LoginApplications", new[] { "Application_Id" });
            DropIndex("dbo.TB_T_LoginApplications", new[] { "Login_Id" });
            DropTable("dbo.TB_T_LoginApplications");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.TB_T_LoginApplications", "Login_Id");
            CreateIndex("dbo.TB_T_LoginApplications", "Application_Id");
            AddForeignKey("dbo.TB_T_LoginApplications", "Login_Id", "dbo.TB_M_Logins", "Id");
            AddForeignKey("dbo.TB_T_LoginApplications", "Application_Id", "dbo.TB_M_Applications", "Id");
        }
    }
}
