namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doitenkhoahocthanhidkhoahoc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MuaKhoaHoc", "KhoaHoc_IDKhoaHoc", "dbo.KhoaHocs");
            DropIndex("dbo.MuaKhoaHoc", new[] { "KhoaHoc_IDKhoaHoc" });
            AddColumn("dbo.MuaKhoaHoc", "IdKhoaHoc", c => c.Int(nullable: false));
            DropColumn("dbo.MuaKhoaHoc", "TenKhoaHoc");
            DropColumn("dbo.MuaKhoaHoc", "KhoaHoc_IDKhoaHoc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MuaKhoaHoc", "KhoaHoc_IDKhoaHoc", c => c.Int());
            AddColumn("dbo.MuaKhoaHoc", "TenKhoaHoc", c => c.String());
            DropColumn("dbo.MuaKhoaHoc", "IdKhoaHoc");
            CreateIndex("dbo.MuaKhoaHoc", "KhoaHoc_IDKhoaHoc");
            AddForeignKey("dbo.MuaKhoaHoc", "KhoaHoc_IDKhoaHoc", "dbo.KhoaHocs", "IDKhoaHoc");
        }
    }
}
