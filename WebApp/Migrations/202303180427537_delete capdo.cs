namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecapdo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KhoaHocs", "TenKhoaHoc", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.KhoaHocs", "CapDo");
            DropColumn("dbo.KhoaHocs", "NgonNgu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KhoaHocs", "NgonNgu", c => c.Int(nullable: false));
            AddColumn("dbo.KhoaHocs", "CapDo", c => c.Int(nullable: false));
            AlterColumn("dbo.KhoaHocs", "TenKhoaHoc", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
