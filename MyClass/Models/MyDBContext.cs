using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Models
{
    public class MyDBContext: DbContext
    {
        public MyDBContext(): base("name=StrConnect") 
        { 
        }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<NgonNgu> NgonNgus { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        public DbSet<BaiHoc> BaiHocs { get; set; }
        public DbSet<BaiTap> BaiTaps { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LuyenTap> LuyenTaps { get; set; }
    }
}
