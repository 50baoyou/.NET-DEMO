using Computer.SDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Loader;

namespace Computer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUSB ssd = new SSD.SSD();
            ssd.GetInfo();

            Console.WriteLine("Hello World!");

            // 获取 USB 文件夹的访问路径
            var USBInterface = Path.Combine(Environment.CurrentDirectory, "USB");
            // 读取 DLL 文件
            var dllFiles = Directory.GetFiles(USBInterface);
            // 创建 USB 设备列表
            // 因为要遵循Computer中IUSB协议，所以设备列表类型为IUSB
            var deviceLis = new List<IUSB>();

            // 读取 USB 设备
            foreach (var dll in dllFiles)
            {
                // 加载 DLL 程序
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dll);
                // 读取设备类型
                var typeList = assembly.GetTypes();

                foreach (var type in typeList)
                {
                    // 获取所有接口列表
                    var interfaceList = type.GetInterfaces();

                    foreach (var item in interfaceList)
                    {
                        // 判断是否为 USB 设备
                        if (item.Name == "IUSB")
                        {
                            var usb = (IUSB)Activator.CreateInstance(type);
                            deviceLis.Add(usb);
                        }
                    }
                }
            }

            // 输出 USB 设备列表
            foreach (var usb in deviceLis)
            {
                usb.GetInfo();
                usb.Read();
                usb.Write();
            }
        }
    }
}
