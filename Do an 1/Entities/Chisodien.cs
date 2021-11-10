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
        private string loaict;
        private int chiso;
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
        public Chisodien()
        {
        }
        public Chisodien(Chisodien cs)
        {
            this.maho = cs.maho;
            this.mact = cs.mact;
            this.loaict = cs.loaict;
            this.thoigian = cs.thoigian;
            this.chiso = cs.chiso;

        }
        public Chisodien(string maho,string mact,string loaict,DateTime thoigian,int chiso)
        {
            this.maho = maho;
            this.mact = mact;
            this.loaict = loaict;
            this.thoigian = thoigian;
            this.chiso = chiso;
        }
    }
}
