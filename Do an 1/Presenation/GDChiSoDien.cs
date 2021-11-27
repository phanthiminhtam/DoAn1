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
    public class GDChiSoDien
    {
        private IChisodienBLL Cs = new ChisodienBLL();
        public void Input()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                          Thêm Thông Tin Chỉ Sơ Điện                       ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════╝");
            Chisodien cs = new Chisodien();
            while (true)
            {
                Console.SetCursorPosition(20, 8); Console.Write("Mã hộ gia đình: ");
                cs.Maho = Console.ReadLine();
                if (cs.Maho.Length == 5 && Cs.ExitMH(cs.Maho)) break;
                else
                    Console.WriteLine("Nhập lại mã hộ!");
            }
            while (true)
            {
                Console.SetCursorPosition(20, 9); Console.Write("Mã công tơ: ");
                cs.Mact = Console.ReadLine();
                if (cs.Mact.Length == 5 && Cs.ExitMCT(cs.Mact)) break;
                else
                    Console.WriteLine("Nhập lại mã công tơ!");
            }
            Console.SetCursorPosition(20, 10); Console.Write("Thời gian:  ");
            cs.Thoigian = DateTime.Parse(Console.ReadLine());
            while (true)
            {
                Console.SetCursorPosition(20, 11); Console.Write("Loại công tơ: ");
                cs.Loaict = Console.ReadLine();
                if (cs.Loaict == "CTGD" || cs.Loaict == "CTKD") break;
                else
                    Console.WriteLine("Nhập lại loại công tơ !");
            }
            while(true)
            {
                Console.SetCursorPosition(20, 12); Console.Write("Chỉ số: ");
                cs.Chiso = int.Parse(Console.ReadLine());
                if (cs.Chiso >=0) break;
                Console.WriteLine("Nhập lại chỉ số điện mới!");
            }
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
            Console.WriteLine("{0,-8}{1,-15}{2,-17}{3,-15}{4,-15}", "Mã hộ", "Mã công tơ", "Thời gian", "Loại công tơ", "Chỉ số");
            foreach (var cs in list)
            {
                Console.Write("{0,-8}{1,-15}", cs.Maho, cs.Mact);
                Console.Write("{0:d}", cs.Thoigian);
                Console.Write("{0,-1}{1,-15}{2,-15}","\t", cs.Loaict, cs.Chiso);
                Console.WriteLine("Nhấn enter để tiếp tục....");
            }
        }
        public void Correct()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                                  Sửa Thông Tin Chỉ Số Điện                                ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Chisodien> list = Cs.GetAllChisodien();
            int chisos;
            Console.Write("Nhập chỉ số cần sửa: ");
            chisos = int.Parse(Console.ReadLine());
            int i;
            for (i = 0; i < list.Count; i++)
            {
                if (list[i].Chiso == chisos) break;
            }
            if (i < list.Count)
            {
                Chisodien cs = new Chisodien(list[i]);
                Console.SetCursorPosition(20, 8); Console.Write("Mã hộ gia đình mới: ");
                string mh = Console.ReadLine();
                if (!string.IsNullOrEmpty(mh) && Cs.ExitMH(cs.Maho) && mh != cs.Maho) cs.Maho = mh;
                Console.SetCursorPosition(20, 9); Console.Write("Thời gian mới: ");
                DateTime tg = DateTime.Parse(Console.ReadLine()); cs.Thoigian = tg;
                Console.SetCursorPosition(20, 10); Console.Write("Loại công tơ mới: ");
                string loai = Console.ReadLine();
                if (!string.IsNullOrEmpty(loai) && loai != cs.Loaict) 
                     cs.Loaict = loai;
                Console.SetCursorPosition(20, 11); Console.Write("Chỉ số mới: ");
                int csm = int.Parse(Console.ReadLine());
                if (csm != 0 && csm != cs.Chiso)
                    cs.Chiso = csm;
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
                Console.SetCursorPosition(20, 18); Console.WriteLine("\t\t\t║               5.Quay lại màn hình chính                      ║");
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
