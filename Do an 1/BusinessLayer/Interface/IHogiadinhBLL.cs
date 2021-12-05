using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_an_1.Entities;

namespace Do_an_1.BusinessLayer.Interface
{
    public interface IHogiadinhBLL
    {
        List<Hogiadinh> GetAllHogiadinh();
        Hogiadinh GetHogiadinh(string Maho);
        void Themhogiadinh(Hogiadinh ho);
        void Xoahogiadinh(string Maho);
        void Suahogiadinh(Hogiadinh ho);
        bool ExitMH(string Maho);
        List<Hogiadinh> Timho(Hogiadinh ho);
    }
}
