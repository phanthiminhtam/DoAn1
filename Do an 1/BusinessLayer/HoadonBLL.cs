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
        private IChisodienDAL cs = new ChisodienDAL();
       
        public List<Hoadon> GetAllHoadon()
        {
            return hd.GetAllHoadon();
        }
        public Hoadon GetHoaDon(string Maho,DateTime Ngaythang)
        {
            List<Hoadon> hoadons = hd.GetAllHoadon();
            foreach (var a in hoadons)
            {
                if (a.Maho == Maho && a.Ngaythang.Month == Ngaythang.Month && a.Ngaythang.Year == Ngaythang.Year)
                    return a;
            }
            throw new Exception("Hóa đơn không tồn tại!");
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
        public bool ExitMHD(string Mahd)
        {
            List<Hoadon> hd = GetAllHoadon();
            if (hd.Find(m => m.Mahd == Mahd) != null)
                return true;
            return false;
        }
        public double Tongtien(string Maho, DateTime Ngaythang)
        {
            List<Chisodien> ds = cs.GetAllChisodien();
            double tt = 0;
            bool check = false;
            for(int i=ds.Count-1;i>=0;i--)
            {
                if (ds[i].Maho == Maho && ds[i].Thoigian.Month == Ngaythang.Month && ds[i].Thoigian.Year == Ngaythang.Year)
                {
                    check = true;
                    tt += ds[i].Tinhtien;
                }
                else if (check == true)
                    break;
            }
            return tt;
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
        public void Suatinhtrang(Hoadon hd , int thang, int nam)
        {
            int i;
            List<Hoadon> list = GetAllHoadon();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Maho == hd.Maho && list[i].Ngaythang.Month == thang && list[i].Ngaythang.Year == nam) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                hd.Tinhtrang = "Da Nop";
                list.Add(hd);
                this.hd.Update(list);
            }
            else
                throw new Exception("------------->Khong ton tai ma cong to nay<------------");
        }
        public List<Hoadon> TimHoadon(Hoadon hd)
        {
            List<Hoadon> list = GetAllHoadon();
            List<Hoadon> kq = new List<Hoadon>();
            if (hd.Maho != null )
            {
                foreach (Hoadon a in list)
                    if (a.Maho.IndexOf(hd.Maho) >= 0)
                    {
                        kq.Add(new Hoadon(a));
                    }
            }
            else kq = null;
            return kq;
        }
    }
}
