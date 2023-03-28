using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models.Entities
{
    [Table("BaiHocs")]
    public class BaiHoc
    {
        [Key]
        public int IdBaiHoc { get; set; }

        [Required]
        [StringLength(200)]
        public string TenBaiHoc { get; set; }




        public Nullable<long> IdKhoaHoc { get; set; }


    }
}