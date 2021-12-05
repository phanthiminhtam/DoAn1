using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_an_1.Entities;

namespace Do_an_1.BusinessLayer.Interface
{
    public interface IChisodienBLL
    {
        List<Chisodien> GetAllChisodien();
        Chisodien GetChisodien(string Mact);
        void Themchiso(Chisodien cs);
        void Xoachiso(string Mact);
        bool ExitMH(string Maho);
        bool ExitMCT(string Mact);
        int Sodientruoc(Chisodien t);
        double Tiendien(Chisodien t);
        DateTime Getit(Chisodien t);
        void Suachiso(Chisodien cs);
    }
}
