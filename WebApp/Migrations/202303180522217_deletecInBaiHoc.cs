namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecInBaiHoc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BaiHocs", "KhoaHoc_IDKhoaHoc", "dbo.KhoaHocs");
            DropIndex("dbo.BaiHocs", new[] { "KhoaHoc_IDKhoaHoc" });
            DropColumn("dbo.BaiHocs", "KhoaHoc_IDKhoaHoc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BaiHocs", "KhoaHoc_IDKhoaHoc", c => c.Int());
            CreateIndex("dbo.BaiHocs", "KhoaHoc_IDKhoaHoc");
            AddForeignKey("dbo.BaiHocs", "KhoaHoc_IDKhoaHoc", "dbo.KhoaHocs", "IDKhoaHoc");
        }
    }
}
