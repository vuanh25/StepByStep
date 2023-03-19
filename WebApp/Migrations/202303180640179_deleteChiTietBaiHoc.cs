namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteChiTietBaiHoc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChiTietBaiHoc", "BaiHoc_IdBaiHoc", "dbo.BaiHocs");
            DropIndex("dbo.ChiTietBaiHoc", new[] { "BaiHoc_IdBaiHoc" });
            DropTable("dbo.ChiTietBaiHoc");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ChiTietBaiHoc",
                c => new
                    {
                        IdChiTietBaiHoc = c.Int(nullable: false, identity: true),
                        NoiDungBaiHoc = c.String(nullable: false, maxLength: 3000),
                        BaiHoc_IdBaiHoc = c.Int(),
                    })
                .PrimaryKey(t => t.IdChiTietBaiHoc);
            
            CreateIndex("dbo.ChiTietBaiHoc", "BaiHoc_IdBaiHoc");
            AddForeignKey("dbo.ChiTietBaiHoc", "BaiHoc_IdBaiHoc", "dbo.BaiHocs", "IdBaiHoc");
        }
    }
}
