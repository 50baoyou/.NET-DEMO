using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PropertyChanged
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Sum Sum { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Sum = new Sum()
            {
                Num1 = "1",
                Num2 = "2"

            };
            // 数据上下文
            // 将窗口内的 UI 元素绑定到 Sum 类的属性，用于实现向数据绑定
            //DataContext = Sum;

            // 编程中上下文的概念 Context
            /** 
             * 在读小说时，人物的背景、故事发生的时间、地点等都是构成小说情境（上下文）的重要因素。
             * 这些信息帮助读者更好地理解故事中发生的事件，就像在编程中上下文提供了执行环境和相关信息一样。
             * 当我们了解了这些上下文信息，我们更容易理解故事中人物的行为，就如同在编程中理解上下文有助于理解程序的行为一样。
             **/
        }
    }
}
