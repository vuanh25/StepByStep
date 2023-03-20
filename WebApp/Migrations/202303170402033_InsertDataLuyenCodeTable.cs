namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertDataLuyenCodeTable : DbMigration
    {
        public override void Up()
        {
          /*  Sql("INSERT INTO LuyenCodes (TenLuyenTap,YeuThich,DoKho,NgonNgu) VALUES (N'Hello World',1000,0,0)");*/
        }
        
        public override void Down()
        {
        }
    }
}
