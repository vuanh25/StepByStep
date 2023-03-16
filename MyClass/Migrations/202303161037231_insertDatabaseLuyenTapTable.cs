namespace MyClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertDatabaseLuyenTapTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LuyenTaps", "MucDo", c => c.Int(nullable: false));
           
        }
        
        public override void Down()
        {
            DropColumn("dbo.LuyenTaps", "MucDo");
        }
    }
}
