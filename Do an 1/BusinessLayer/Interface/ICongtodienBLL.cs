using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_an_1.Entities;

namespace Do_an_1.BusinessLayer.Interface
{
    public interface ICongtodienBLL
    {
        List<Congtodien> GetALLCongtodien();
        void Themcongto(Congtodien ct);
        void Xoacongto(string Mact);
        void Suacongto(Congtodien ct);
        bool ExitMH(string Maho);
        bool ExitMCT(string Mact);
        List<Congtodien> Timcongto(Congtodien ct);
    }
}
