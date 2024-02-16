using System;

namespace HelloWorld
{
    internal class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("亮度增加");
        }

        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("对比度增加");
        }

        public void Resize(Photo photo)
        {
            Console.WriteLine("图片放大");
        }
    }
}
