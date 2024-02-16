using System;

namespace HelloWorld
{
    internal class SmsMessageService : INotfication
    {
        public void Send(string message)
        {
            Console.WriteLine($"发送短信: {message}");
        }
    }
}
