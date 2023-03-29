namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemTablemuakhoahoc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MuaKhoaHoc",
                c => new
                    {
                        IdMua = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        NgayThanhToan = c.DateTime(nullable: false),
                        ThanhTien = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.IdMua)
                .ForeignKey("dbo.Users", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MuaKhoaHoc", "IdUser", "dbo.Users");
            DropIndex("dbo.MuaKhoaHoc", new[] { "IdUser" });
            DropTable("dbo.MuaKhoaHoc");
        }
    }
}
