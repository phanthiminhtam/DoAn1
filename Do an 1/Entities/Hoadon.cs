using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an_1.Entities
{
    public class Hoadon
    {
        private DateTime ngaythang;
        private string maho, mact, mahd, tench, loaict;
        private int ngay, thang, nam;
        private int chiso;
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
        public string Loaict
        {
            get { return loaict; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    loaict = value;
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
        public int Chiso
        {
            get { return chiso; }
            set { chiso = value; }
        }
        public int Ngay
        {
            get { return ngay; }
            set { ngay = value; }
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
            ngaythang = DateTime.Now;
        }
        public Hoadon(Hoadon hd)
        {
            this.maho = hd.maho;
            this.mact = hd.mact;
            this.mahd = hd.mahd;
            this.tench = hd.tench;
            this.loaict = hd.loaict;
            this.ngaythang = hd.ngaythang;
            this.chiso = hd.chiso;
            this.tinhtrang = hd.tinhtrang;
        }
        public Hoadon(DateTime ngaythang, string maho,string mact,string mahd,string tench,string loaict,int ngay,int thang,int nam,int chiso,string tinhtrang)
        {
            this.ngaythang = ngaythang;
            this.maho = maho;
            this.mact = mact;
            this.mahd = mahd;
            this.tench = tench;
            this.loaict = loaict;
            this.chiso = chiso;
            this.ngay = ngay;
            this.nam = nam;
            this.thang = thang;
            this.tinhtrang = tinhtrang;
        }
    }
}
