namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableChiTietBaiHoc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietBaiHoc",
                c => new
                    {
                        IdChiTietBaiHoc = c.Int(nullable: false, identity: true),
                        NoiDungBaiHoc = c.String(nullable: false, maxLength: 3000),
                        BaiHoc_IdBaiHoc = c.Int(),
                    })
                .PrimaryKey(t => t.IdChiTietBaiHoc)
                .ForeignKey("dbo.BaiHocs", t => t.BaiHoc_IdBaiHoc)
                .Index(t => t.BaiHoc_IdBaiHoc);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietBaiHoc", "BaiHoc_IdBaiHoc", "dbo.BaiHocs");
            DropIndex("dbo.ChiTietBaiHoc", new[] { "BaiHoc_IdBaiHoc" });
            DropTable("dbo.ChiTietBaiHoc");
        }
    }
}
