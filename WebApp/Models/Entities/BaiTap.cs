using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApp.Models.Enums;

namespace WebApp.Models.Entities
{
    [Table("BaiTaps")]
    public class BaiTap
    {
        [Key]
        public int IDBaiTap { get; set; }

        [Required]
        [StringLength(100)]
        public string TenBaiTap { get; set; }

        [Required]
        [StringLength(500)]
        public string NoiDungBaiTap { get; set; }

        [Required]
        public int Diem { get; set; }

        public virtual TrangThaiHoanThanh TrangThaiHoanThanh { get; set; }
        public Nullable<long> IdBaiHoc { get; set; }
        public virtual BaiHoc BaiHoc { get; set; }
    }
}