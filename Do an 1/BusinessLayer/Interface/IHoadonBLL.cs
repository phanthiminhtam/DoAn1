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
        bool ExitMH(string Maho);
        bool ExitMHD(string Mahd);
        void Suatinhtrang(Hoadon hd,int thang,int nam);
        Hoadon GetHoaDon(string Maho, DateTime Ngaythang);
        double Tongtien(string Maho, DateTime Ngaythang);
        List<Hoadon> TimHoadon(Hoadon hd);
    }
}
