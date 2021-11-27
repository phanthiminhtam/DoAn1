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
    class HoadonBLL : IHoadonBLL
    {
        private IHoadonDAL hd = new HoadonDAL();
        private IHogiadinhDAL ho = new HogiadinhDAL();
        private ICongtodienDAL ct = new CongtodienDAL();
        public List<Hoadon> GetAllHoadon()
        {
            return hd.GetAllHoadon();
        }
        public void Themhoadon(Hoadon hd)
        {
            if (!string.IsNullOrEmpty(hd.Mahd))
            {
                this.hd.Themhoadon(hd);
            }
            else
                throw new Exception("------------->Nhap sai du lieu<------------");
        }
        public bool ExitMH(string Maho)
        {
            List<Hogiadinh> ds = ho.GetAllHogiadinh() ;
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
        public bool ExitMHD(string Mahd)
        {
            List<Hoadon> hd = GetAllHoadon();
            if (hd.Find(m => m.Mahd == Mahd) != null)
                return true;
            return false;
        }
        public DateTime Getit(Hoadon t)
        {
            string x = t.Thang.ToString() + '/' + t.Ngay.ToString() +  '/' + t.Nam.ToString();
            DateTime h = Convert.ToDateTime(x);
            return h;
        }

        public int VT(Hoadon t)
        {
            int d = 0;
            for(int i=0;i< GetAllHoadon().Count;i++ )
            {
                if (Getit(t)> Getit(GetAllHoadon()[i]) && t.Maho==GetAllHoadon()[i].Maho && t.Loaict== GetAllHoadon()[i].Loaict)
                    d++;
            }
            return d;
        }
        public int Sodientruoc(Hoadon t)
        {
            int d;
            d = VT(t);
            if (d == 0)
                return 0;
            else
            {
                for (int i = d-1  ; i >= 0; i--)
                {
                    if (t.Maho ==GetAllHoadon()[i].Maho)
                    {
                        return GetAllHoadon()[i].Chiso;
                    }
                }
            }         
            return 0;
        }
        //sd<=50 : 1.678 ; sd<=100 : 1.734 ; sd <=200 : 2.014 ; sd <=300: 2.536 ; sd <=400 : 2.834 ; sd>400 : 2.947
        public double Tiendien(Hoadon t)
        {
            int tg;
            tg = t.Chiso - Sodientruoc(t);
            if (t.Loaict == "CTGD")
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
        public void Xoahoadon(string Mahd)
        {
            int i;
            List<Hoadon> list = GetAllHoadon();
            for (i = 0; i < list.Count; i++)
                if (list[i].Mahd == Mahd) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                hd.Update(list);
            }
            else
                throw new Exception("------------>Khong ton tai ma hoa don nay<-------------");
        }
        public void Suahoadon(Hoadon hd)
        {
            int i;
            List<Hoadon> list = GetAllHoadon();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Mahd == hd.Mahd) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(hd);
                this.hd.Update(list);
            }
            else
                throw new Exception("------------->Khong ton tai ma hoa don nay<------------");
        }

        public List<Hoadon> TimHoadon(Hoadon hd)
        {
            List<Hoadon> list =GetAllHoadon();
            List<Hoadon> kq = new List<Hoadon>();
            if (hd.Maho != null && hd.Tench == null && hd.Mahd == null)
            {
                foreach (Hoadon a in list)
                    if (a.Maho.IndexOf(hd.Maho) >= 0)
                    {
                        kq.Add(new Hoadon(a));
                    }
            }
            //Tim kiem theo ten 
            else if (hd.Tench != null && hd.Mahd == null && hd.Maho == null)
            {
                foreach (Hoadon a in list)
                {
                    if (a.Tench.ToUpper().IndexOf(hd.Tench.ToUpper()) >= 0)
                    {
                        kq.Add(new Hoadon(a));
                    }
                }
            }
            else if (hd.Tench == null && hd.Mahd != null && hd.Maho == null)
            {
                foreach (Hoadon a in list)
                {
                    if (a.Mahd.ToUpper().IndexOf(hd.Mahd.ToUpper()) >= 0)
                    {
                        kq.Add(new Hoadon(a));
                        break;
                    }
                }
            }
            else kq = null;
            return kq;
        }
    }
}
