using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Models
{
    public class BaiViet
    {
        public int IDBaiViet { get; set; }
        public string NoiDungBaiViet { get; set; }
        public string NgayDang { get; set; }
        public int LuotXem { get; set; }
        public virtual NgonNgu NgonNgu { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
    }
}
