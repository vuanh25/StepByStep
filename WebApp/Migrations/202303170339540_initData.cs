namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initData : DbMigration
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
                        KhoaHoc_IDKhoaHoc = c.Int(),
                    })
                .PrimaryKey(t => t.IdBaiHoc)
                .ForeignKey("dbo.KhoaHocs", t => t.KhoaHoc_IDKhoaHoc)
                .Index(t => t.KhoaHoc_IDKhoaHoc);
            
            CreateTable(
                "dbo.KhoaHocs",
                c => new
                    {
                        IDKhoaHoc = c.Int(nullable: false, identity: true),
                        TenKhoaHoc = c.String(nullable: false, maxLength: 100),
                        CapDo = c.Int(nullable: false),
                        IDNgonNgu = c.Long(),
                        NgonNgu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDKhoaHoc);
            
            CreateTable(
                "dbo.BaiTaps",
                c => new
                    {
                        IDBaiTap = c.Int(nullable: false, identity: true),
                        TenBaiTap = c.String(nullable: false, maxLength: 100),
                        NoiDungBaiTap = c.String(nullable: false, maxLength: 500),
                        Diem = c.Int(nullable: false),
                        TrangThaiHoanThanh = c.Int(nullable: false),
                        IdBaiHoc = c.Long(),
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
                        NoiDungBaiViet = c.String(nullable: false),
                        NgayDang = c.String(nullable: false),
                        LuotXem = c.Int(nullable: false),
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
                        NoiDungCauHoi = c.String(nullable: false, maxLength: 1500),
                        NgayDang = c.String(nullable: false),
                        LuotXem = c.Int(nullable: false),
                        NgonNgu = c.Int(nullable: false),
                        DanhMuc = c.Int(nullable: false),
                        User_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdCauHoi)
                .ForeignKey("dbo.Users", t => t.User_IdUser)
                .Index(t => t.User_IdUser);
            
            CreateTable(
                "dbo.ChiTietBaiLuyens",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DeBai = c.String(nullable: false, maxLength: 1000),
                        YeuCauDauVao = c.String(nullable: false, maxLength: 100),
                        DauVao = c.String(nullable: false, maxLength: 100),
                        DauRa = c.String(nullable: false, maxLength: 100),
                        ViduVao = c.String(nullable: false, maxLength: 100),
                        ViduRa = c.String(nullable: false, maxLength: 100),
                        Diem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LuyenCodes", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.LuyenCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenLuyenTap = c.String(nullable: false, maxLength: 255),
                        YeuThich = c.Int(nullable: false),
                        NgonNgu = c.Int(nullable: false),
                        DoKho = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhanHois",
                c => new
                    {
                        IDPhanHoi = c.Int(nullable: false, identity: true),
                        NoiDung = c.String(nullable: false, maxLength: 500),
                        NgayDang = c.String(nullable: false),
                        LuotThich = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PhanHois", "User_IdUser", "dbo.Users");
            DropForeignKey("dbo.PhanHois", "CauHoi_IdCauHoi", "dbo.CauHois");
            DropForeignKey("dbo.PhanHois", "BaiViet_IdBaiViet", "dbo.BaiViets");
            DropForeignKey("dbo.ChiTietBaiLuyens", "Id", "dbo.LuyenCodes");
            DropForeignKey("dbo.CauHois", "User_IdUser", "dbo.Users");
            DropForeignKey("dbo.BaiViets", "User_IdUser", "dbo.Users");
            DropForeignKey("dbo.BaiTaps", "BaiHoc_IdBaiHoc", "dbo.BaiHocs");
            DropForeignKey("dbo.BaiHocs", "KhoaHoc_IDKhoaHoc", "dbo.KhoaHocs");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PhanHois", new[] { "User_IdUser" });
            DropIndex("dbo.PhanHois", new[] { "CauHoi_IdCauHoi" });
            DropIndex("dbo.PhanHois", new[] { "BaiViet_IdBaiViet" });
            DropIndex("dbo.ChiTietBaiLuyens", new[] { "Id" });
            DropIndex("dbo.CauHois", new[] { "User_IdUser" });
            DropIndex("dbo.BaiViets", new[] { "User_IdUser" });
            DropIndex("dbo.BaiTaps", new[] { "BaiHoc_IdBaiHoc" });
            DropIndex("dbo.BaiHocs", new[] { "KhoaHoc_IDKhoaHoc" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PhanHois");
            DropTable("dbo.LuyenCodes");
            DropTable("dbo.ChiTietBaiLuyens");
            DropTable("dbo.CauHois");
            DropTable("dbo.Users");
            DropTable("dbo.BaiViets");
            DropTable("dbo.BaiTaps");
            DropTable("dbo.KhoaHocs");
            DropTable("dbo.BaiHocs");
        }
    }
}
