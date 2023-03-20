namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertDataLuyenCodeTable_Final : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO LuyenCodes (TenLuyenTap,YeuThich,DoKho,NgonNgu) VALUES (N'Hello World',1000,0,0)");
            Sql("INSERT INTO LuyenCodes (TenLuyenTap,YeuThich,DoKho,NgonNgu) VALUES (N'Tính tổng 2 số nguyên',500,0,0)");
            Sql("INSERT INTO LuyenCodes (TenLuyenTap,YeuThich,DoKho,NgonNgu) VALUES (N'Tính tổng của 3 số nguyên',40,0,0)");
            Sql("INSERT INTO LuyenCodes (TenLuyenTap,YeuThich,DoKho,NgonNgu) VALUES (N'Tìm số dư',234,0,0)");
            Sql("INSERT INTO LuyenCodes (TenLuyenTap,YeuThich,DoKho,NgonNgu) VALUES (N'Tìm số lớn nhất',264,0,0)");
            Sql("INSERT INTO LuyenCodes (TenLuyenTap,YeuThich,DoKho,NgonNgu) VALUES (N'Tính chu vi, diện tích hình chữ nhật',586,0,0)");
            Sql("INSERT INTO LuyenCodes (TenLuyenTap,YeuThich,DoKho,NgonNgu) VALUES (N'Tính chu vi, diện tích hình tròn',280,0,0)");
            Sql("INSERT INTO LuyenCodes (TenLuyenTap,YeuThich,DoKho,NgonNgu) VALUES (N'Tìm số lớn nhất trong 3 số',119,0,0)");

        }

        public override void Down()
        {
        }
    }
}
