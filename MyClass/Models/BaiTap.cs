using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Models
{
    [Table("BaiTap")]
    public class BaiTap
    {
        [Key]
        public int IDBaiTap { get; set; }

        [Required]
        [StringLength(2000)]  
        public string NoiDungBaiTap { get; set; }
        [Required]
        [StringLength(255)]
        public string TenBaiTap { get; set; }

        public Nullable<long> IDBaiHoc { get; set; }

        public virtual BaiHoc BaiHoc { get; set; }
    }
}
