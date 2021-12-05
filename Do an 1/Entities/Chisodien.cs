using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an_1.Entities
{
    public class Chisodien
    {
        private string maho;
        private string mact;
        private DateTime thoigian;
        private int thang, nam;
        private string loaict;
        private int chiso;
        private double tinhtien;
        public string Maho
        {
            get { return maho; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    maho = value;
            }
        }
        public string Mact
        {
            get { return mact; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    mact = value;
            }
        }
        public DateTime Thoigian
        {
            get { return thoigian; }
            set { thoigian = value; }
        }
        public int Thang
        {
            get { return thang; }
            set { thang = value; }
        }
        public int Nam
        {
            get { return nam; }
            set { nam = value; }
        }
        public string Loaict
        {
            get { return loaict; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    loaict = value;
            }
        }
        public int Chiso
        {
            get { return chiso; }
            set { chiso = value; }
        }
        public double Tinhtien
        {
            get { return tinhtien; }
            set { tinhtien = value; }
        }
        public Chisodien()
        {
        }
        public Chisodien(Chisodien cs)
        {
            this.maho = cs.maho;
            this.thoigian = cs.thoigian;
            this.mact = cs.mact;
            this.thang = cs.thang;
            this.nam = cs.nam;
            this.loaict = cs.loaict;
            this.chiso = cs.chiso;
            this.tinhtien = cs.tinhtien;
        }
        public Chisodien(string maho, string mact, DateTime thoigian, int thang,int nam,string loaict,int chiso,double tinhtien)
        {
            this.maho = maho;
            this.mact = mact;
            this.thoigian = thoigian;
            this.thang = thang;
            this.nam = nam;
            this.loaict = loaict;
            this.chiso = chiso;
            this.tinhtien = tinhtien;
        }
    }
}
