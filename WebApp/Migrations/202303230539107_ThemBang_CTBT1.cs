namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemBang_CTBT1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
              "dbo.ChiTietBaiLuyens",
              c => new
              {
                  Id = c.Int(nullable: false, identity: true),
                  DeBai = c.String(nullable: false, maxLength: 1000),
                  YeuCauDauVao = c.String(nullable: false, maxLength: 100),
                  DauVao = c.String(nullable: false, maxLength: 100),
                  DauRa = c.String(nullable: false, maxLength: 100),
                  ViduVao = c.String(nullable: false, maxLength: 100),
                  ViduRa = c.String(nullable: false, maxLength: 100),
                  Diem = c.Int(nullable: false),
              })
              .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
        }
    }
}
