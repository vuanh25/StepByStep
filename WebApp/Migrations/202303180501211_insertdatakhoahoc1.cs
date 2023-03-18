namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertdatakhoahoc1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO KhoaHocs (TenKhoaHoc,IDNgonNgu) VALUES (N'Java cơ bản',2)");
            Sql("INSERT INTO KhoaHocs (TenKhoaHoc,IDNgonNgu) VALUES (N'C# cơ bản',1)");
            Sql("INSERT INTO KhoaHocs (TenKhoaHoc,IDNgonNgu) VALUES (N'C/C++ cơ bản',0)");
        }
        
        public override void Down()
        {
        }
    }
}
