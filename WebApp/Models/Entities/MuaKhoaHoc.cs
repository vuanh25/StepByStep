using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models.Entities
{
    [Table("MuaKhoaHoc")]
    public class MuaKhoaHoc
    {
        [Key]
        public int IdMua { get; set; }
        public int IdKhoaHoc { get; set; }
        public int IdUser { get; set; }
        public DateTime NgayThanhToan { get; set; }
        [Column(TypeName ="money")]
        public decimal? ThanhTien { get; set; }
        public virtual User User { get; set; }

    }
}