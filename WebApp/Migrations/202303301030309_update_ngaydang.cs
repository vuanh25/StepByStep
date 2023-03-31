namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_ngaydang : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BaiViets", "NgayDang", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BaiViets", "NgayDang", c => c.String());
        }
    }
}
