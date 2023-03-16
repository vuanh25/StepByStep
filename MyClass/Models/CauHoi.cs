using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Models
{
    public class CauHoi
    {
        public int IDCauHoi { get; set; }
        public string NoiDungCauHoi { get; set; }
        public string NgayDang { get; set; }
        public int LuotXem { get; set; }
        public virtual NgonNgu NgonNgu { get;set; }
        public virtual DanhMuc DanhMuc { get; set; }
        public virtual User User { get; set; }
    }
}
