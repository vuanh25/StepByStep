using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Models
{
    [Table("BaiHoc")]
    public class BaiHoc
    {
        [Key]
        public int IDBaiHoc { get; set; }
        [Required]
        [StringLength(100)]  
        public string TenBaiHoc { get; set; }

        public Nullable<long> IdKhoaHoc { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }
    }
}
