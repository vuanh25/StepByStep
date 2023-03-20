namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themchitietbaihoc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietBaiHoc",
                c => new
                    {
                        IdChiTietBaiHoc = c.Int(nullable: false, identity: true),
                        NoiDung1 = c.String(maxLength: 3000),
                        NoiDung2 = c.String(maxLength: 3000),
                        NoiDung3 = c.String(maxLength: 3000),
                        NoiDung4 = c.String(maxLength: 3000),
                        NoiDung5 = c.String(maxLength: 3000),
                        NoiDung6 = c.String(maxLength: 3000),
                        NoiDung7 = c.String(maxLength: 3000),
                        NoiDung8 = c.String(maxLength: 3000),
                        NoiDung9 = c.String(maxLength: 3000),
                        NoiDung10 = c.String(maxLength: 3000),
                        IdBaiHoc = c.Long(),
                    })
                .PrimaryKey(t => t.IdChiTietBaiHoc);
            
            DropColumn("dbo.BaiHocs", "NoiDung1");
            DropColumn("dbo.BaiHocs", "NoiDung2");
            DropColumn("dbo.BaiHocs", "NoiDung3");
            DropColumn("dbo.BaiHocs", "NoiDung4");
            DropColumn("dbo.BaiHocs", "NoiDung5");
            DropColumn("dbo.BaiHocs", "NoiDung6");
            DropColumn("dbo.BaiHocs", "NoiDung7");
            DropColumn("dbo.BaiHocs", "NoiDung8");
            DropColumn("dbo.BaiHocs", "NoiDung9");
            DropColumn("dbo.BaiHocs", "NoiDung10");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BaiHocs", "NoiDung10", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung9", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung8", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung7", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung6", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung5", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung4", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung3", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung2", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung1", c => c.String(maxLength: 3000));
            DropTable("dbo.ChiTietBaiHoc");
        }
    }
}
