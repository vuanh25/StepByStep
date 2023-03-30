namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_ngaydang1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CauHois", "NgayDang", c => c.DateTime());
            AlterColumn("dbo.PhanHois", "NgayDang", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhanHois", "NgayDang", c => c.String());
            AlterColumn("dbo.CauHois", "NgayDang", c => c.String());
        }
    }
}
