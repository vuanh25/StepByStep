using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApp.Models.Enums;

namespace WebApp.Models.Entities
{
    [Table("CauHois")]
    public class CauHoi
    {
        [Key]
        public int IdCauHoi { get; set; }
        public string TieuDe { get; set; }      

        [StringLength(1500)]
        public string NoiDungCauHoi { get; set; }

        public string  HinhAnh { get; set; } 

        public DateTime NgayDang { get; set; }

        public int LuotXem { get; set; }

        public virtual NgonNgu NgonNgu { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
        public virtual User User { get; set; }
    }
}