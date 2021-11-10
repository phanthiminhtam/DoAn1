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
    class HogiadinhDAL: IHogiadinhDAL
    {
        private string Txtfile = "C:/Users/DELL/Documents/DoAn1/Hogiadinh.txt";

        public List<Hogiadinh> GetAllHogiadinh()
        {
            List<Hogiadinh> list = new List<Hogiadinh>();
            StreamReader fread= File.OpenText(Txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {              
                    string[] a = s.Split('#');
                    list.Add(new Hogiadinh(a[0],a[1],a[2],a[3],DateTime.Parse(a[4]),a[5],a[6]));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }

        public void Themhogiadinh(Hogiadinh ho)
        {
            StreamWriter fwrite = File.AppendText(Txtfile);
            fwrite.WriteLine(ho.Maho + "#" + ho.Tench + "#" + ho.Diachi + "#" + ho.Gioitinh + "#" + ho.Ngaysinh+ "#" + ho.Sdt + "#" + ho.Sothe);
            fwrite.Close();
        }

        public void Update(List<Hogiadinh> list)
        {
            StreamWriter fwrite = File.CreateText(Txtfile);
            for(int i=0;i<list.Count; i++)
            {
                fwrite.WriteLine(list[i].Maho + "#" + list[i].Tench + "#" + list[i].Diachi + "#" + list[i].Gioitinh + "#" + list[i].Ngaysinh + "#" + list[i].Sdt + "#" + list[i].Sothe);
            }
            fwrite.Close();
        }
    }
}
