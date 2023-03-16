using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Models
{
    public class PhanHoi
    {
        public int IDPhanHoi { get; set; }
        public string NoiDung { get; set; }
        public int LuotThich { get; set; }  
        //public virtual PhanHoi BinhLuan { get; set; }
        public virtual CauHoi CauHoi { get; set; }

        public virtual BaiViet BaiViet { get; set; }

    }
}
