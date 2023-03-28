namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capnhaplaikhoahoavamuakhoahoc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MuaKhoaHoc", "KhoaHoc_IDKhoaHoc", c => c.Int());
            AddColumn("dbo.KhoaHocs", "GiaGoiKhoaHoc", c => c.Decimal(storeType: "money"));
            CreateIndex("dbo.MuaKhoaHoc", "KhoaHoc_IDKhoaHoc");
            AddForeignKey("dbo.MuaKhoaHoc", "KhoaHoc_IDKhoaHoc", "dbo.KhoaHocs", "IDKhoaHoc");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MuaKhoaHoc", "KhoaHoc_IDKhoaHoc", "dbo.KhoaHocs");
            DropIndex("dbo.MuaKhoaHoc", new[] { "KhoaHoc_IDKhoaHoc" });
            DropColumn("dbo.KhoaHocs", "GiaGoiKhoaHoc");
            DropColumn("dbo.MuaKhoaHoc", "KhoaHoc_IDKhoaHoc");
        }
    }
}
