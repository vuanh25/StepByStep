using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models.Entities
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=StrConnect")
        {

        }


        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        public DbSet<BaiHoc> BaiHocs { get; set; }
        public DbSet<BaiTap> BaiTaps { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LuyenCode> LuyenTaps { get; set; }
        public DbSet<ChiTietBaiLuyen> ChiTietBaiLuyens { get; set; }
        public DbSet<BaiViet> BaiViets { get; set; }
        public DbSet<PhanHoi> PhanHois { get; set; }
        public DbSet<CauHoi> CauHois { get; set; }

    }
}