using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApp.Models.Enums;

namespace WebApp.Models.Entities
{
    [Table("LuyenCodes")]
    public class LuyenCode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string TenLuyenTap { get; set; }

        [Required]
        public int YeuThich { get; set; }

    //    public ChiTietBaiLuyen NoiDung { get; set; }
        public virtual NgonNgu NgonNgu { get; set; }
        public virtual DoKho DoKho { get; set; }






    }
}