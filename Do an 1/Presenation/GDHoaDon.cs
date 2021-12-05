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
        private IHogiadinhBLL Ho = new HogiadinhBLL();
        public void Input()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                          Thêm Thông Tin Hóa Đơn                           ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════╝");
            Hoadon hd = new Hoadon();
            Console.SetCursorPosition(20, 8); Console.Write("Thời gian in hóa đơn:  ");
            hd.Ngaythang = DateTime.Parse(Console.ReadLine());
            while (true)
            {
                Console.SetCursorPosition(20, 9); Console.Write("Mã hộ gia đình: ");
                hd.Maho = Console.ReadLine();
                try
                {
                    Hogiadinh h = Ho.GetHogiadinh(hd.Maho);
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (true)
            {
                Console.SetCursorPosition(20, 10); Console.Write("Mã hóa đơn: ");
                hd.Mahd = Console.ReadLine();
                if (hd.Mahd.Length == 5 && !Hd.ExitMHD(hd.Mahd)) break;
                else
                    Console.WriteLine("Nhập lại mã hóa đơn!");
            }
           
            hd.Tinhtrang = "Chua Nop";
            hd.Tt = Hd.Tongtien(hd.Maho,hd.Ngaythang); 
            Hd.Themhoadon(hd);
        }
        public void Display()
        {
            Console.Clear();
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                                 Hiện Thị Danh Sách Hóa Đơn                                ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Hoadon> list = Hd.GetAllHoadon();
            Console.WriteLine("{0,-8}{1,-15}{2,-15}{3,-18}{4,-15}{5,-12}{6,-12}", "Mã hộ", "Thời gian", "Mã hóa đơn", "Tên chủ hộ","Số thẻ","Tổng tiền","Tình trạng");
            Hogiadinh h;
            foreach (var hd in list)
            {
                h = Ho.GetHogiadinh(hd.Maho);
                Console.Write("{0,-8}", hd.Maho);
                Console.Write("{0:d}{1,-2}", hd.Ngaythang,"\t");
                Console.Write("{0,-13}{1,-18}{2,-15}{3,-12}{4,-12}",
                   hd.Mahd ,h.Tench, h.Sothe,hd.Tt,hd.Tinhtrang);
                Console.WriteLine("Nhấn enter để tiếp tục..");
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
            Console.SetCursorPosition(10, 5);  Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(10, 6);  Console.WriteLine("║                                           Hóa Đơn Của Hộ Gia Đình                                     ║");
            Console.SetCursorPosition(10, 7);  Console.WriteLine("╠═══════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.SetCursorPosition(10, 8);  Console.WriteLine("║Bạn muốn in hóa đơn hộ gia đình:                                        Tháng:        Năm:             ║");
            Console.SetCursorPosition(10, 9);  Console.WriteLine("╠═══════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.SetCursorPosition(10, 10); Console.WriteLine("║   Thời gian:                                                           Mã hóa đơn:                    ║");
            Console.SetCursorPosition(10, 11); Console.WriteLine("║                                                                                                       ║");
            Console.SetCursorPosition(10, 12); Console.WriteLine("║    Mã hộ:                      Tên chủ hộ:                             Địa chỉ:                       ║");
            Console.SetCursorPosition(10, 13); Console.WriteLine("║                                                                                                       ║");
            Console.SetCursorPosition(10, 14); Console.WriteLine("║    Năm sinh:                   Giới tính:                                                             ║");
            Console.SetCursorPosition(10, 15); Console.WriteLine("║                                                                                                       ║");
            Console.SetCursorPosition(10, 16); Console.WriteLine("║    Số điện thoại:                                                      Số thẻ:                        ║");
            Console.SetCursorPosition(10, 17); Console.WriteLine("║                                                                                                       ║");
            Console.SetCursorPosition(10, 18); Console.WriteLine("║-------------------------------------------------------------------------------------------------------║");
            Console.SetCursorPosition(10, 19); Console.WriteLine("║                                                                                                       ║");
            Console.SetCursorPosition(10, 20); Console.WriteLine("║     Tổng tiền:                                                         Tình trạng:                    ║");
            Console.SetCursorPosition(10, 21); Console.WriteLine("║                                                                                                       ║");
            Console.SetCursorPosition(10, 22); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Hoadon hd = new Hoadon();
            int thang, nam;
            Console.SetCursorPosition(45, 8);  hd.Maho = Console.ReadLine();
            Console.SetCursorPosition(90, 8);  thang = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(102, 8); nam = int.Parse(Console.ReadLine());
            hd = Hd.GetHoaDon(hd.Maho, new DateTime(nam, thang, 1));
            Hd.Suatinhtrang(hd,thang,nam);
            Hogiadinh h;       
            if (Hd.TimHoadon(hd).Count > 0)
            {
                foreach (var a in Hd.TimHoadon(hd))
                {
                    h = Ho.GetHogiadinh(hd.Maho); 
                    a.Tinhtrang = "Da Nop";
                    Console.SetCursorPosition(25, 10); Console.WriteLine("{0:d}",a.Ngaythang);
                    Console.SetCursorPosition(97, 10); Console.WriteLine(a.Mahd);
                    Console.SetCursorPosition(22, 12); Console.WriteLine(a.Maho);
                    Console.SetCursorPosition(55, 12); Console.WriteLine(h.Tench);
                    Console.SetCursorPosition(93, 12); Console.WriteLine(h.Diachi);
                    Console.SetCursorPosition(27, 14); Console.WriteLine("{0:d}",h.Ngaysinh);
                    Console.SetCursorPosition(54, 14); Console.WriteLine(h.Gioitinh);
                    Console.SetCursorPosition(30, 16); Console.WriteLine(h.Sdt);
                    Console.SetCursorPosition(91, 16); Console.WriteLine(h.Sothe);
                    Console.SetCursorPosition(28, 20); Console.WriteLine(a.Tt+ "(VND)");
                    Console.SetCursorPosition(95, 20); Console.WriteLine(a.Tinhtrang);
                }
              
            }
            else
            {
                Console.SetCursorPosition(40, 21); Console.WriteLine("-----> Không tồn tại hộ gia đình đó! <------");
            }
        }
        public void Thongked()
        {
            Console.Clear();
            int i ;
            List<Hoadon> list = Hd.GetAllHoadon();
            Console.SetCursorPosition(20, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(20, 6); Console.WriteLine("║                             Thống Kê Những Hộ Chưa Đóng Tiền                              ║");
            Console.SetCursorPosition(20, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.SetCursorPosition(0, 9); Console.WriteLine("{0,-8}{1,-15}{2,-15}{3,-18}{4,-15}{5,-12}{6,-12}", "Mã hộ", "Thời gian", "Mã hóa đơn", "Tên chủ hộ", "Số thẻ", "Tổng tiền", "Tình trạng");
            Hogiadinh h;
            for (i = 0; i < list.Count; i++)
            {
                if (list[i].Tinhtrang == "Da Nop")
                {
                    h = Ho.GetHogiadinh(list[i].Maho);
                    Console.Write("{0,-8}", list[i].Maho);
                    Console.Write("{0:d}{1,-2}", list[i].Ngaythang, "\t");
                    Console.Write("{0,-13}{1,-18}{2,-15}{3,-12}{4,-12}",
                       list[i].Mahd, list[i].Tench, list[i].Sothe, list[i].Tt, list[i].Tinhtrang);
                    Console.WriteLine("Nhấn enter để tiếp tục..");
                }
            }
        }
        public void Thongkec()
        {
            Console.Clear();
            int i;
            List<Hoadon> list = Hd.GetAllHoadon();
            Console.SetCursorPosition(20, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(20, 6); Console.WriteLine("║                             Thống Kê Những Hộ Chưa Đóng Tiền                              ║");
            Console.SetCursorPosition(20, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.SetCursorPosition(0, 9); Console.WriteLine("{0,-8}{1,-15}{2,-15}{3,-18}{4,-15}{5,-12}{6,-12}", "Mã hộ", "Thời gian", "Mã hóa đơn", "Tên chủ hộ", "Số thẻ", "Tổng tiền", "Tình trạng");
            Hogiadinh h;
            for (i = 0; i < list.Count; i++)
            {
                if (list[i].Tinhtrang == "Chua Nop")
                {
                    h = Ho.GetHogiadinh(list[i].Maho);
                    Console.Write("{0,-8}", list[i].Maho);
                    Console.Write("{0:d}{1,-2}", list[i].Ngaythang, "\t");
                    Console.Write("{0,-13}{1,-18}{2,-15}{3,-12}{4,-12}",
                       list[i].Mahd, list[i].Tench, list[i].Sothe, list[i].Tt, list[i].Tinhtrang);
                    Console.WriteLine("Nhấn enter để tiếp tục..");
                }
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
                Console.SetCursorPosition(20, 14); Console.WriteLine("\t\t\t║               3.Hiển Thị Danh Sách Hóa Đơn                   ║");
                Console.SetCursorPosition(20, 15); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 16); Console.WriteLine("\t\t\t║               4.Hiển Thị Hóa Đơn Của Hộ Gia Đình             ║");
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
                        Delete();
                        Display();
                        Console.ReadKey();
                        break;
                    case '3':
                        Display();
                        Console.ReadKey();
                        break;
                    case '4':
                        Search();
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
