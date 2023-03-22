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

        
        [StringLength(3000)]
        public string NoiDung1 { get; set; }
        [StringLength(3000)]
        public string NoiDung2 { get; set; }
        [StringLength(3000)]
        public string NoiDung3 { get; set; }
        [StringLength(3000)]
        public string NoiDung4 { get; set; }
        [StringLength(3000)]
        public string NoiDung5 { get; set; }
        [StringLength(3000)]
        public string NoiDung6 { get; set; }
        [StringLength(3000)]
        public string NoiDung7 { get; set; }
        [StringLength(3000)]
        public string NoiDung8 { get; set; }
        [StringLength(3000)]
        public string NoiDung9 { get; set; }
        [StringLength(3000)]
        public string NoiDung10 { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }
     
    
    }
}