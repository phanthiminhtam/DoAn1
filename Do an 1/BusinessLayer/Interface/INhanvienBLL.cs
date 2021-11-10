using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_an_1.Entities;

namespace Do_an_1.BusinessLayer.Interface
{
    public interface INhanvienBLL
    {
        List<Nhanvien> GetAllNhanvien();
        void Themnhanvien(Nhanvien nv);
        void Xoanhanvien(string Manv);
        void Suanhanvien(Nhanvien nv);
        bool ExitMNV(string Manv);
        List<Nhanvien> TimNhanvien(Nhanvien nv);
    }
}
