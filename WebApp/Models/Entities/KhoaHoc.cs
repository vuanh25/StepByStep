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
        [StringLength(100)]
        public string TenKhoaHoc { get; set; }

        [Required]
        public int CapDo { get; set; }

        public Nullable<long> IDNgonNgu { get; set; }
        public virtual NgonNgu NgonNgu { get; set; }
    }
}