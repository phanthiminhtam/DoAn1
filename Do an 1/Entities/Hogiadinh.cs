using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an_1.Entities
{
    public class Hogiadinh
    {
        private string maho;
        private string tench;
        private string gioitinh;
        private DateTime ngaysinh;
        private string diachi;
        private string sdt;
        private string sothe;
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
        public string Gioitinh
        {
            get { return gioitinh; }
            set
            {
                    gioitinh = value;
            }
        }
        public string Diachi
        {
            get { return diachi; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    diachi = value;
            }
        }
        public DateTime Ngaysinh
        {
            get { return ngaysinh; }
            set
            {
                ngaysinh = value;
            }
        }
        public string Sdt
        {
            get { return sdt; }
            set{
                if (!string.IsNullOrEmpty(value))
                    sdt = value;
            }
        }
        public string Sothe
        {
            get { return sothe; }
            set 
            { 
                if(!string.IsNullOrEmpty(value))
                sothe = value; 
            }
        }
        public Hogiadinh()
        {  
        }
        public Hogiadinh(Hogiadinh ho)
        {
            this.maho = ho.maho;
            this.tench = ho.tench;
            this.gioitinh = ho.gioitinh;
            this.diachi = ho.diachi;
            this.ngaysinh = ho.ngaysinh;
            this.sdt = ho.sdt;
            this.sothe = ho.sothe;
        }
        public Hogiadinh(string maho,string tench,string diachi,string gioitinh,DateTime ngaysinh,string sdt,string sothe )
        {
            this.maho = maho;
            this.tench = tench;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.ngaysinh = ngaysinh;
            this.sdt = sdt;
            this.sothe = sothe;
        }
    }
}
