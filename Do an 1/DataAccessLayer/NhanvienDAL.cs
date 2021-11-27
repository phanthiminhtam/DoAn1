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
    class NhanvienDAL : INhanvienDAL
    {
        private string Txtfile = "C:/Users/DELL/Documents/DoAn1/Nhanvien.txt";
        public List<Nhanvien> GetAllNhanvien()
        {
            List<Nhanvien> list = new List<Nhanvien>();
            StreamReader fread = File.OpenText(Txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('#');
                    list.Add(new Nhanvien(a[0], a[1],DateTime.Parse(a[2]), a[3],a[4], int.Parse(a[5]),float.Parse(a[6]),float.Parse(a[7]),a[8]));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }

        public void Themnhanvien(Nhanvien nv)
        {
            StreamWriter fwrite = File.AppendText(Txtfile);
            fwrite.WriteLine();
            fwrite.Write(nv.Manv + "#" + nv.Tennv + "#" + nv.Ngaysinh.Month+"/"+ nv.Ngaysinh.Day +"/"+ nv.Ngaysinh.Year + "#" + nv.Gioitinh + "#" +  nv.Sdt + "#" + nv.Songaylv + "#"+ nv.Hsl + "#" + nv.Tongluong + "#" + nv.Chucvu);
            fwrite.Close();
        }

        public void Update(List<Nhanvien> list)
        {
            StreamWriter fwrite = File.CreateText(Txtfile);
            for (int i = 0; i < list.Count; i++)
            {
                fwrite.WriteLine(list[i].Manv + "#" + list[i].Tennv + "#"+ list[i].Ngaysinh + "#" + list[i].Gioitinh + "#" + list[i].Sdt + "#" + list[i].Songaylv + "#" + list[i].Hsl + "#" + list[i].Tongluong + "#" + list[i].Chucvu);
            }
            fwrite.Close();
        }
    }
}
