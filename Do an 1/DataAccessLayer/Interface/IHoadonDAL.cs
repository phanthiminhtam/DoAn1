using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_an_1.Entities;

namespace Do_an_1.DataAccessLayer.Interface
{
    interface IHoadonDAL
    {
        List<Hoadon> GetAllHoadon();
        void Themhoadon(Hoadon hd);
        void Update(List<Hoadon> list);
    }
}
