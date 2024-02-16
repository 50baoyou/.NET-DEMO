using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 初始化订单
            var order = new Order()
            {
                Id = 123,
                DatePlaced = DateTime.Now,
                TotalPrice = 20f,
                IsShipped = false,
                Shipment = null
            };

            // 初始化运费计算器
            //var shippingCalculator = new DobleElevenShippingCalculator();

            // 初始化运费处理器
            //var processor = new OrderProcessor(shippingCalculator);
            //processor.Process(order);

            Console.WriteLine("Hello World!");

            // 配置 IOC（控制反转） 容器
            ServiceCollection services = new ServiceCollection();

            // 添加服务（三种方式）
            /*
             * singleton  -- 单例模式
             * scoped     -- 作用域模式
             * tansient   -- 瞬时模式
             */

            // singleton  -- 单例模式
            //services.AddSingleton<IOrderProcessor, OrderProcessor>();
            //services.AddSingleton<IShippingCalculator, DobleElevenShippingCalculator>();

            // scoped     -- 作用域模式（例：每个 http 请求可看作单独的作用域，每次 http 请求创建一次）
            services.AddScoped<IOrderProcessor, OrderProcessor>();
            services.AddScoped<IShippingController, ShippingController>();
            services.AddScoped<IShippingCalculator, ShippingCalculator>();
            services.AddScoped<IShippingCalculator, DobleElevenShippingCalculator>();

            // tansient   -- 瞬时模式
            //services.AddTransient<IOrderProcessor, OrderProcessor>();
            //services.AddTransient<IShippingCalculator, DobleElevenShippingCalculator>();

            // 从 IOC 中提取服务
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var orderProcessor = serviceProvider.GetService<IOrderProcessor>();

            // 处理订单（耦合程度：从“依赖”转为“引用”）
            orderProcessor.Process(order);

            IEnumerable<IShippingCalculator> shippingCalculators = serviceProvider.GetServices<IShippingCalculator>();

            Console.WriteLine(shippingCalculators.ToArray()[1]);
        }
    }
}
