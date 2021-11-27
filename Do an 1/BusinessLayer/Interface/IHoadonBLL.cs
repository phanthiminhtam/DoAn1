using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_an_1.Entities;

namespace Do_an_1.BusinessLayer.Interface
{
    public interface IHoadonBLL
    {
        List<Hoadon> GetAllHoadon();
        void Themhoadon(Hoadon hd);
        void Xoahoadon(string Mahd);
        void Suahoadon(Hoadon hd);
        bool ExitMH(string Maho);
        bool ExitMCT(string Mact);
        bool ExitMHD(string Mahd);
        int Sodientruoc(Hoadon t);
        double Tiendien(Hoadon t);
        DateTime Getit(Hoadon t);
        List<Hoadon> TimHoadon(Hoadon hd);
    }
}
