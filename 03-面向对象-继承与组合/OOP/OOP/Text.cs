using System;

namespace OOP
{
    class Text : PresemtationObject
    {
        public int FontSoze { get; set; }
        public string FontName { get; set; }
        public void AddHyperLink()
        {
            Console.WriteLine("添加超链接");
        }
    }
}
