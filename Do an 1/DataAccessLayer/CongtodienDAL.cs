using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_an_1.Entities;
using System.IO;
using Do_an_1.DataAccessLayer.Interface;

namespace Do_an_1.DataAccessLayer
{
    class CongtodienDAL: ICongtodienDAL
    {
        private string Txtfile = "C:/Users/DELL/Documents/DoAn1/Congtodien.txt";
        public List<Congtodien> GetAllCongtodien()
        {
            List<Congtodien> list = new List<Congtodien>();
            StreamReader fread = File.OpenText(Txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('#');
                    list.Add(new Congtodien(a[0], a[1], int.Parse(a[2]), DateTime.Parse(a[3]), a[4]));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }

        public void Themcongto(Congtodien ct)
        {
            StreamWriter fwrite = File.AppendText(Txtfile);
            fwrite.Write(ct.Maho + "#" + ct.Mact + "#" + ct.Sosx + "#" + ct.Ngayhd.Month+ "/" +ct.Ngayhd.Day + "/" + ct.Ngayhd.Year + "#" + ct.Loaict);
            fwrite.Close();
        }

        public void Update(List<Congtodien> list)
        {
            StreamWriter fwrite = File.CreateText(Txtfile);
            for (int i = 0; i < list.Count; i++)
            {
                fwrite.WriteLine(list[i].Maho + "#" + list[i].Mact + "#" + list[i].Sosx + "#" + list[i].Ngayhd + "#" + list[i].Loaict);
            }
            fwrite.Close();
        }
    }
}
