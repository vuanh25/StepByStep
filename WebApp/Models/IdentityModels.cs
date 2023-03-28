using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApp.Models.Entities;

namespace WebApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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