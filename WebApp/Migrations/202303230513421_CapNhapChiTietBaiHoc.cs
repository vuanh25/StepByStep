namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CapNhapChiTietBaiHoc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChiTietBaiHoc", "NoiDung2", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChiTietBaiHoc", "NoiDung2", c => c.String(maxLength: 3000));
        }
    }
}
