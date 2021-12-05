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
    class HoadonDAL : IHoadonDAL
    {
        private string Txtfile = "C:/Users/DELL/Documents/DoAn1/Hoadon.txt";
        private IHogiadinhBLL Ho = new HogiadinhBLL();
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
                    list.Add(new Hoadon(a[0],DateTime.Parse(a[1]), a[2], a[3],a[4],double.Parse(a[5]),a[6]));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }

        public void Themhoadon(Hoadon hd)
        {
            Hogiadinh h = Ho.GetHogiadinh(hd.Maho);
            StreamWriter fwrite = File.AppendText(Txtfile);
            fwrite.WriteLine();
            fwrite.Write(hd.Maho + "#" + hd.Ngaythang.Month+"/"+hd.Ngaythang.Day+"/"+hd.Ngaythang.Year + "#" +hd.Mahd + "#" + h.Tench + "#" + h.Sothe + "#" + hd.Tt + "#" + hd.Tinhtrang);
            fwrite.Close();
        }

        public void Update(List<Hoadon> list)
        {
            StreamWriter fwrite = File.CreateText(Txtfile);
            for (int i = 0; i < list.Count; i++)
            {
                fwrite.WriteLine(list[i].Maho + "#" + list[i].Ngaythang.Month+"/"+list[i].Ngaythang.Day+"/"+ list[i].Ngaythang.Year + "#" +list[i].Mahd + "#" + list[i].Tench + "#" + list[i].Sothe + "#" + list[i].Tt + "#" +list[i].Tinhtrang);
            }
            fwrite.Close();
        }
    }
}
