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
        private ICongtodienBLL Ct = new CongtodienBLL();
        public List<Chisodien> GetAllChisodien()
        {
            return cs.GetAllChisodien();
        }
        public Chisodien GetChisodien(string Mact)
        {
            List<Chisodien> chisodiens = cs.GetAllChisodien();
            foreach (var a in chisodiens)
            {
                if (a.Mact == Mact)
                    return a;
            }
            throw new Exception("Hộ gia đình không tồn tại!");
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
        public DateTime Getit(Chisodien t)
        {

            string x = t.Thang.ToString() + '/' + " 1" + '/' + t.Nam.ToString();
            DateTime h = Convert.ToDateTime(x);
            return h;
        }
        public int VT(Chisodien t)
        {
            int d = 0;
            for (int i = 0; i < GetAllChisodien().Count; i++)
            {
                if (Getit(t) > Getit(cs.GetAllChisodien()[i]) && t.Mact == cs.GetAllChisodien()[i].Mact)
                    d++;
            }
            return d;
        }
        public int Sodientruoc(Chisodien t)
        {
            int d;
            d = VT(t);
            if (d == 0)
                return 0;
            else
            {
                for (int i = d - 1; i >= 0; i--)
                {
                    if (t.Mact == cs.GetAllChisodien()[i].Mact)
                    {
                        return cs.GetAllChisodien()[i].Chiso;
                    }
                }
            }
            return 0;
        }
        //sd<=50 : 1.678 ; sd<=100 : 1.734 ; sd <=200 : 2.014 ; sd <=300: 2.536 ; sd <=400 : 2.834 ; sd>400 : 2.947
        public double Tiendien(Chisodien t)
        {
            int tg;
            tg = t.Chiso - Sodientruoc(t);
            if (Ct.GetCongtodien(t.Mact).Loaict == "CTGD")
            {
                if (tg <= 50)
                {
                    return (tg * 1.678);
                }
                else if (tg <= 100)
                {
                    return 50 * 1.678 + (tg - 50) * 1.734;
                }
                else if (tg <= 200)
                {
                    return 50 * 1.678 + (100 - 50) * 1.734 + (tg - 100) * 2.014;
                }
                else if (tg <= 300)
                {
                    return 50 * 1.678 + (100 - 50) * 1.734 + (200 - 100) * 2.014 + (tg - 200) * 2.536;
                }
                else if (tg <= 400)
                {
                    return 50 * 1.678 + (100 - 50) * 1.734 + (200 - 100) * 2.014 + (300 - 200) * 2.536 + (tg - 300) * 2.834;
                }
                else
                {
                    return 50 * 1.678 + (100 - 50) * 1.734 + (200 - 100) * 2.014 + (300 - 200) * 2.536 + (400 - 300) * 2.834 + (tg - 400) * 2.947;
                }
            }
            return tg * 2.666 * 1.1;
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
