using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an_1.Entities
{
    public class Hoadon
    {
        private string maho;
        private DateTime ngaythang;
        private string mahd, tench;
        private string sothe;
        private double tt;
        private string tinhtrang;

        public string Maho
        {
            get { return maho; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    maho = value;
            }
        }
        public string Tench
        {
            get { return tench; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    tench = value;
            }
        }
        public string Mahd
        {
            get { return mahd; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    mahd = value;
            }
        }
        public DateTime Ngaythang
        {
            get { return ngaythang; }
            set { ngaythang = value; }
        }
        public string Sothe
        {
            get { return sothe; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    sothe = value;
            }
        }
        public double Tt
        {
            get { return tt; }
            set { tt = value; }
        }
        public string Tinhtrang
        {
            get { return tinhtrang; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    tinhtrang = value;
            }
        }
        public Hoadon()
        {
        }
        public Hoadon(Hoadon hd)
        {
            this.maho = hd.maho;
            this.mahd = hd.mahd;
            this.tench = hd.tench;
            this.ngaythang = hd.ngaythang;
            this.sothe = hd.sothe;
            this.tt = hd.tt;
            this.tinhtrang = hd.tinhtrang;

        }
        public Hoadon(string maho, DateTime ngaythang,string mahd,string tench,string sothe,double tt,string tinhtrang)
        {
            this.maho = maho;
            this.ngaythang = ngaythang;
            this.mahd = mahd;
            this.tench = tench;
            this.sothe = sothe;
            this.tt = tt;
            this.tinhtrang = tinhtrang;
       
        }
    }
}
