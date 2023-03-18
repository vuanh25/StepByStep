namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertData_ChiTietBaiLuyenTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ChiTietBaiLuyens (Id,DeBai,YeuCauDauVao,DauVao,DauRa,ViduVao,ViduRa,Diem) VALUES (1,N'Công việc bạn cần phải làm là in ra câu nói dưới đây: Hello World',N'Không có',N'Không có',N'Hello World',N'Không có',N'Hello World',100)");

        }

        public override void Down()
        {
        }
    }
}
