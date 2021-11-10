using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_an_1.BusinessLayer;
using Do_an_1.Entities;

namespace Do_an_1.Presenation
{
    public class GiaoDien
    {
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.SetCursorPosition(20, 6);  Console.Write("╔═══════════════════════════════════════════════════════════════════════════╗");
                Console.SetCursorPosition(20, 7);  Console.Write("║                  CHƯƠNG TRÌNH QUẢN LÝ HỘ TIÊU THỤ ĐIỆN                    ║");
                Console.SetCursorPosition(20, 8);  Console.Write("╠═══════════════════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 9);  Console.Write("║                                 MENU LỰA CHỌN                             ║");
                Console.SetCursorPosition(20, 10); Console.Write("╠══════════╦════════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 11); Console.Write("║    1     ║            Quản Lý Hộ Gia Đình                                 ║");
                Console.SetCursorPosition(20, 12); Console.Write("╠══════════╬════════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 13); Console.Write("║    2     ║            Quản Lý Công Tơ Điện                                ║");
                Console.SetCursorPosition(20, 14); Console.Write("╠══════════╬════════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 15); Console.Write("║    3     ║            Quản Lý Chỉ Số Điện                                 ║");
                Console.SetCursorPosition(20, 16); Console.Write("╠══════════╬════════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 17); Console.Write("║    4     ║            Quản Lý Nhân Viên                                   ║");
                Console.SetCursorPosition(20, 18); Console.Write("╠══════════╬════════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 19); Console.Write("║    5     ║            Quản Lý Hóa Đơn Tiền Điện                           ║");
                Console.SetCursorPosition(20, 20); Console.Write("╠══════════╬════════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 21); Console.Write("║    6     ║            Thống Kê                                            ║");
                Console.SetCursorPosition(20, 22); Console.Write("╠══════════╬════════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 23); Console.Write("║    7     ║            Thoát Khỏi Chương Trình                             ║");
                Console.SetCursorPosition(20, 24); Console.Write("╠══════════╩════════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 25); Console.Write("║  Mời Bạn Chọn Chức Năng :                                                 ║");
                Console.SetCursorPosition(20, 26); Console.Write("╚═══════════════════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(48, 25);
                ConsoleKeyInfo c = Console.ReadKey();
                switch(c.KeyChar)
                {
                    case '1':
                        GDHoGiaDinh G1 = new GDHoGiaDinh();
                        G1.MenuHGD();
                        break;
                    case '2':
                        GDCongToDien G2 = new GDCongToDien();
                        G2.MenuCTD();
                        break;
                    case '3':
                        GDChiSoDien G3 = new GDChiSoDien();
                        G3.MenuCSD();
                        break;
                    case '4':
                        GDNhanVien G4 = new GDNhanVien();
                        G4.MenuNV();
                        break;
                    case '5':
                        GDHoaDon G5 = new GDHoaDon();
                        G5.MenuHD();
                        break;
                    case '6':
                        GDThongKe G6 = new GDThongKe();
                        G6.MenuTK();
                        break;
                    case '7':
                        Program.Start();
                        break;
                }
            } while (true);
        }
       
    }
}
