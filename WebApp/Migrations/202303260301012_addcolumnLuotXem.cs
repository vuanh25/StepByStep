namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumnLuotXem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LuyenCodes", "LuotXem", c => c.Int());
        }
        
        public override void Down()
        {
        }
    }
}
