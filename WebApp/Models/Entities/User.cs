using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models.Entities
{
    [Table("Users")]
    public class User
    {
        
        [Key]
        public int IdUser { get; set; }

        [Required]
        [StringLength(50)]
        public string TenUser { get; set; }

        [Required, StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTaiKHoan { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuaKhoaHoc> MuaKhoaHocs { get; set; }

        // Quan hệ nối ở dưới

    }
}