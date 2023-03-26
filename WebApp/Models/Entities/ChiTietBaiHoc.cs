using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models.Entities
{
    [Table("ChiTietBaiHoc")]
    public class ChiTietBaiHoc
    {
        [Key]
        public int IdChiTietBaiHoc { get; set; }
        [StringLength(100000)]
        public string NoiDung1 { get; set; }
  

        public Nullable<long> IdBaiHoc { get; set; }
    }
}