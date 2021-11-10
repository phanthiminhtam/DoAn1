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
    public class GDHoaDon
    {
        private IHoadonBLL Hd = new HoadonBLL();
        public void Input()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                          Thêm Thông Tin Hóa Đơn                           ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════╝");
            Hoadon hd = new Hoadon();
            Console.SetCursorPosition(20, 8); Console.Write("Thời gian:  ");
            hd.Ngaythang = DateTime.Parse(Console.ReadLine());
            while (true)
            {
                Console.SetCursorPosition(20, 9); Console.Write("Mã hộ gia đình: ");
                hd.Maho = Console.ReadLine();
                if (hd.Maho.Length == 5 && Hd.ExitMH(hd.Maho)) break;
                else
                    Console.WriteLine("Nhập lại mã hộ!");
            }
            while (true)
            {
                Console.SetCursorPosition(20, 10); Console.Write("Mã công tơ: ");
                hd.Mact = Console.ReadLine();
                if (hd.Mact.Length == 5 && Hd.ExitMCT(hd.Mact)) break;
                else
                    Console.WriteLine("Nhập lại mã công tơ!");
            }
            while (true)
            {
                Console.SetCursorPosition(20, 11); Console.Write("Mã hóa đơn: ");
                hd.Mahd = Console.ReadLine();
                if (hd.Mahd.Length == 5 && !Hd.ExitMH(hd.Mahd)) break;
                else
                    Console.WriteLine("Nhập lại mã hóa đơn!");
            }
            Console.SetCursorPosition(20, 12); Console.Write("Tên chủ hộ: ");
            hd.Tench = Console.ReadLine();
            while (true)
            {
                Console.SetCursorPosition(20, 13); Console.Write("Loại công tơ: ");
                hd.Loaict = Console.ReadLine();
                if (hd.Loaict == "CTGD" || hd.Loaict == "CTKD") break;
                else
                    Console.WriteLine("Nhập lại loại công tơ !");
            }
            while (true)
            {
                Console.SetCursorPosition(20, 15); Console.Write("Chỉ số: ");
                hd.Chiso = int.Parse(Console.ReadLine());
                if (hd.Chiso>0) break;
                Console.WriteLine("Nhập lại chỉ số điện hợp lệ !");
            }
            while(true)
            {
                Console.SetCursorPosition(20, 16); Console.Write("Ngày: ");
                hd.Ngay = int.Parse(Console.ReadLine());
                if (hd.Ngay >= 1 && hd.Ngay <= 31)
                    break;
                else
                    Console.WriteLine("Nhập lại ngày!");
            }
            while (true)
            {
                Console.SetCursorPosition(20, 17); Console.Write("Tháng: ");
                hd.Thang = int.Parse(Console.ReadLine());
                if (hd.Thang >= 1 && hd.Thang <= 12)
                    break;
                else
                    Console.WriteLine("Nhập lại năm!");
            }
            Console.SetCursorPosition(20, 18); Console.Write("Năm: ");
            hd.Nam = int.Parse(Console.ReadLine());
            Hd.Themhoadon(hd);
        }
        public void Display()
        {
            Console.Clear();
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                                 Hiện Thông Tin Hóa Đơn                                    ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Hoadon> list = Hd.GetAllHoadon();
            Console.WriteLine("{0,-11}{1,-7}{2,-7}{3,-7}{4,-17}{5,-14}{6,-6},{7,-7},{8,-6}{9,-8}{10,-15}{11,-20}", "Thời gian",
                  "Mã hộ", "Mã công tơ", "Mã hóa đơn", "Tên chủ hộ", "Loại công tơ","Ngày" ,"Tháng","Năm","Chỉ số", "Tổng tiền","Tình trạng");
            foreach (var hd in list)
            {
                Console.Write("{0:d}", hd.Ngaythang);
                Console.Write("{0,-7}{1,-7}{2,-7}{3,-17}{4,-14}{5,-6},{6,-7},{7,-6}{8,-8}{9,-15}{10,-20}",
                    hd.Maho , hd.Mact,hd.Mahd,hd.Tench,hd.Loaict,hd.Ngay,hd.Thang,hd.Nam,hd.Chiso,Hd.Tiendien(hd),hd.Tinhtrang);
                Console.WriteLine("Nhấn enter để tiếp tục....");
            }
        }
        public void Correct()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                                  Sửa Thông Tin Hóa Đơn                                    ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Hoadon> list = Hd.GetAllHoadon();
            string Masua;
            Console.Write("Nhập mã công tơ cần sửa: ");
            Masua = Console.ReadLine();
            int i;
            for (i = 0; i < list.Count; i++)
            {
                if (list[i].Maho == Masua) break;
            }
            if (i < list.Count)
            {
                Hoadon hd = new Hoadon(list[i]);
                Console.SetCursorPosition(20, 8); Console.Write("Mã công tơ mới: ");
                string mct = Console.ReadLine();
                if (!string.IsNullOrEmpty(mct)) hd.Mact = mct;
                Console.SetCursorPosition(20, 9); Console.Write("Mã hóa đơn mới: ");
                string mhd = Console.ReadLine();
                if (!string.IsNullOrEmpty(mhd)) hd.Mahd = mhd;
                Console.SetCursorPosition(20, 10); Console.Write("Tên chủ hộ mới: ");
                string ten = Console.ReadLine();
                if (!string.IsNullOrEmpty(ten)) hd.Tench = ten;
                Console.SetCursorPosition(20, 11); Console.Write("Loại công tơ mới: ");
                string loai = Console.ReadLine(); hd.Loaict = loai;
                Hd.Suahoadon(hd);
            }
        }
        public void Delete()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                                  Xóa Thông Tin Hóa Đơn                                    ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Hoadon> list = Hd.GetAllHoadon();
            string Maxoa;
            Console.Write("Nhập mã hóa đơn cần xóa: ");
            Maxoa = Console.ReadLine();
            int i;
            for (i = 0; i < list.Count; i++)
            {
                if (list[i].Mahd == Maxoa) break;
            }
            if (i < list.Count)
            {
                Console.SetCursorPosition(15, 8); Console.Write("--------------> Xóa Thành Công! <----------------");
                Hd.Xoahoadon(Maxoa);
                Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(15, 8); Console.Write("----------------> Không Tồn Tại Mã hóa đơn này........ <----------------");
                Console.ReadKey();
            }
        }
        public void Search()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                             Tìm kiếm Thông Tin Hóa Đơn                                    ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Hoadon> list = Hd.GetAllHoadon();
            string Matim;
            Console.Write("Nhập mã hóa đơn cần tìm: ");
            Matim = Console.ReadLine();
            int i;
            for (i = 0; i < list.Count; i++)
            {
                if (list[i].Mahd == Matim) break;
            }
            if (i < list.Count)
            {

                Console.WriteLine("{0,-11}{1,-7}{2,-7}{3,-7}{4,-17}{5,-14}{6,-6},{7,-7},{8,-6}{9,-8}{10,-15}{11,-20}", "Thời gian",
                   "Mã hộ", "Mã công tơ", "Mã hóa đơn", "Tên chủ hộ", "Loại công tơ", "Ngày", "Tháng", "Năm", "Chỉ số", "Tổng tiền", "Tình trạng");
                Console.Write("{0:d}", list[i].Ngaythang);
                Console.Write("{0,-7}{1,-7}{2,-7}{3,-17}{4,-14}{5,-6},{6,-7},{7,-6}{8,-8}{9,-15}{10,-20}",
                   list[i].Maho, list[i].Mact, list[i].Mahd, list[i].Tench, list[i].Loaict, list[i].Ngay, list[i].Thang, list[i].Nam, list[i].Chiso, Hd.Tiendien(list[i]), list[i].Tinhtrang);
                Console.WriteLine("Nhấn enter để tiếp tục....");
            }
            else
            {
                Console.SetCursorPosition(13, 8); Console.Write("----------------> Không Tồn Tại Mã Hóa Đơn Nay.....<----------------");
                Console.ReadKey();
            }
        }
        public void MenuHD()
        {
            do
            {
                Console.Clear();
                Console.SetCursorPosition(20, 5);  Console.WriteLine("\t\t\t╔══════════════════════════════════════════════════════════════╗");
                Console.SetCursorPosition(20, 6);  Console.WriteLine("\t\t\t║                                                              ║");
                Console.SetCursorPosition(20, 7);  Console.WriteLine("\t\t\t║                      HÓA ĐƠN TIỀN ĐIỆN                       ║");
                Console.SetCursorPosition(20, 8);  Console.WriteLine("\t\t\t║                                                              ║");
                Console.SetCursorPosition(20, 9);  Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 10); Console.WriteLine("\t\t\t║               1.Thêm Thông Tin Hóa Đơn                       ║");
                Console.SetCursorPosition(20, 11); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 12); Console.WriteLine("\t\t\t║               2.Xoá Thông Tin Hóa Đơn                        ║");
                Console.SetCursorPosition(20, 13); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 14); Console.WriteLine("\t\t\t║               3.Sửa Thông Tin Hóa Đơn                        ║");
                Console.SetCursorPosition(20, 15); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 16); Console.WriteLine("\t\t\t║               4.Tìm Kiếm Thông Tin Hóa Đơn                   ║");
                Console.SetCursorPosition(20, 17); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 18); Console.WriteLine("\t\t\t║               5.Hiển Thị Thông Tin Hóa Đơn                   ║");
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
                        Search();
                        Console.ReadKey();
                        break;
                    case '5':
                        Display();
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
