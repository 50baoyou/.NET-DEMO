using System;

namespace Cms
{
    internal class Menu
    {
        public void ShowMenu()
        {
            bool isExit = false;
            while (!isExit)
            {
                string selection = Program.CmdReader("主菜单\n1.客户管理\n2.预约管理\n3.系统设置\n4.退出\n请选择: ");
                switch (selection)
                {
                    case "1":
                        Console.WriteLine("客户管理");
                        break;
                    case "2":
                        Console.WriteLine("预约管理");
                        break;
                    case "3":
                        Console.WriteLine("系统设置");
                        break;
                    case "4":
                    default:
                        Console.WriteLine("退出");
                        isExit = true;
                        break;
                }
            }
        }
    }
}
