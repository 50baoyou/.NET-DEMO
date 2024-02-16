using System;

namespace HelloWorld
{
    internal class Program
    {
        static void RedEyesRemovalFilter(Photo photo)
        {
            Console.WriteLine("去除红眼");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // -- 委托 --
            var photo = Photo.load("photo.jpg");
            var filters = new PhotoFilters();

            //PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            Action<Photo> filterHandler = filters.ApplyBrightness;
            // 多播委托
            filterHandler += filters.ApplyContrast;
            filterHandler += filters.Resize;
            filterHandler += RedEyesRemovalFilter;

            var processor = new PhotoProcessor();
            processor.Process(photo, filterHandler);
        }
    }
}
