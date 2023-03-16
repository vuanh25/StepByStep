using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Models
{
    class LuyenTap
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(2000)]
        public string NoiDungLuyenTap { get; set; }

        [Required]
        [StringLength(255)]
        public string TenLuyenTap { get; set; }

        public virtual NgonNgu NgonNgu { get; set; }


    }
}
