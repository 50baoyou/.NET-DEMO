using System;
using System.Timers;

namespace Demo
{
    public class Robot
    {
        // 事件处理器
        public void AlarmEventHandler(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("闹钟响了，不管，继续睡");
        }
    }

    public class GoodMan
    {
        public int RageValue { get; set; }
        public void AlarmEventHandler(object sender, ElapsedEventArgs e)
        {
            RageValue += 1;

            if (RageValue >= 10)
            {
                Console.WriteLine("受不了，关闹钟");
                ((Timer)sender).Stop(); // 转换类型
            }
            else
            {
                Console.WriteLine("闹钟响了");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // 方块：方法  扳手：属性  闪电：事件

            // 事件响应者：robot
            var robot = new Robot();
            var man = new GoodMan();

            // 事件拥有者：alarm
            var alarm = new Timer(1000);
            alarm.Enabled = true;
            alarm.AutoReset = true;
            // 事件：alarm.Elapsed  事件订阅：+= 操作符
            alarm.Elapsed += robot.AlarmEventHandler; // 事件处理器
            alarm.Elapsed += man.AlarmEventHandler;
            alarm.Start();

            // 阻止程序停止
            Console.Read();
        }
    }
}
