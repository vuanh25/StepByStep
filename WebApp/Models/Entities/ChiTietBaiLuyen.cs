using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models.Entities
{
    [Table("ChiTietBaiLuyens")]
    public class ChiTietBaiLuyen
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string DeBai { get; set; }

        [Required]
        [StringLength(100)]
        public string YeuCauDauVao { get; set; }

        [Required]
        [StringLength(100)]
        public string DauVao { get; set; }

        [Required]
        [StringLength(100)]
        public string DauRa { get; set; }

        [Required]
        [StringLength(100)]
        public string ViduVao { get; set; }

        [Required]
        [StringLength(100)]
        public string ViduRa { get; set; }

        [Required]
        public int Diem { get; set; }

        public LuyenCode LuyenCode { get; set; }

    }
}