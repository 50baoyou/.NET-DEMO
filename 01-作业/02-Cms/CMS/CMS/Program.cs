using Microsoft.Extensions.DependencyInjection;
using System;

namespace CMS
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
            Console.WriteLine("Hello World!");

            ServiceCollection services = new ServiceCollection();

            services.AddScoped<IUser, User>();
            services.AddScoped<IMenu, Menu>();
            services.AddScoped<ICMSController, CMSController>();

            var serviceProvider = services.BuildServiceProvider();

            var cmsController = serviceProvider.GetService<ICMSController>();

            cmsController.Start();
        }
    }
}
