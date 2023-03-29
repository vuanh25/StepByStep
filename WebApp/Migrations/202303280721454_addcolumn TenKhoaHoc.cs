namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumnTenKhoaHoc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MuaKhoaHoc", "TenKhoaHoc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MuaKhoaHoc", "TenKhoaHoc");
        }
    }
}
