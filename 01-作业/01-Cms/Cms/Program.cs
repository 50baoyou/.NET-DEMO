using System;

namespace Cms
{
    internal class Program
    {
        public static string CmdReader(string instruction)
        {
            Console.Write(instruction);
            string cmd = Console.ReadLine();
            return cmd;
        }
        static void Main(string[] args)
        {
            // 初始化用户系统
            User user = new();
            // 初始化菜单系统
            Menu menu = new();
            // 初始化控制系统
            CMSController controller = new();

            // 启动程序
            controller.Start(user, menu);
        }
    }
}
