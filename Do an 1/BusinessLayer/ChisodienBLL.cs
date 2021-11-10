using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_an_1.Entities;
using Do_an_1.DataAccessLayer;
using Do_an_1.DataAccessLayer.Interface;
using Do_an_1.BusinessLayer.Interface;

namespace Do_an_1.BusinessLayer
{
    class ChisodienBLL : IChisodienBLL
    {
        private IChisodienDAL cs = new ChisodienDAL();
        private IHogiadinhDAL ho = new HogiadinhDAL();
        private ICongtodienDAL ct = new CongtodienDAL();
        public List<Chisodien> GetAllChisodien()
        {
            return cs.GetAllChisodien();
        }
        public void Themchiso(Chisodien cs)
        {
            if (!string.IsNullOrEmpty(cs.Mact))
            {
                this.cs.Themchiso(cs);
            }
            else
                throw new Exception("------------->Nhap sai du lieu<------------");
        }
        public bool ExitMH(string Maho)
        {
            List<Hogiadinh> ds = ho.GetAllHogiadinh();
            if (ds.Find(m => m.Maho == Maho) != null)
                return true;
            return false;
        }
        public bool ExitMCT(string Mact)
        {
            List<Congtodien> ds = ct.GetAllCongtodien();
            if (ds.Find(m => m.Mact == Mact) != null)
                return true;
            return false;
        }
        public void Xoachiso(string Mact)
        {
            int i;
            List<Chisodien> list = GetAllChisodien();
            for (i = 0; i < list.Count; i++)
                if (list[i].Mact == Mact) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                cs.Update(list);
            }
            else
                throw new Exception("------------>Khong ton tai ma cong to nay<-------------");
        }
        public void Suachiso(Chisodien cs)
        {
            int i;
            List<Chisodien> list = GetAllChisodien();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Mact == cs.Mact) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(cs);
                this.cs.Update(list);
            }
            else
                throw new Exception("------------->Khong ton tai ma cong to nay<------------");
        }

    }
}
