namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE_LUYENCODE_CTBT_TABLE : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChiTietBaiLuyens", "Id", "dbo.LuyenCodes");
            DropIndex("dbo.ChiTietBaiLuyens", new[] { "Id" });
            DropPrimaryKey("dbo.ChiTietBaiLuyens");
            AlterColumn("dbo.ChiTietBaiLuyens", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ChiTietBaiLuyens", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ChiTietBaiLuyens");
            AlterColumn("dbo.ChiTietBaiLuyens", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ChiTietBaiLuyens", "Id");
            CreateIndex("dbo.ChiTietBaiLuyens", "Id");
            AddForeignKey("dbo.ChiTietBaiLuyens", "Id", "dbo.LuyenCodes", "Id");
        }
    }
}
