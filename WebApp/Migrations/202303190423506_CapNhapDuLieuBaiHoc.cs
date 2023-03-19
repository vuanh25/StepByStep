namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CapNhapDuLieuBaiHoc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BaiHocs", "KhoaHoc_IDKhoaHoc", "dbo.KhoaHocs");
            DropIndex("dbo.BaiHocs", new[] { "KhoaHoc_IDKhoaHoc" });
            DropColumn("dbo.BaiHocs", "KhoaHoc_IDKhoaHoc");

            AddColumn("dbo.BaiHocs", "NoiDung1", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung2", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung3", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung4", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung5", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung6", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung7", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung8", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung9", c => c.String(maxLength: 3000));
            AddColumn("dbo.BaiHocs", "NoiDung10", c => c.String(maxLength: 3000));
        }
        
        public override void Down()
        {

        }
    }
}
