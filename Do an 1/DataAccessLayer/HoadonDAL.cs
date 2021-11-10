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
    class HoadonDAL : IHoadonDAL
    {
        private string Txtfile = "C:/Users/DELL/Documents/DoAn1/Hoadon.txt";
        public List<Hoadon> GetAllHoadon()
        {
            List<Hoadon> list = new List<Hoadon>();
            StreamReader fread = File.OpenText(Txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('#');
                    list.Add(new Hoadon(DateTime.Parse(a[0]), a[1], a[2], a[3], a[4], a[5], int.Parse(a[6]), int.Parse(a[7]), int.Parse(a[8]), int.Parse(a[9]),a[10]));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }

        public void Themhoadon(Hoadon hd)
        {
            StreamWriter fwrite = File.AppendText(Txtfile);
            fwrite.WriteLine();
            fwrite.Write(hd.Ngaythang + "#" + hd.Maho + "#" + hd.Mact + "#" + hd.Mahd + "#" + hd.Tench + "#" + hd.Loaict + "#" + hd.Ngay 
                + "#" + hd.Thang + "#" + hd.Nam + "#" + hd.Chiso + "#" + hd.Tinhtrang );
            fwrite.Close();
        }

        public void Update(List<Hoadon> list)
        {
            StreamWriter fwrite = File.CreateText(Txtfile);
            for (int i = 0; i < list.Count; i++)
            {
                fwrite.WriteLine(list[i].Ngaythang + "#" + list[i].Maho + "#" + list[i].Mact + "#" + list[i].Mahd + "#" + list[i].Tench + "#" + list[i].Loaict + "#" + list[i].Ngay 
                    + "#" + list[i].Thang + "#" + list[i].Nam + "#" + list[i].Chiso + "#" + list[i].Tinhtrang);
            }
            fwrite.Close();
        }
    }
}
