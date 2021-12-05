using Do_an_1.BusinessLayer;
using Do_an_1.BusinessLayer.Interface;
using Do_an_1.Entities;
using System;
using System.Collections.Generic;

namespace Do_an_1.Presenation
{
    public class GDChiSoDien
    {
        private IChisodienBLL Cs = new ChisodienBLL();
        private ICongtodienBLL Ct = new CongtodienBLL();
        public void Input()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                          Thêm Thông Tin Chỉ Sơ Điện                       ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════╝");
            Chisodien cs = new Chisodien();
            while (true)
            {
                Console.SetCursorPosition(20, 9); Console.Write("Mã công tơ: ");
                cs.Mact = Console.ReadLine();
                try
                {
                    Congtodien ct = Ct.GetCongtodien(cs.Mact);
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.SetCursorPosition(20, 10); Console.Write("Thời gian chốt số:  ");
            cs.Thoigian = DateTime.Parse(Console.ReadLine());
            if (cs.Thoigian.Month == 1)
            {
                cs.Thang = 12;
                cs.Nam = cs.Thoigian.Year - 1;
            }
            else
            {
                cs.Thang = cs.Thoigian.Month - 1;
                cs.Nam = cs.Thoigian.Year;
            }
            while (true)
            {
                Console.SetCursorPosition(20, 11); Console.Write("Chỉ số điện: ");
                cs.Chiso = int.Parse(Console.ReadLine());
                if (cs.Chiso >=0) break;
                Console.WriteLine("Nhập lại chỉ số điện mới!");
            }
            cs.Tinhtien = Cs.Tiendien(cs);
            Cs.Themchiso(cs);
        }
        public void Display()
        {
            Console.Clear();
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                                 Hiện Thông Tin Chi Số Điện                                ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Chisodien> list = Cs.GetAllChisodien();
            Console.WriteLine("|{0,-8}|{1,-12}|{2,-17}|{3,-12}|{4,-15}|{5,-10}|{6,-15}|","Mã hộ","Mã công tơ", "Thời gian", "Tháng/Năm", "Loại công tơ", "Chỉ số","Tiền điện");
            Congtodien c;
            foreach (var cs in list)
            {
                c = Ct.GetCongtodien(cs.Mact);
                Console.Write("|{0,-8}|{1,-12}|",c.Maho,cs.Mact);
                Console.Write("{0:d}\t|", cs.Thoigian);
                Console.Write("{0}/{1,-10}|", cs.Thang, cs.Nam);
                Console.Write("{0,-15}|{1,-10}|{2,-15}|", c.Loaict, cs.Chiso,cs.Tinhtien);
                Console.WriteLine("Nhấn enter để tiếp tục..");
            }
        }
        public void Correct()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                                  Sửa Thông Tin Chỉ Số Điện                                ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Chisodien> list = Cs.GetAllChisodien();
            string mact;
            Console.Write("Nhập mã công tơ: ");
            mact = Console.ReadLine();
            int i;
            for (i = 0; i < list.Count; i++)
            {
                if (list[i].Mact == mact) break;
            }
            if (i < list.Count)
            {
                Chisodien cs = new Chisodien(list[i]);
                Console.SetCursorPosition(20, 9); Console.Write("Mã công tơ mới: ");
                string mct = Console.ReadLine();
                if (mct != cs.Mact && Cs.ExitMCT(cs.Mact)) cs.Mact = mct;
                Console.SetCursorPosition(20, 10); Console.Write("Thời gian mới: ");
                DateTime tg = DateTime.Parse(Console.ReadLine()); cs.Thoigian = tg;         
                Console.SetCursorPosition(20, 11); Console.Write("Chỉ số mới: ");
                int csm = int.Parse(Console.ReadLine());
                if (csm != 0 && csm != cs.Chiso)
                {
                    cs.Chiso = csm;
                   
                }
                cs.Tinhtien = Cs.Tiendien(cs);
                Cs.Suachiso(cs);
            }
        }
        public void Delete()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                                  Xóa Thông Tin Chỉ số điện                                ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Chisodien> list = Cs.GetAllChisodien();
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
                Console.SetCursorPosition(15, 8); Console.Write("--------------> Xóa Thành Công! <----------------");
                Cs.Xoachiso(Maxoa);
                Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(15, 8); Console.Write("----------------> Không Tồn Tại Mã công tơ Nay........ <----------------");
                Console.ReadKey();
            }
        }
        public void MenuCSD()
        {
            do
            {
                Console.Clear();
                Console.SetCursorPosition(20, 5);  Console.WriteLine("\t\t\t╔══════════════════════════════════════════════════════════════╗");
                Console.SetCursorPosition(20, 6);  Console.WriteLine("\t\t\t║                                                              ║");
                Console.SetCursorPosition(20, 7);  Console.WriteLine("\t\t\t║                MENU QUẢN LÝ CHỈ SỐ ĐIỆN                      ║");
                Console.SetCursorPosition(20, 8);  Console.WriteLine("\t\t\t║                                                              ║");
                Console.SetCursorPosition(20, 9);  Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 10); Console.WriteLine("\t\t\t║               1.Thêm Thông Tin Chỉ Số Điện                   ║");
                Console.SetCursorPosition(20, 11); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 12); Console.WriteLine("\t\t\t║               2.Sửa Thông Tin Chỉ Số Điện                    ║");
                Console.SetCursorPosition(20, 13); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 14); Console.WriteLine("\t\t\t║               3.Xóa Thông Tin Chỉ Số Điện                    ║");
                Console.SetCursorPosition(20, 15); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 16); Console.WriteLine("\t\t\t║               4.Hiển Thị Thông Tin Chỉ Số Điện               ║");
                Console.SetCursorPosition(20, 17); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 18); Console.WriteLine("\t\t\t║               5.Quay Lại Màn Hình Chính                      ║");
                Console.SetCursorPosition(20, 19); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 20); Console.WriteLine("\t\t\t║  Mời Bạn Chọn Chức Năng :                                    ║");
                Console.SetCursorPosition(20, 21); Console.WriteLine("\t\t\t╚══════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(67, 20);
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
                        GiaoDien t = new GiaoDien();
                        t.Menu();
                        break;
                }
            } while (true);
        }
    }
}
