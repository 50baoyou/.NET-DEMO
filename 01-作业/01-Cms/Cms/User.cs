using System;

namespace Cms
{
    internal class User
    {
        private bool _isUserLogin;

        public bool IsUserLogin { get { return _isUserLogin; } }

        public void Login()
        {
            string username;
            string password;

            username = Program.CmdReader("用户名: ");
            if (username != "alex")
            {
                Console.WriteLine("查无此人");
                return;
            }

            password = Program.CmdReader("密码: ");
            if (password != "123456")
            {
                Console.WriteLine("密码错误， 请重试。");
                return;
            }

            _isUserLogin = true;
        }
    }
}
