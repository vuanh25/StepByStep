namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alo1111 : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.KhoaHocs", "IDNgonNgu");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.KhoaHocs", "IDNgonNgu", c => c.Long());
        }
    }
}
