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
    class NhanvienBLL : INhanvienBLL
    {
        private INhanvienDAL nv = new NhanvienDAL();

        public List<Nhanvien> GetAllNhanvien()
        {
            return nv.GetAllNhanvien();
        }

        public void Themnhanvien(Nhanvien nv)
        {
            if (!string.IsNullOrEmpty(nv.Manv))
            {
                this.nv.Themnhanvien(nv);
            }
            else
                throw new Exception("------------->Nhap sai du lieu<------------");
        }
        public bool ExitMNV(string Manv)
        {
            List<Nhanvien> nv = GetAllNhanvien();
            if (nv.Find(m => m.Manv == Manv) != null)
                return true;
            return false;
        }
        public void Xoanhanvien(string Manv)
        {
            int i;
            List<Nhanvien> list = GetAllNhanvien();
            for (i = 0; i < list.Count; i++)
                if (list[i].Manv == Manv) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                nv.Update(list);
            }
            else
                throw new Exception("------------>Khong ton tai ma nhan vien nay<-------------");
        }
        public void Suanhanvien(Nhanvien nv)
        {
            int i;
            List<Nhanvien> list = GetAllNhanvien();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Manv == nv.Manv) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(nv);
                this.nv.Update(list);
            }
            else
                throw new Exception("------------->Khong ton tai ma nhan vien nay<------------");
        }

        public List<Nhanvien> TimNhanvien(Nhanvien nv)
        {
            List<Nhanvien> list = GetAllNhanvien();
            List<Nhanvien> kq = new List<Nhanvien>();
            //Tim theo mã
            if (nv.Manv != null && nv.Tennv == null && nv.Gioitinh == null)
            {
                foreach (Nhanvien a in list)
                    if (a.Manv.IndexOf(nv.Manv) >= 0)
                    {
                        kq.Add(new Nhanvien(a));
                    }
            }
            //Tim kiem theo ten 
            else if (nv.Manv == null && nv.Tennv != null && nv.Gioitinh == null)
            {
                foreach (Nhanvien a in list)
                {
                    if (a.Tennv.ToUpper().IndexOf(nv.Tennv.ToUpper()) >= 0)
                    {
                        kq.Add(new Nhanvien(a));
                    }
                }
            }
            //Tim kiem theo giới tính
            else if (nv.Manv == null && nv.Tennv == null && nv.Gioitinh != null)
            {
                foreach (Nhanvien a in list)
                {
                    if (a.Gioitinh.ToUpper().IndexOf(nv.Gioitinh.ToUpper())>=0)
                    {
                        kq.Add(new Nhanvien(a));
                    }
                }
            }
            else kq = null;
            return kq;
        }
    }
}
