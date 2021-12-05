using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_an_1.Presenation;

namespace Do_an_1
{
    public class Program
    {
        public static void MenuDemo()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║║-║-║-║-║--║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║--║-║-║-║-║");
            Console.WriteLine("\t\t║ ║- ╔══════════════════════════════════════════════════════════════════════════╗- ║ ║");
            Console.WriteLine("\t\t║- ║ ║                                                                          ║ ║ -║");
            Console.WriteLine("\t\t║ ║- ║               TRƯỜNG ĐẠI HỌC SƯ PHẠM KỸ THUẬT HƯNG YÊN                   ║- ║ ║");
            Console.WriteLine("\t\t║- ║ ║           _____________________________________________________          ║ ║ -║");
            Console.WriteLine("\t\t║- ║ ║                                                                          ║ ║ -║");
            Console.WriteLine("\t\t║ ║- ║  :::::::::   ::::::::              :::     ::::    :::            :::    ║- ║ ║");
            Console.WriteLine("\t\t║- ║ ║  :+:    :+: :+:    :+:           :+: :+:   :+:+:   :+:          :+:+:    ║ ║ -║");
            Console.WriteLine("\t\t║ ║- ║  +:+    +:+ +:+    +:+          +:+   +:+  :+:+:+  +:+            +:+    ║- ║ ║");
            Console.WriteLine("\t\t║- ║ ║  +#+    +:+ +#+    +:+         +#++:++#++: +#+ +:+ +#+            +#+    ║ ║ -║");
            Console.WriteLine("\t\t║ ║- ║  +#+    +#+ +#+    +#+         +#+     +#+ +#+  +#+#+#            +#+    ║- ║ ║");
            Console.WriteLine("\t\t║- ║ ║  #+#    #+# #+#    #+#         #+#     #+# #+#   #+#+#            #+#    ║ ║ -║");
            Console.WriteLine("\t\t║ ║- ║  #########   ########          ###     ### ###    ####          #######  ║- ║ ║");
            Console.WriteLine("\t\t║ ║- ║                                                                          ║- ║ ║");
            Console.WriteLine("\t\t║- ║ ║                                                                          ║ ║ -║");
            Console.WriteLine("\t\t║ ║- ║       ╔══════════════════════════════════════════════════════════╗       ║- ║ ║");
            Console.WriteLine("\t\t║- ║ ║       ║          CHƯƠNG TRÌNH QUẢN LÍ CÁC HỘ TIÊU THỤ ĐIỆN       ║       ║ ║- ║");
            Console.WriteLine("\t\t║ ║- ║       ╠══════════════════════╦═══════════════════════════════════╣       ║- ║ ║");
            Console.WriteLine("\t\t║- ║ ║       ║ Giảng Viên Hướng Dẫn ║         Chu Thị Minh Huệ          ║       ║ ║- ║");
            Console.WriteLine("\t\t║ ║- ║       ╠══════════════════════╬═══════════════════════════════════╣       ║- ║ ║");
            Console.WriteLine("\t\t║- ║ ║       ║ Sinh Viên Thực Hiện  ║         Phan Thị Minh Tâm         ║       ║ ║- ║");
            Console.WriteLine("\t\t║ ║- ║       ╠══════════════════════╬═══════════════════════════════════╣       ║- ║ ║");
            Console.WriteLine("\t\t║- ║ ║       ║ Mã Sinh Viên         ║         10120088                  ║       ║ ║- ║");
            Console.WriteLine("\t\t║ ║- ║       ╠══════════════════════╬═══════════════════════════════════╣       ║- ║ ║");
            Console.WriteLine("\t\t║- ║ ║       ║ Mã Lớp               ║         125202                    ║       ║ ║- ║");
            Console.WriteLine("\t\t║ ║- ║       ╚══════════════════════╩═══════════════════════════════════╝       ║- ║ ║");
            Console.WriteLine("\t\t║- ║ ║                       Nhấn phím Enter để tiếp tục                        ║ ║- ║");
            Console.WriteLine("\t\t║ ║- ╚══════════════════════════════════════════════════════════════════════════╝- ║ ║");
            Console.WriteLine("\t\t║║**║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║--║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║-║**║║");
            Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════════════════╝");
        }
        public static string ReadPassword()
        {
            string pass = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter) //không có dấu trống và không enter dừng 
                {
                    pass += key.KeyChar; //chuyển kí vừa nhập thành kiểu kí tự
                    Console.Write("*"); //ghi sao
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1)); //Cắt phần tử cuối cùng 
                        Console.Write("\b \b"); 
                        //đầu tiên di chuyển dấu nháy trở lại, sau đó viết một ký tự khoảng trắng ghi đè lên ký tự cuối cùng và di chuyển dấu nháy về phía trước một lần nữa
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            return pass;
        }
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(15, 8);  Console.WriteLine("\t\t\t╔══════════════════════════════════════════════════════════════╗");
                Console.SetCursorPosition(15, 9);  Console.WriteLine("\t\t\t║                            ĐĂNG NHẬP                         ║");
                Console.SetCursorPosition(15, 10); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(15, 11); Console.WriteLine("\t\t\t║              Tài Khoản(User) :                               ║");
                Console.SetCursorPosition(15, 12); Console.WriteLine("\t\t\t╠══════════════════════════════════════════════════════════════╣");
                Console.SetCursorPosition(15, 13); Console.WriteLine("\t\t\t║              Mật Khẩu(Password) :                            ║");
                Console.SetCursorPosition(15, 14); Console.WriteLine("\t\t\t╚══════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(65, 11); string TK = Console.ReadLine();
                Console.SetCursorPosition(68, 13); string MK = ReadPassword();

                if(TK.ToUpper()=="DLTD" && MK.ToUpper()=="TD@123")
                {
                    Console.SetCursorPosition(45, 15); Console.Write(">ĐĂNG NHẬP HỆ THỐNG THÀNH CÔNG<");
                    Console.ReadKey();
                    Console.Clear();
                    GiaoDien t = new GiaoDien();
                    t.Menu();
                }
                else
                {
                    Console.SetCursorPosition(45, 15); Console.Write(">ĐĂNG NHẬP HỆ THỐNG THẤT BẠI<");
                  
                    Console.ReadKey();
                }    
                
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.OutputEncoding = Encoding.UTF8;
            ConsoleKeyInfo k;
            do
            {
                MenuDemo();
                k = Console.ReadKey();
                if (k.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Start();
                }
            } while (true);
        }
    }
}
