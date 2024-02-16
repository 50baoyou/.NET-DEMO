using System;

namespace HelloWorld
{
    // 委托 --> 解耦，delegate：委托类
    //public delegate void PhotoFilterHandler(Photo photo);

    // 预定义委托方法

    public class PhotoProcessor
    {
        public void Process(Photo photo, Action<Photo> filterHandler)
        {
            filterHandler(photo);

            photo.Save();
        }
    }
}
