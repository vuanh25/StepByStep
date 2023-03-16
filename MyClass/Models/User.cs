using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int IDUser { get; set; }
        [Required]
        [StringLength(50)]  
        public string TenUser { get; set; }
        [Required,StringLength(100)] 
        public string Email { get; set; }
        [Required]
        [StringLength(50)]  
        public string TenTaiKHoan { get; set; }
        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }
    }
}
