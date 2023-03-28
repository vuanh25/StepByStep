using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApp.Models.Entities;

namespace WebApp.Models
{

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext() : base("name=StrConnect")
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // Cấu hình DbSet
        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        public DbSet<BaiHoc> BaiHocs { get; set; }
        public DbSet<ChiTietBaiHoc> ChiTietBaiHocs { get; set; }
        public DbSet<BaiTap> BaiTaps { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LuyenCode> LuyenTaps { get; set; }
        public DbSet<ChiTietBaiLuyen> ChiTietBaiLuyens { get; set; }
        public DbSet<BaiViet> BaiViets { get; set; }
        public DbSet<PhanHoi> PhanHois { get; set; }
        public DbSet<CauHoi> CauHois { get; set; }
  
    }
}