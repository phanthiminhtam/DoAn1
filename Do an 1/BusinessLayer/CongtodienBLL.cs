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
    class CongtodienBLL : ICongtodienBLL
    {
        private ICongtodienDAL ct = new CongtodienDAL();
        private IHogiadinhDAL ho = new HogiadinhDAL();
        public List<Congtodien> GetALLCongtodien()
        {
            return ct.GetAllCongtodien();
        }
        public void Themcongto(Congtodien ct)
        {
            if (!string.IsNullOrEmpty(ct.Mact))
            {
                this.ct.Themcongto(ct);
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
            List<Congtodien> ct = GetALLCongtodien();
            if (ct.Find(m => m.Mact == Mact) != null)
                return true;
            return false;
        }
        public void Xoacongto(string Mact)
        {
            int i;
            List<Congtodien> list = GetALLCongtodien();
            for (i = 0; i < list.Count; i++)
                if (list[i].Mact == Mact) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                ct.Update(list);
            }
            else
                throw new Exception("------------>Khong ton tai ma cong to nay<-------------");
        }
        public void Suacongto(Congtodien ct)
        {
            int i;
            List<Congtodien> list = GetALLCongtodien();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Mact == ct.Mact) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(ct);
                this.ct.Update(list);
            }
            else
                throw new Exception("------------->Khong ton tai ma cong to nay<------------");
        }
       
        public List<Congtodien> Timcongto(Congtodien ct)
        {
            List<Congtodien> list = GetALLCongtodien();
            List<Congtodien> kq = new List<Congtodien>();
            //Tim theo mã
            if (ct.Mact != null &&  ct.Loaict == null )
            {
                foreach (Congtodien a in list)
                    if (a.Mact.IndexOf(ct.Mact) >= 0)
                    {
                        kq.Add(new Congtodien(a));
                    }
            }
            //Tim kiem theo loai
            else if (ct.Mact == null && ct.Loaict != null)
            {
                foreach (Congtodien b in list)
                {
                    if (b.Loaict.IndexOf(ct.Loaict) >= 0)
                    {
                        kq.Add(new Congtodien(b));
                    }
                }
            }
            else kq = null;
            return kq;
        }
    }
}
