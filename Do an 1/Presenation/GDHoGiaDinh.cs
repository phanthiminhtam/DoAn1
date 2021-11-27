using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_an_1.Entities;
using Do_an_1.BusinessLayer;
using Do_an_1.BusinessLayer.Interface;

namespace Do_an_1.Presenation
{
     public class GDHoGiaDinh
     {
        private IHogiadinhBLL Ho = new HogiadinhBLL();
        public void Input()
        {

            Console.Clear();
            Console.SetCursorPosition(25, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(25, 6); Console.WriteLine("║                          Thêm Thông Tin Hộ Gia Đình                       ║");
            Console.SetCursorPosition(25, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════╝");
            Hogiadinh ho = new Hogiadinh();
            while (true)
            {
                Console.SetCursorPosition(27, 8); Console.Write("Mã hộ gia đình: ");
                ho.Maho = Console.ReadLine();
                if (ho.Maho.Length == 5 && !Ho.ExitMH(ho.Maho))
                    break;
                else
                    Console.WriteLine("Nhập lại mã hộ!");
            }
            Console.SetCursorPosition(27, 9); Console.Write("Tên chủ hộ: ");
            ho.Tench = Console.ReadLine();
            do
            {
                Console.SetCursorPosition(27, 10); Console.Write("Giới tính : ");
                ho.Gioitinh= Console.ReadLine();
                if (ho.Gioitinh != "Nam" && ho.Gioitinh != "Nu")
                {
                    Console.Write("Ban nhap sai moi nhap lai...");
                }
            } while (ho.Gioitinh != "Nam" && ho.Gioitinh != "Nu");
            Console.SetCursorPosition(27, 11); Console.Write("Ngày sinh: ");
            ho.Ngaysinh = DateTime.Parse(Console.ReadLine());
            Console.SetCursorPosition(27, 12); Console.Write("Địa chỉ: ");
            ho.Diachi = Console.ReadLine();
            while (true)
            {
                Console.SetCursorPosition(27, 13); Console.Write("Số điện thoại: ");
                ho.Sdt = Console.ReadLine();
                if (ho.Sdt.ToString().Length == 10) break;
                else
                    Console.WriteLine("Nhập lai số điện thoại!");
            }
            while (true)
            {
                Console.SetCursorPosition(27, 14); Console.Write("Số thẻ nộp tiền: ");
                ho.Sothe = Console.ReadLine();
                if (ho.Sothe.Length == 12) break;
                else
                    Console.WriteLine("Nhập lai số thẻ!");
            }
            Ho.Themhogiadinh(ho);
        }
        public void Display()
        {
            Console.Clear();
            Console.Clear();
            Console.SetCursorPosition(13, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(13, 6); Console.WriteLine("║                                 Hiện Thông Tin Hộ Gia Đình                                ║");
            Console.SetCursorPosition(13, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Hogiadinh> list = Ho.GetAllHogiadinh();
            Console.WriteLine("{0,-7}{1,-17}{2,-11}{3,-15}{4,-10}{5,-15}{6,-15}", "Mã hộ", "Tên chủ hộ", "Giới tính","Ngày sinh","Địa chỉ" ,"Số điện thoại", "Số thẻ nộp tiền");
            foreach (var ho in list)
            { 
                Console.Write("{0,-7}{1,-17}{2,-11}",ho.Maho,ho.Tench,ho.Gioitinh);
                Console.Write("{0:d}", ho.Ngaysinh);
                Console.Write("{0,-4}{1,-10}{2,-15}{3,-15}",'\t', ho.Diachi, ho.Sdt, ho.Sothe);
                Console.WriteLine("Nhấn enter để tiếp tục..");
            }
        }
        public void Correct()
        {
            Console.Clear();
            Console.SetCursorPosition(13, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(13, 6); Console.WriteLine("║                                  Sửa Thông Tin Hộ Gia đình                                ║");
            Console.SetCursorPosition(13, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Hogiadinh> list = Ho.GetAllHogiadinh();
            string Masua;
            Console.Write("Nhập mã hộ cần sửa: ");
            Masua = Console.ReadLine();
            int i;
            for (i = 0; i < list.Count; i++)
            {
                if (list[i].Maho == Masua) break;
            }
            if (i < list.Count)
            {
                Hogiadinh ho = new Hogiadinh(list[i]);
                Console.SetCursorPosition(14, 8); Console.Write("Tên chủ hộ mới: ");
                string ten = Console.ReadLine();
                if (!string.IsNullOrEmpty(ten) && ten != ho.Tench) ho.Tench = ten;
                Console.SetCursorPosition(14, 9); Console.Write("Giới tính : ");
                string gt = Console.ReadLine();
                if (!string.IsNullOrEmpty(gt) && gt != ho.Gioitinh) ho.Gioitinh = gt;
                Console.SetCursorPosition(14, 10); Console.Write("Ngày sinh: ");
                DateTime ns = DateTime.Parse(Console.ReadLine()); ho.Ngaysinh = ns;
                Console.SetCursorPosition(14, 11); Console.Write("Số điện thoại: ");
                string sdt = Console.ReadLine();
                if (!string.IsNullOrEmpty(sdt) && sdt != ho.Sdt) ho.Sdt = sdt;
                Console.SetCursorPosition(14, 12); Console.Write("Số thẻ: ");
                string st = Console.ReadLine();
                if (!string.IsNullOrEmpty(st) && st != ho.Sothe) ho.Sothe = st;
                Ho.Suahogiadinh(ho);
            }
            else
            {
                Console.SetCursorPosition(13, 8); Console.Write("----------> Không tồn tại mã hộ này! <----------");
            }
        }
        public void Delete()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                                  Xóa Thông Tin Hộ Gia đình                                ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Hogiadinh> list = Ho.GetAllHogiadinh();
            string Maxoa;
            Console.Write("Nhập mã hộ cần xóa: ");
            Maxoa = Console.ReadLine();
            int i;
            for (i = 0; i < list.Count; i++)
            {
                if (list[i].Maho == Maxoa) break;
            }
            if (i < list.Count)
            {
                Console.SetCursorPosition(15, 8); Console.Write("--------------> Xóa Thành Công! <----------------");
                Ho.Xoahogiadinh(Maxoa);
                Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(15, 8); Console.Write("----------------> Không Tồn Tại Mã Hộ Nay..... <----------------");
                Console.ReadKey();
            }
        }
        public void Search()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                             Tìm kiếm Thông Tin Hộ Gia đình                                ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            Hogiadinh ho = new Hogiadinh();
            char c;
            while (true)
            {
                Console.SetCursorPosition(15, 8);Console.Write("\nTìm mã_M,Tìm tên chủ hộ_T,Tìm địa chỉ_D: ");
                try
                {
                    c = Char.ToUpper(char.Parse(Console.ReadLine()));
                    if (c == 'M' || c == 'T' || c == 'D') 
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("-----------> Nhập lại cho đúng <-----------");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bạn nhập sai định dạng!");
                }
            }
            switch (c)
            { 
                case 'M':
                    Console.SetCursorPosition(12, 11); Console.Write("----> Mời nhập mã muốn tìm: ");
                    ho.Maho = Console.ReadLine();
                    break;
                case 'T':
                    Console.SetCursorPosition(12, 11); Console.Write("---------> Mời nhập tên muốn tìm: ");
                    ho.Tench = Console.ReadLine();
                    break;
                case 'D':
                    Console.SetCursorPosition(12, 11); Console.Write("---------> Mời nhập địa chỉ muốn tìm: ");
                    ho.Diachi = Console.ReadLine();
                    break;
            }
            Console.WriteLine();
            if(Ho.Timho(ho).Count>0)
            {
                Console.WriteLine("\n{0,-7}{1,-17}{2,-11}{3,-15}{4,-10}{5,-15}{6,-15}", "Mã hộ", "Tên chủ hộ", "Giới tính", "Ngày sinh", "Địa chỉ", "Số điện thoại", "Số thẻ nộp tiền");
                foreach (var a in Ho.Timho(ho))
                {
                    Console.Write("{0,-7}{1,-17}{2,-11}", a.Maho, a.Tench, a.Gioitinh);
                    Console.Write("{0:d}", a.Ngaysinh);
                    Console.Write("{0,-4}{1,-10}{2,-15}{3,-15}", '\t', a.Diachi, a.Sdt, a.Sothe);
                    Console.WriteLine("Nhấn enter để tiếp tục..");
                }
            }
            else
            {
                Console.WriteLine("Không tồn tại thông tin đó!");
            }
        }
        public void MenuHGD()
        {
            do
            {
                Console.Clear();
                Console.SetCursorPosition(20, 5);  Console.WriteLine("\t\t\t╔══════════════════════════════════════════════════════════════╗");
                Console.SetCursorPosition(20, 6);  Console.WriteLine("\t\t\t║                                                              ║");
                Console.SetCursorPosition(20, 7);  Console.WriteLine("\t\t\t║                   MENU QUẢN LÝ HỘ GIA ĐÌNH                   ║");
                Console.SetCursorPosition(20, 8);  Console.WriteLine("\t\t\t║                                                              ║");
                Console.SetCursorPosition(20, 9);  Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 10); Console.WriteLine("\t\t\t║               1.Thêm Thông Tin Hộ Gia Đình                   ║");
                Console.SetCursorPosition(20, 11); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 12); Console.WriteLine("\t\t\t║               2.Sửa Thông Tin Hộ Gia Đình                    ║");
                Console.SetCursorPosition(20, 13); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 14); Console.WriteLine("\t\t\t║               3.Xóa Thông Tin Hộ Gia Đình                    ║");
                Console.SetCursorPosition(20, 15); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 16); Console.WriteLine("\t\t\t║               4.Hiển Thị Thông Tin Hộ Gia Đình               ║");
                Console.SetCursorPosition(20, 17); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 18); Console.WriteLine("\t\t\t║               5.Tìm kiếm Thông Tin Hộ Gia Đình               ║");
                Console.SetCursorPosition(20, 19); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 20); Console.WriteLine("\t\t\t║               6.Quay lại màn hình chính                      ║");
                Console.SetCursorPosition(20, 21); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 22); Console.WriteLine("\t\t\t║  Mời Bạn Chọn Chức Năng :                                    ║");
                Console.SetCursorPosition(20, 23); Console.WriteLine("\t\t\t╚══════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(67, 22);
                ConsoleKeyInfo c = Console.ReadKey();
                switch(c.KeyChar)
                {
                    case '1':
                        Input();
                        Display();
                        Console.ReadKey();
                        break;
                    case '2':
                        Correct();
                        Display();
                        Console.ReadKey();
                        break;
                    case '3':
                        Delete();
                        Display();
                        Console.ReadKey();
                        break;
                    case '4':
                        Display();
                        Console.ReadKey();
                        break;
                    case '5':
                        Search();
                        Console.ReadKey();
                        break;
                    case '6':
                        GiaoDien t = new GiaoDien();
                        t.Menu();
                        break;
                }
            } while (true);
        }
    }
}
