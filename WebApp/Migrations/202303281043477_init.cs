namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaiHocs",
                c => new
                    {
                        IdBaiHoc = c.Int(nullable: false, identity: true),
                        TenBaiHoc = c.String(nullable: false, maxLength: 200),
                        IdKhoaHoc = c.Long(),
                    })
                .PrimaryKey(t => t.IdBaiHoc);
            
            CreateTable(
                "dbo.BaiTaps",
                c => new
                    {
                        IDBaiTap = c.Int(nullable: false, identity: true),
                        TenBaiTap = c.String(nullable: false, maxLength: 100),
                        NoiDungBaiTap = c.String(nullable: false, maxLength: 500),
                        Diem = c.Int(nullable: false),
                        TrangThaiHoanThanh = c.Int(nullable: false),
                        BaiHoc_IdBaiHoc = c.Int(),
                    })
                .PrimaryKey(t => t.IDBaiTap)
                .ForeignKey("dbo.BaiHocs", t => t.BaiHoc_IdBaiHoc)
                .Index(t => t.BaiHoc_IdBaiHoc);
            
            CreateTable(
                "dbo.BaiViets",
                c => new
                    {
                        IdBaiViet = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(),
                        NoiDungBaiViet = c.String(),
                        HinhAnh = c.String(),
                        NgayDang = c.String(),
                        LuotXem = c.Int(nullable: false),
                        LuotThich = c.Int(nullable: false),
                        NgonNgu = c.Int(nullable: false),
                        DanhMuc = c.Int(nullable: false),
                        User_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdBaiViet)
                .ForeignKey("dbo.Users", t => t.User_IdUser)
                .Index(t => t.User_IdUser);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        TenUser = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        TenTaiKHoan = c.String(nullable: false, maxLength: 50),
                        MatKhau = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdUser);
            
            CreateTable(
                "dbo.CauHois",
                c => new
                    {
                        IdCauHoi = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(),
                        NoiDungCauHoi = c.String(maxLength: 1500),
                        HinhAnh = c.String(),
                        NgayDang = c.String(),
                        LuotXem = c.Int(nullable: false),
                        NgonNgu = c.Int(nullable: false),
                        DanhMuc = c.Int(nullable: false),
                        User_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdCauHoi)
                .ForeignKey("dbo.Users", t => t.User_IdUser)
                .Index(t => t.User_IdUser);
            
            CreateTable(
                "dbo.ChiTietBaiHoc",
                c => new
                    {
                        IdChiTietBaiHoc = c.Int(nullable: false, identity: true),
                        NoiDung1 = c.String(),
                        IdBaiHoc = c.Long(),
                    })
                .PrimaryKey(t => t.IdChiTietBaiHoc);
            
            CreateTable(
                "dbo.ChiTietBaiLuyens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeBai = c.String(nullable: false, maxLength: 1000),
                        YeuCauDauVao = c.String(nullable: true, maxLength: 100),
                        DauVao = c.String(nullable: true, maxLength: 100),
                        DauRa = c.String(nullable: true, maxLength: 100),
                        ViduVao = c.String(nullable: true, maxLength: 100),
                        ViduRa = c.String(nullable: true, maxLength: 100),
                        Diem = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KhoaHocs",
                c => new
                    {
                        IDKhoaHoc = c.Int(nullable: false, identity: true),
                        TenKhoaHoc = c.String(nullable: false, maxLength: 500),
                        NgonNgu = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.IDKhoaHoc);
            
            CreateTable(
                "dbo.LuyenCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenLuyenTap = c.String(nullable: false, maxLength: 255),
                        LuotXem = c.Int(nullable: true),
                        YeuThich = c.Int(nullable: true),
                        NgonNgu = c.Int(nullable: false),
                        DoKho = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhanHois",
                c => new
                    {
                        IDPhanHoi = c.Int(nullable: false, identity: true),
                        NoiDung = c.String(maxLength: 500),
                        HinhAnh = c.String(),
                        NgayDang = c.String(),
                        LuotThich = c.Int(nullable: true),
                        BaiViet_IdBaiViet = c.Int(),
                        CauHoi_IdCauHoi = c.Int(),
                        User_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IDPhanHoi)
                .ForeignKey("dbo.BaiViets", t => t.BaiViet_IdBaiViet)
                .ForeignKey("dbo.CauHois", t => t.CauHoi_IdCauHoi)
                .ForeignKey("dbo.Users", t => t.User_IdUser)
                .Index(t => t.BaiViet_IdBaiViet)
                .Index(t => t.CauHoi_IdCauHoi)
                .Index(t => t.User_IdUser);
            
          
            
        }
        
        public override void Down()
        {
           
        }
    }
}
