using System;

namespace HelloWorld
{
    public class Photo
    {
        public static Photo load(string path)
        {
            return new Photo();
        }

        public void Save()
        {
            Console.WriteLine("已保存");
        }
    }
}
