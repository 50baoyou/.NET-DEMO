using System;

namespace HelloWorld
{
    internal class MailService : INotfication
    {
        public void Send(string message)
        {
            Console.WriteLine($"发送email: {message}");
        }
    }
}
