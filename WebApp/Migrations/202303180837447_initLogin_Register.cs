namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initLogin_Register : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BaiHocs", "KhoaHoc_IDKhoaHoc", c => c.Int());
            CreateIndex("dbo.BaiHocs", "KhoaHoc_IDKhoaHoc");
            AddForeignKey("dbo.BaiHocs", "KhoaHoc_IDKhoaHoc", "dbo.KhoaHocs", "IDKhoaHoc");
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
            DropForeignKey("dbo.BaiHocs", "KhoaHoc_IDKhoaHoc", "dbo.KhoaHocs");
            DropIndex("dbo.BaiHocs", new[] { "KhoaHoc_IDKhoaHoc" });
            DropColumn("dbo.BaiHocs", "KhoaHoc_IDKhoaHoc");
        }
    }
}
