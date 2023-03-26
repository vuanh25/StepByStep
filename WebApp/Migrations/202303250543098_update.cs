namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            
        /*    AlterColumn("dbo.ChiTietBaiHoc", "NoiDung1", c => c.String());
      *//*      DropColumn("dbo.ChiTietBaiHoc", "NoiDung2");
            DropColumn("dbo.ChiTietBaiHoc", "NoiDung3");
            DropColumn("dbo.ChiTietBaiHoc", "NoiDung4");
            DropColumn("dbo.ChiTietBaiHoc", "NoiDung5");
            DropColumn("dbo.ChiTietBaiHoc", "NoiDung6");
            DropColumn("dbo.ChiTietBaiHoc", "NoiDung7");
            DropColumn("dbo.ChiTietBaiHoc", "NoiDung8");
            DropColumn("dbo.ChiTietBaiHoc", "NoiDung9");
            DropColumn("dbo.ChiTietBaiHoc", "NoiDung10");*/
        }
        
        public override void Down()
        {
       /*     AddColumn("dbo.ChiTietBaiHoc", "NoiDung10", c => c.String(maxLength: 3000));
            AddColumn("dbo.ChiTietBaiHoc", "NoiDung9", c => c.String(maxLength: 3000));
            AddColumn("dbo.ChiTietBaiHoc", "NoiDung8", c => c.String(maxLength: 3000));
            AddColumn("dbo.ChiTietBaiHoc", "NoiDung7", c => c.String(maxLength: 3000));
            AddColumn("dbo.ChiTietBaiHoc", "NoiDung6", c => c.String(maxLength: 3000));
            AddColumn("dbo.ChiTietBaiHoc", "NoiDung5", c => c.String(maxLength: 3000));
            AddColumn("dbo.ChiTietBaiHoc", "NoiDung4", c => c.String(maxLength: 3000));
            AddColumn("dbo.ChiTietBaiHoc", "NoiDung3", c => c.String(maxLength: 3000));
            AddColumn("dbo.ChiTietBaiHoc", "NoiDung2", c => c.String(maxLength: 3000));
            AlterColumn("dbo.ChiTietBaiHoc", "NoiDung1", c => c.String(maxLength: 3000));*/
           
        }
    }
}
