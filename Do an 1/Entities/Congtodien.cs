using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an_1.Entities
{
    public class Congtodien
    {
        private string maho;
        private string mact;
        private int sosx;
        private DateTime ngayhd;
        private string loaict;
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
        public int Sosx
        {
            get { return sosx; }
            set 
            {
                sosx = value;
            }
        }
        public DateTime Ngayhd
        {
            get { return ngayhd; }
            set { ngayhd = value; }
        }
        public string Loaict
        {
            get { return loaict; }
            set
            {    
                if(value.Length==4)
                    loaict = value;
            }
        }
        public Congtodien()
        {
        }
        public Congtodien (Congtodien ct)
        {
            this.maho = ct.maho;
            this.mact = ct.mact;
            this.sosx = ct.sosx;
            this.ngayhd = ct.ngayhd;
            this.loaict = ct.loaict;
        }
        public Congtodien(string maho, string mact, int sosx, DateTime ngayhd, string loaict)
        {
            this.maho = maho;
            this.mact = mact;
            this.sosx = sosx;
            this.ngayhd = ngayhd;
            this.loaict = loaict;
        }
    }
}
