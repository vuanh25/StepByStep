using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApp.Models.Enums;

namespace WebApp.Models.Entities
{
    [Table("BaiViets")]
    public class BaiViet
    {
        [Key]
        public int IdBaiViet { get; set; }

        [Required]
        public string NoiDungBaiViet { get; set; }

        [Required]
        public string NgayDang { get; set; }

        [Required]
        public int LuotXem { get; set; }

        public virtual NgonNgu NgonNgu { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
        public virtual User User { get; set; }
    }
}