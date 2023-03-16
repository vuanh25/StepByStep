using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Models
{
    [Table("DanhMuc")]
    public class DanhMuc
    {
        [Key]
        public int IDDanhMuc { get; set; }

        [Required]
        [StringLength(255)]  
        public string TenDanhMuc { get; set; }

    }
}
