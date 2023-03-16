using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Models
{
    [Table("NgonNgu")]
    public class NgonNgu
    {
        [Key]
        public int IDNgonNgu { get; set; }
        [Required]
        public string TenNgonNgu { get; set; }
        public Nullable<long> IDDanhMuc { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

    }
}
