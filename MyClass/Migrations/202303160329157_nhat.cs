namespace MyClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nhat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaiHoc",
                c => new
                    {
                        IDBaiHoc = c.Int(nullable: false, identity: true),
                        TenBaiHoc = c.String(nullable: false, maxLength: 100),
                        IdKhoaHoc = c.Long(),
                        KhoaHoc_IDKhoaHoc = c.Int(),
                    })
                .PrimaryKey(t => t.IDBaiHoc)
                .ForeignKey("dbo.KhoaHoc", t => t.KhoaHoc_IDKhoaHoc)
                .Index(t => t.KhoaHoc_IDKhoaHoc);
            
            CreateTable(
                "dbo.KhoaHoc",
                c => new
                    {
                        IDKhoaHoc = c.Int(nullable: false, identity: true),
                        TenKhoaHoc = c.String(nullable: false, maxLength: 100),
                        CapDo = c.Int(nullable: false),
                        IDNgonNgu = c.Long(),
                        NgonNgu_IDNgonNgu = c.Int(),
                    })
                .PrimaryKey(t => t.IDKhoaHoc)
                .ForeignKey("dbo.NgonNgu", t => t.NgonNgu_IDNgonNgu)
                .Index(t => t.NgonNgu_IDNgonNgu);
            
            CreateTable(
                "dbo.NgonNgu",
                c => new
                    {
                        IDNgonNgu = c.Int(nullable: false, identity: true),
                        TenNgonNgu = c.String(nullable: false),
                        IDDanhMuc = c.Long(),
                        DanhMuc_IDDanhMuc = c.Int(),
                    })
                .PrimaryKey(t => t.IDNgonNgu)
                .ForeignKey("dbo.DanhMuc", t => t.DanhMuc_IDDanhMuc)
                .Index(t => t.DanhMuc_IDDanhMuc);
            
            CreateTable(
                "dbo.DanhMuc",
                c => new
                    {
                        IDDanhMuc = c.Int(nullable: false, identity: true),
                        TenDanhMuc = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.IDDanhMuc);
            
            CreateTable(
                "dbo.BaiTap",
                c => new
                    {
                        IDBaiTap = c.Int(nullable: false, identity: true),
                        NoiDungBaiTap = c.String(nullable: false, maxLength: 2000),
                        TenBaiTap = c.String(nullable: false, maxLength: 255),
                        IDBaiHoc = c.Long(),
                        BaiHoc_IDBaiHoc = c.Int(),
                    })
                .PrimaryKey(t => t.IDBaiTap)
                .ForeignKey("dbo.BaiHoc", t => t.BaiHoc_IDBaiHoc)
                .Index(t => t.BaiHoc_IDBaiHoc);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        IDUser = c.Int(nullable: false, identity: true),
                        TenUser = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        TenTaiKHoan = c.String(nullable: false, maxLength: 50),
                        MatKhau = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IDUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BaiTap", "BaiHoc_IDBaiHoc", "dbo.BaiHoc");
            DropForeignKey("dbo.BaiHoc", "KhoaHoc_IDKhoaHoc", "dbo.KhoaHoc");
            DropForeignKey("dbo.KhoaHoc", "NgonNgu_IDNgonNgu", "dbo.NgonNgu");
            DropForeignKey("dbo.NgonNgu", "DanhMuc_IDDanhMuc", "dbo.DanhMuc");
            DropIndex("dbo.BaiTap", new[] { "BaiHoc_IDBaiHoc" });
            DropIndex("dbo.NgonNgu", new[] { "DanhMuc_IDDanhMuc" });
            DropIndex("dbo.KhoaHoc", new[] { "NgonNgu_IDNgonNgu" });
            DropIndex("dbo.BaiHoc", new[] { "KhoaHoc_IDKhoaHoc" });
            DropTable("dbo.User");
            DropTable("dbo.BaiTap");
            DropTable("dbo.DanhMuc");
            DropTable("dbo.NgonNgu");
            DropTable("dbo.KhoaHoc");
            DropTable("dbo.BaiHoc");
        }
    }
}
