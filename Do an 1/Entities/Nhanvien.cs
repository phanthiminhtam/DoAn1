using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an_1.Entities
{
     public class Nhanvien
    {
        private string manv;
        private string tennv;
        private DateTime ngaysinh;
        private string gioitinh;
        private string sdt;
        private int songaylv;
        private string chucvu;
        private float hsl;
        private float tongluong;
        public string Manv
        {
            get { return manv; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    manv = value;
            }
        }
        public string Tennv
        {
            get { return tennv; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    tennv = value;
            }
        }
        public string Gioitinh
        {
            get { return gioitinh; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    gioitinh = value;
            }
        }
        public string Chucvu
        {
            get { return chucvu; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    chucvu = value;
            }
        }
        public int Songaylv
        {
            get { return songaylv; }
            set 
            { 
                songaylv = value;
            }
        }
        public DateTime Ngaysinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }
        public string Sdt
        {
            get { return sdt; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    sdt = value;
            }
        }
        public float Hsl
        {
            get { return hsl; }
            set 
            {
                if (value >= 210)
                    hsl = value;
            }
        }
        public float Tongluong
        {
            get { return tongluong=Songaylv * Hsl; }
        }
        public Nhanvien()
        {
        }
        public Nhanvien(Nhanvien nv)
        {
            this.manv = nv.manv;
            this.tennv = nv.tennv;
            this.ngaysinh = nv.ngaysinh;
            this.gioitinh = nv.gioitinh;
            this.sdt = nv.sdt;
            this.songaylv = nv.songaylv;
            this.hsl = nv.hsl;
            this.tongluong = nv.tongluong;
            this.chucvu = nv.chucvu;

        }
        public Nhanvien(string manv,string tennv,DateTime ngaysinh,string gioitinh,string sdt, int songaylv,float hsl,float tongluong, string chucvu)
        {
            this.manv = manv;
            this.tennv = tennv;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;         
            this.sdt = sdt;
            this.songaylv = songaylv;
            this.hsl = hsl;
            this.tongluong = tongluong;
            this.chucvu = chucvu;
        }
    }
}
