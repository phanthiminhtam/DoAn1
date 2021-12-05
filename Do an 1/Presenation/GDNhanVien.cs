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
     public class GDNhanVien
     {
        private INhanvienBLL Nv = new NhanvienBLL();
        public void Input()
        {
            Console.Clear();
            Console.SetCursorPosition(25, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(25, 6); Console.WriteLine("║                          Thêm Thông Tin Nhân Viên                         ║");
            Console.SetCursorPosition(25, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════╝");
            Nhanvien nv = new Nhanvien();
            while (true)
            {
                Console.SetCursorPosition(27, 8); Console.Write("Mã nhân viên: ");
                nv.Manv= Console.ReadLine();
                if (nv.Manv.Length == 5 && !Nv.ExitMNV(nv.Manv))
                    break;
                else
                    Console.WriteLine("Nhập lại mã nhân viên!");
            }
            Console.SetCursorPosition(27, 9); Console.Write("Tên nhân viên: ");
            nv.Tennv = Console.ReadLine();
            do
            {
                Console.SetCursorPosition(27, 10); Console.Write("Giới tính : ");
                nv.Gioitinh = Console.ReadLine();
                if (nv.Gioitinh.ToUpper() != "NAM" && nv.Gioitinh.ToUpper() != "NU")
                {
                    Console.Write("Ban nhap sai moi nhap lai...");
                }
            } while (nv.Gioitinh.ToUpper() != "NAM" && nv.Gioitinh.ToUpper() != "NU");
            Console.SetCursorPosition(27, 11); Console.Write("Ngày sinh: ");
            nv.Ngaysinh = DateTime.Parse(Console.ReadLine());
            while (true)
            {
                Console.SetCursorPosition(27, 12); Console.Write("Số ngày làm việc: ");
                nv.Songaylv = int.Parse(Console.ReadLine());
                if (nv.Songaylv>=1 && nv.Songaylv<=31) break;
                else
                    Console.WriteLine("Nhập lai số ngày làm việc");
            }
            Console.SetCursorPosition(27, 13); Console.Write("Chức vụ: ");
            nv.Chucvu = Console.ReadLine();
            while(true)
            {
                Console.SetCursorPosition(27, 14); Console.Write("Số điện thoại: ");
                nv.Sdt = Console.ReadLine();
                if (nv.Sdt.Length == 10) break;
                else
                    Console.WriteLine("Nhập lại số điện thoại!");
            }
            Console.SetCursorPosition(27, 15); Console.Write("Hệ số lương: ");
            nv.Hsl = float.Parse(Console.ReadLine());
            Nv.Themnhanvien(nv);
        }
        public void Display()
        {
            Console.Clear();
            Console.Clear();
            Console.SetCursorPosition(13, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(13, 6); Console.WriteLine("║                                 Hiện Thông Tin Nhân Viên                                  ║");
            Console.SetCursorPosition(13, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Nhanvien> list = Nv.GetAllNhanvien();
            Console.WriteLine("{0,-8}{1,-20}{2,-12}{3,-16}{4,-16}{5,-13}{6,-14}{7,-14}{8,-20}",
                             "Mã NV", "Tên nhân viên", "Giới tính", "Ngày sinh", "Số điện thoại", "Số ngày lv", "Hệ số lương", "Tổng lương", "Chức vụ");
            foreach (var nv in list)
            {
                Console.Write("{0,-8}{1,-20}{2,-12}", nv.Manv, nv.Tennv, nv.Gioitinh);
                Console.Write("{0:d}", nv.Ngaysinh);
                Console.Write("{0,-1}{1,-16}{2,-14}{3,-14}{4,-14}{5,-20}", '\t',nv.Sdt, nv.Songaylv,nv.Hsl,nv.Tongluong, nv.Chucvu);
                Console.WriteLine("Nhấn enter để tiếp tục..");
            }
        }
        public void Correct()
        {
            Console.Clear();
            Console.SetCursorPosition(13, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(13, 6); Console.WriteLine("║                                  Sửa Thông Tin Nhân Viên                                  ║");
            Console.SetCursorPosition(13, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Nhanvien> list = Nv.GetAllNhanvien();
            string Masua;
            Console.Write("Nhập mã nhân viên cần sửa: ");
            Masua = Console.ReadLine();
            int i;
            for (i = 0; i < list.Count; i++)
            {
                if (list[i].Manv == Masua) break;
            }
            if (i < list.Count)
            {
                Nhanvien nv = new Nhanvien(list[i]);
                Console.SetCursorPosition(14, 8); Console.Write("Tên nhân viên mới: ");
                string ten = Console.ReadLine();
                if (!string.IsNullOrEmpty(ten) && ten != nv.Tennv) nv.Tennv = ten;
                Console.SetCursorPosition(14, 9); Console.Write("Giới tính : ");
                string gt = Console.ReadLine();
                if(gt != nv.Gioitinh) nv.Gioitinh = gt;
                Console.SetCursorPosition(14, 10); Console.Write("Ngày sinh: ");
                DateTime ns = DateTime.Parse(Console.ReadLine()); nv.Ngaysinh = ns;
                Console.SetCursorPosition(14, 11); Console.Write("Số ngành làm việc: ");
                int snlv = int.Parse(Console.ReadLine()); 
                if(snlv!= nv.Songaylv && snlv !=0)  nv.Songaylv = snlv;
                Console.SetCursorPosition(14, 12); Console.Write("Chức vụ: ");
                string cv= Console.ReadLine(); 
                if(cv!= nv.Chucvu && cv != null)  nv.Chucvu = cv ;
                Nv.Suanhanvien(nv);
            }
            else
            {
                Console.SetCursorPosition(13, 8); Console.Write("----------> Không tồn tại mã nhân viên này! <----------");
                Console.ReadKey();
            }
        }
        public void Delete()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                                  Xóa Thông Tin Hóa Đơn                                    ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            List<Nhanvien> list = Nv.GetAllNhanvien();
            string Maxoa;
            Console.Write("Nhập mã nhân viên cần xóa: ");
            Maxoa = Console.ReadLine();
            int i;
            for (i = 0; i < list.Count; i++)
            {
                if (list[i].Manv == Maxoa) break;
            }
            if (i < list.Count)
            {
                Console.SetCursorPosition(15, 8); Console.Write("--------------> Xóa Thành Công! <----------------");
                Nv.Xoanhanvien(Maxoa);
                Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(15, 8); Console.Write("----------------> Không Tồn Tại Mã Nhân Viên Nay..... <----------------");
                Console.ReadKey();
            }
        }
        public void Search()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 5); Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(15, 6); Console.WriteLine("║                             Tìm kiếm Thông Tin Hộ Gia đình                                ║");
            Console.SetCursorPosition(15, 7); Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");
            Nhanvien nv = new Nhanvien();
            char c;
            while (true)
            {
                Console.SetCursorPosition(15, 8); Console.Write("\nTìm mã_M,Tìm tên nhân viên_T,Tìm giới tính_G: ");
                try
                {
                    c = Char.ToUpper(char.Parse(Console.ReadLine()));
                    if (c == 'M' || c == 'T' || c == 'G')
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
                    Console.SetCursorPosition(12, 11); Console.Write("----> Mời nhập mã nhân viên muốn tìm: ");
                    nv.Manv = Console.ReadLine();
                    break;
                case 'T':
                    Console.SetCursorPosition(12, 11); Console.Write("---------> Mời nhập tên nhân viên muốn tìm: ");
                    nv.Tennv = Console.ReadLine();
                    break;
                case 'G':
                    Console.SetCursorPosition(12, 11); Console.Write("---------> Mời nhập giới tính muốn tìm: ");
                    nv.Gioitinh = Console.ReadLine();
                    break;
            }
            if (Nv.TimNhanvien(nv).Count > 0)
            {
                Console.WriteLine("{0,-8}{1,-20}{2,-12}{3,-16}{4,-16}{5,-13}{6,-14}{7,-14}{8,-20}",
                           "Mã NV", "Tên nhân viên", "Giới tính", "Ngày sinh", "Số điện thoại", "Số ngày lv", "Hệ số lương", "Tổng lương", "Chức vụ");
                foreach (var a in Nv.TimNhanvien(nv))
                {
                    Console.Write("{0,-8}{1,-20}{2,-12}", a.Manv, a.Tennv, a.Gioitinh);
                    Console.Write("{0:d}", a.Ngaysinh);
                    Console.Write("{0,-1}{1,-16}{2,-14}{3,-14}{4,-14}{5,-20}", '\t', a.Sdt, a.Songaylv, a.Hsl, a.Tongluong, a.Chucvu);
                    Console.WriteLine("Nhấn enter để tiếp tục..");
                }
            }
            else
            {
                Console.WriteLine("Không tồn tại thông tin đó!");
            }
        }
        public void MenuNV()
        {
            do
            {
                Console.Clear();
                Console.SetCursorPosition(20, 5);  Console.WriteLine("\t\t\t╔══════════════════════════════════════════════════════════════╗");
                Console.SetCursorPosition(20, 6);  Console.WriteLine("\t\t\t║                                                              ║");
                Console.SetCursorPosition(20, 7);  Console.WriteLine("\t\t\t║                   MENU QUẢN LÝ NHÂN VIÊN                     ║");
                Console.SetCursorPosition(20, 8);  Console.WriteLine("\t\t\t║                                                              ║");
                Console.SetCursorPosition(20, 9);  Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 10); Console.WriteLine("\t\t\t║               1.Thêm Thông Tin Nhân Viên                     ║");
                Console.SetCursorPosition(20, 11); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 12); Console.WriteLine("\t\t\t║               2.Sửa Thông Tin Nhân Viên                      ║");
                Console.SetCursorPosition(20, 13); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 14); Console.WriteLine("\t\t\t║               3.Xóa Thông Tin Nhân Viên                      ║");
                Console.SetCursorPosition(20, 15); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 16); Console.WriteLine("\t\t\t║               4.Hiển Thị Thông Tin Nhân Viên                 ║");
                Console.SetCursorPosition(20, 17); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 18); Console.WriteLine("\t\t\t║               5.Tìm kiếm Thông Tin Nhân Viên                 ║");
                Console.SetCursorPosition(20, 19); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(20, 20); Console.WriteLine("\t\t\t║               6.Quay Lại Màn Hình Chính                      ║");
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
