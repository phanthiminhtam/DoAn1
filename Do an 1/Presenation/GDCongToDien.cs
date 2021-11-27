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
    public class GDCongToDien
    {
        private ICongtodienBLL Ct = new CongtodienBLL();
        public void Input()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                          Thêm Thông Tin Công Tơ Điện                      ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════╝");
            Congtodien ct = new Congtodien();
            while (true)
            {
                Console.SetCursorPosition(20, 8); Console.Write("Mã hộ gia đình: ");
                ct.Maho = Console.ReadLine();
                if (ct.Maho.Length == 5 && Ct.ExitMH(ct.Maho))
                    break;
                else
                    Console.WriteLine("Nhập lại mã hộ!");
            }
            while (true)
            {
                Console.SetCursorPosition(20, 9); Console.Write("Mã công tơ: ");
                ct.Mact = Console.ReadLine();
                if (ct.Mact.Length == 5 && !Ct.ExitMCT(ct.Mact))
                    break;
                else
                    Console.WriteLine("Nhập lại mã công tơ!");
            }
            Console.SetCursorPosition(20, 10); Console.Write("Số sản xuất: ");
            ct.Sosx = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(20, 11); Console.Write("Ngày hoạt động: ");
            ct.Ngayhd = DateTime.Parse(Console.ReadLine());
            while (true)
            {
                Console.SetCursorPosition(20, 12); Console.Write("Loại công tơ: ");
                ct.Loaict = Console.ReadLine();
                if (ct.Loaict.ToUpper() == "CTGD" || ct.Loaict.ToUpper() == "CTKD")
                    break;
                else
                    Console.WriteLine("Nhập lại loại công tơ!");
            }
            Ct.Themcongto(ct);
        }
        public void Display()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                                 Hiện Thông Tin Công Tơ Điện                               ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Congtodien> list = Ct.GetALLCongtodien();
            Console.WriteLine("{0,-8}{1,-15}{2,-15}{3,-17}{4,-15}", "Mã hộ", "Mã công tơ", "Số sản xuất", "Ngày hoạt động", "Loại công tơ");
            foreach (var ct in list)
            {
                Console.Write("{0,-8}{1,-15}{2,-15}", ct.Maho, ct.Mact, ct.Sosx);
                Console.Write("{0:d}", ct.Ngayhd);
                Console.Write("{0,-9}{1,-13}", '\t', ct.Loaict);
                Console.WriteLine("Nhấn enter để tiếp tục....");
            }
        }
        public void Correct()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                                  Sửa Thông Tin Công Tơ Điện                               ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Congtodien> list = Ct.GetALLCongtodien();
            string Masua;
            Console.Write("Nhập mã công tơ cần sửa: ");
            Masua = Console.ReadLine();
            int i;
            for (i = 0; i < list.Count; i++)
            {
                if (list[i].Mact == Masua) break;
            }
            if (i < list.Count)
            {
                Congtodien ct = new Congtodien(list[i]);
                Console.SetCursorPosition(17, 10); Console.Write("Mã hộ gia đình mới: ");
                string mh = Console.ReadLine();
                if (!string.IsNullOrEmpty(mh) && mh != ct.Maho && Ct.ExitMH(ct.Maho))  ct.Maho = mh;
                Console.SetCursorPosition(17, 11); Console.Write("Số sản xuất mới: ");
                int sx = int.Parse(Console.ReadLine());
                if(sx!=0 && sx != ct.Sosx)  ct.Sosx = sx;
                Console.SetCursorPosition(17, 12); Console.Write("Ngày hoạt động mới: ");
                DateTime nhd = DateTime.Parse(Console.ReadLine()); ct.Ngayhd = nhd;
                Console.SetCursorPosition(17, 13); Console.Write("Loại công tơ mới: ");
                string loai = Console.ReadLine();
                if(!string.IsNullOrEmpty(loai) && loai != ct.Loaict) ct.Loaict = loai;
                Ct.Suacongto(ct);
            }
        }
        public void Delete()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                                  Xóa Thông Tin Công tơ điện                               ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Congtodien> list = Ct.GetALLCongtodien();
            string Maxoa;
            Console.Write("Nhập mã công tơ cần xóa: ");
            Maxoa = Console.ReadLine();
            int i;
            for (i = 0; i < list.Count; i++)
            {
                if (list[i].Mact == Maxoa) break;
            }
            if (i < list.Count)
            {
                Console.SetCursorPosition(13, 8); Console.Write("-----------------> Xóa Thành Công! <----------------");
                Ct.Xoacongto(Maxoa);
                Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(13, 8); Console.Write("----------------> Không Tồn Tại Mã công tơ Nay........ <----------------");
                Console.ReadKey();
            }
        }
        public void Search()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                             Tìm kiếm Thông Tin Công Tơ Điện                               ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            Congtodien ct = new Congtodien();
            char c;
            while (true)
            {
                Console.SetCursorPosition(15, 8); Console.Write("\nTìm mã_M,Tìm loại_L: ");
                try
                {
                    c = Char.ToUpper(char.Parse(Console.ReadLine()));
                    if (c == 'M' || c == 'L')
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
                    Console.SetCursorPosition(12, 11); Console.Write("---------> Mời nhập mã công tơ muốn tìm: ");
                    ct.Mact = Console.ReadLine();
                    break;
                case 'L':
                    Console.SetCursorPosition(12, 11); Console.Write("---------> Mời nhập loại công tơ muốn tìm: ");
                    ct.Loaict = Console.ReadLine();
                    break;
            }
            Console.WriteLine();
            if (Ct.Timcongto(ct).Count > 0)
            {
                Console.WriteLine("{0,-8}{1,-15}{2,-15}{3,-17}{4,-15}", "Mã hộ", "Mã công tơ", "Số sản xuất", "Ngày hoạt động", "Loại công tơ");
                foreach (var a in Ct.Timcongto(ct))
                {
                    Console.Write("{0,-8}{1,-15}{2,-15}", a.Maho, a.Mact, a.Sosx);
                    Console.Write("{0:d}", a.Ngayhd);
                    Console.Write("{0,-9}{1,-13}", '\t', a.Loaict);
                    Console.WriteLine("Nhấn enter để tiếp tục....");
                }
            }
            else
            {
                Console.WriteLine("Không tồn tại thông tin đó!");
            }
        }
        public void MenuCTD()
        {
            do
            {
                Console.Clear();
                Console.SetCursorPosition(20, 5);  Console.WriteLine("\t\t\t╔══════════════════════════════════════════════════════════════╗");
                Console.SetCursorPosition(20, 6);  Console.WriteLine("\t\t\t║                                                              ║");
                Console.SetCursorPosition(20, 7);  Console.WriteLine("\t\t\t║                   MENU QUẢN LÝ CÔNG TƠ ĐIỆN                  ║");
                Console.SetCursorPosition(20, 8);  Console.WriteLine("\t\t\t║                                                              ║");
                Console.SetCursorPosition(20, 9);  Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 10); Console.WriteLine("\t\t\t║               1.Thêm Thông Tin Công Tơ Điện                  ║");
                Console.SetCursorPosition(20, 11); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 12); Console.WriteLine("\t\t\t║               2.Sửa Thông Tin Công Tơ Điện                   ║");
                Console.SetCursorPosition(20, 13); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 14); Console.WriteLine("\t\t\t║               3.Xóa Thông Tin Công Tơ Điện                   ║");
                Console.SetCursorPosition(20, 15); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 16); Console.WriteLine("\t\t\t║               4.Hiển Thị Thông Tin Công Tơ Điện              ║");
                Console.SetCursorPosition(20, 17); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 18); Console.WriteLine("\t\t\t║               5.Tìm kiếm Thông Tin Công Tơ Điện              ║");
                Console.SetCursorPosition(20, 19); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 20); Console.WriteLine("\t\t\t║               6.Quay lại màn hình chính                      ║");
                Console.SetCursorPosition(20, 21); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 22); Console.WriteLine("\t\t\t║  Mời Bạn Chọn Chức Năng :                                    ║");
                Console.SetCursorPosition(20, 23); Console.WriteLine("\t\t\t╚══════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(67, 22);
                ConsoleKeyInfo c = Console.ReadKey();
                switch (c.KeyChar)
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

