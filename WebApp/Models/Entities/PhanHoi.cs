using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models.Entities
{
    [Table("PhanHois")]
    public class PhanHoi
    {
        [Key]
        public int IDPhanHoi { get; set; }

        [Required]
        [StringLength(500)]
        public string NoiDung { get; set; }

        [Required]
    
        public string NgayDang { get; set; }
        [Required]
        public int LuotThich { get; set; }


        //public virtual PhanHoi BinhLuan { get; set; }
        public virtual CauHoi CauHoi { get; set; }
        public virtual BaiViet BaiViet { get; set; }
        public virtual User User { get; set; }
    }
}