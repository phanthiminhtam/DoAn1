using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_an_1.Entities;
using System.IO;
using Do_an_1.DataAccessLayer.Interface;
using Do_an_1.BusinessLayer;
using Do_an_1.BusinessLayer.Interface;

namespace Do_an_1.DataAccessLayer
{
    class ChisodienDAL : IChisodienDAL
    {
        private string Txtfile = "C:/Users/DELL/Documents/DoAn1/Chisodien.txt";
        private ICongtodienBLL Ct = new CongtodienBLL();
        public List<Chisodien> GetAllChisodien()
        {
            List<Chisodien> list = new List<Chisodien>();
            StreamReader fread = File.OpenText(Txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('#');
                    list.Add(new Chisodien(a[0],a[1], DateTime.Parse(a[2]),int.Parse(a[3]),int.Parse(a[4]),a[5], int.Parse(a[6]),double.Parse(a[7])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        public void Themchiso(Chisodien cs)
        {
            Congtodien t = Ct.GetCongtodien(cs.Mact);
            StreamWriter fwrite = File.AppendText(Txtfile);
            fwrite.WriteLine();
            fwrite.Write(t.Maho + "#" + cs.Mact + "#" +  cs.Thoigian.Month+"/"+cs.Thoigian.Day+"/"+cs.Thoigian.Year + "#" + cs.Thang + "#" + cs.Nam +"#" + t.Loaict + "#" + cs.Chiso + "#" + cs.Tinhtien);
            fwrite.Close();
        }
        public void Update(List<Chisodien> list)
        {
            StreamWriter fwrite = File.CreateText(Txtfile);
            for (int i = 0; i < list.Count; i++)
            {
                fwrite.WriteLine(list[i].Maho + "#" + list[i].Mact+ "#" + list[i].Thoigian.Month+"/"+list[i].Thoigian.Day+"/"+list[i].Thoigian.Year + "#" + list[i].Thang + "#" + list[i].Nam +"#" + list[i].Loaict + "#" + list[i].Chiso + "#" + list[i].Tinhtien);
            }
            fwrite.Close();
        }
    }
}
