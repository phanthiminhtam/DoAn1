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
   public class HogiadinhBLL: IHogiadinhBLL
    {
        private IHogiadinhDAL ho = new HogiadinhDAL();

        public List<Hogiadinh> GetAllHogiadinh()
        {
            return ho.GetAllHogiadinh();
        }
        public Hogiadinh GetHogiadinh(string Maho)
        {
            List<Hogiadinh> hogiadinhs = ho.GetAllHogiadinh();
            foreach(var a in hogiadinhs)
            {
                if (a.Maho == Maho)
                    return a;
            }
            throw new Exception("Hộ gia đình không tồn tại!");
        }
        public void Themhogiadinh(Hogiadinh ho)
        {
            if (!string.IsNullOrEmpty(ho.Tench))
            {
                this.ho.Themhogiadinh(ho);
            }
            else
                throw new Exception("------------->Nhap sai du lieu<------------");
        }
        public bool ExitMH(string Maho)
        {
            List<Hogiadinh> ho = GetAllHogiadinh();
            if (ho.Find(m => m.Maho == Maho) != null)
                return true; 
            return false;
        }
        public void Xoahogiadinh(string Maho)
        {
            int i;
            List<Hogiadinh> list = GetAllHogiadinh();
            for (i = 0; i < list.Count; i++)
                if (list[i].Maho == Maho) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                ho.Update(list);
            }
            else
                throw new Exception("------------>Khong ton tai ma ho nay<-------------");
        }

        public void Suahogiadinh(Hogiadinh ho)
        {
            int i;
            List<Hogiadinh> list = GetAllHogiadinh();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Maho == ho.Maho) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(ho);
                this.ho.Update(list);
            }
            else
                throw new Exception("------------->Khong ton tai ma ho nay<------------");
        }

        public List<Hogiadinh> Timho(Hogiadinh ho)
        {
            List<Hogiadinh> list = GetAllHogiadinh();
            List<Hogiadinh> kq = new List<Hogiadinh>();
            //Tim theo mã
            if (ho.Maho != null && ho.Tench == null && ho.Diachi == null)
            {
                foreach (Hogiadinh a in list)
                    if (a.Maho.IndexOf(ho.Maho) >= 0)
                    {
                        kq.Add(new Hogiadinh(a));
                    }
            }
            //Tim kiem theo ten 
            else if (ho.Tench != null && ho.Diachi == null && ho.Maho==null)
            {
                foreach (Hogiadinh hgd in list)
                {
                    if (hgd.Tench.ToUpper().IndexOf(ho.Tench.ToUpper()) >= 0)
                    {
                        kq.Add(new Hogiadinh(hgd));
                    }
                }
            }
            //Tim kiem theo dia chi
            else if (ho.Tench == null && ho.Diachi != null && ho.Maho == null)
            {
                foreach (Hogiadinh hgd in list)
                {
                    if (hgd.Diachi.ToUpper().Contains(ho.Diachi.ToUpper()))
                    {
                        kq.Add(new Hogiadinh(hgd));
                    }
                }
            }
            else kq = null;
           return kq;
        }
    }
}
