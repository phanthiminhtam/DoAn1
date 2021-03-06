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
    public class GDThongKe
    {
        private IHoadonBLL Hd = new HoadonBLL();
        public void MenuTK()
        {
            do
            {
                Console.Clear();
                Console.SetCursorPosition(20, 5);  Console.WriteLine("\t\t\t╔══════════════════════════════════════════════════════════════╗");
                Console.SetCursorPosition(20, 6);  Console.WriteLine("\t\t\t║                                                              ║");
                Console.SetCursorPosition(20, 7);  Console.WriteLine("\t\t\t║                     THỐNG KÊ THÔNG TIN                       ║");
                Console.SetCursorPosition(20, 8);  Console.WriteLine("\t\t\t║                                                              ║");
                Console.SetCursorPosition(20, 9);  Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 10); Console.WriteLine("\t\t\t║               1.Thống Kê Hộ Sử Dụng Điện                     ║");
                Console.SetCursorPosition(20, 11); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 12); Console.WriteLine("\t\t\t║               2.Thống Kê Số Công Tơ Điện                     ║");
                Console.SetCursorPosition(20, 13); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 14); Console.WriteLine("\t\t\t║               3.Thống Kê Hộ Đã Đóng Tiền                     ║");
                Console.SetCursorPosition(20, 15); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 16); Console.WriteLine("\t\t\t║               4.Thống Kê Hộ Chưa Đóng Tiền                   ║");
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
                        GDHoGiaDinh ho = new GDHoGiaDinh();
                        Console.SetCursorPosition(0, 9); Console.WriteLine("Số hộ gia đình sử dụng điện: {0}",ho.Thongke());
                        Console.ReadKey();
                        break;
                    case '2':
                        GDCongToDien ct = new GDCongToDien();
                        Console.SetCursorPosition(0, 9); Console.WriteLine("Số công tơ đang sử dụng: {0}", ct.Thongke());
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.WriteLine("\n\n\n\n");
                        GDHoaDon dd = new GDHoaDon();
                        dd.Thongked();
                        Console.ReadKey();
                        break;
                    case '4':
                        Console.WriteLine("\n\n\n\n");
                        GDHoaDon cd = new GDHoaDon();
                        cd.Thongkec();
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
