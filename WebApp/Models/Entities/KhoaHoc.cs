using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApp.Models;
using WebApp.Models.Enums;

namespace WebApp.Models.Entities
{
    [Table("KhoaHocs")]
    public class KhoaHoc
    {
        [Key]
        public int IDKhoaHoc { get; set; }

        [Required]
        [StringLength(500)]
        public string TenKhoaHoc { get; set; }

        public Nullable<long> IDNgonNgu { get; set; }
        [Column(TypeName = "money")]
        public decimal? GiaGoiKhoaHoc { get; set; }

        public virtual NgonNgu NgonNgu { get; set; }


    }
}