namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Data_LuyenTap : DbMigration
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

            //Sql("INSERT INTO ChiTietBaiLuyens (Id,DeBai,YeuCauDauVao,DauVao,DauRa,ViduVao,ViduRa,Diem) VALUES (4,N'Công việc bạn cần phải làm là in ra câu nói dưới đây: Hello World',N'Không có',N'Không có',N'Hello World',N'Không có',N'Hello World',100)");
            //Sql("INSERT INTO ChiTietBaiLuyens (Id,DeBai,YeuCauDauVao,DauVao,DauRa,ViduVao,ViduRa,Diem) VALUES (5,N'Viết chương trình cho phép nhập số nguyên a và b từ bàn phím. Tính và in kết quả:a + b',N'2 số nguyên a và b cách nhau 1 dấu cách ',N' |a|,|b| < 100',N'Tổng của a và b',N'1 2',N'3',100)");
            //Sql("INSERT INTO ChiTietBaiLuyens (Id,DeBai,YeuCauDauVao,DauVao,DauRa,ViduVao,ViduRa,Diem) VALUES (6,N'Viết chương trình cho phép nhập số nguyên a, b, c từ bàn phím. Tính và in kết quả:a + b + c',N'3 số nguyên a, b, c cách nhau 1 dấu cách ',N' |a|,|b|,|c| < 100',N'Tổng của a, b, c',N'1 2 3',N'6',100)");
            //Sql("INSERT INTO ChiTietBaiLuyens (Id,DeBai,YeuCauDauVao,DauVao,DauRa,ViduVao,ViduRa,Diem) VALUES (7,N'Viết chương trình cho phép nhập số nguyên a và b từ bàn phím. Tìm và in ra phần dư của phép toán a/b ',N' |a|,|b| < 100',N'2 số nguyên a và b cách nhau 1 dấu cách ',N'Giá trị dư của phép toán',N'2 2',N'0',100)");
            //Sql("INSERT INTO ChiTietBaiLuyens (Id,DeBai,YeuCauDauVao,DauVao,DauRa,ViduVao,ViduRa,Diem) VALUES (8,N'VIết chương trình tìm số lớn nhất trong 2 số nguyên nhập từ bàn phím',N' |a|,|b| < 100',N'2 số nguyên a và b cách nhau 1 dấu cách ',N'Số lớn nhất trong 2 số',N'1 10',N'10',100)");
            //Sql("INSERT INTO ChiTietBaiLuyens (Id,DeBai,YeuCauDauVao,DauVao,DauRa,ViduVao,ViduRa,Diem) VALUES (9,N'Viết chương trình tính và in ra chu vi, diện tích của hình chữ nhật cho biết trước chiều dài (d) và chiều rộng (r).',N' r,d thuộc N*; a,b < 100',N'2 số nguyên a và b cách nhau 1 dấu cách ',N'Lần lượt là chu vi và diện tích của hình chữ nhật, mỗi kết quả trên 1 dòng',N'20 10',N'60 200',100)");
            //Sql("INSERT INTO ChiTietBaiLuyens (Id,DeBai,YeuCauDauVao,DauVao,DauRa,ViduVao,ViduRa,Diem) VALUES (10,N'Viết chương trình tính chu vi, diện tích của hình tròn. Bán kính r là một số thực được nhập từ bàn phím',N'0 < r < 100',N' Một số thực r là bán kính',N'Chu vi, diện tích hình tròn cách nhau bởi 1 dấu cách, làm tròn tới chữ số thập phân thứ 3',N'0.5',N'3.140 0.785',100)");
            //Sql("INSERT INTO ChiTietBaiLuyens (Id,DeBai,YeuCauDauVao,DauVao,DauRa,ViduVao,ViduRa,Diem) VALUES (11,N'Nhập vào 3 số nguyên dương, tìm và in ra số nhất trong 3 số đó',N'3 số nguyên a, c, b cách nhau 1 dấu cách ',N'3 số nguyên dương có giá trị không quá 100',N'Tổng của a và b',N'1 2 3',N'3',100)");



        }

        public override void Down()
        {
        }
    }
}
