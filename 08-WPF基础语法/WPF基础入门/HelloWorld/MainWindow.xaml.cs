using System.Windows;
using System.Windows.Controls;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    // partial：局部类型
    // 允许将一个类、结构或接口分成几个部分，分别实现在几个不同的.cs文件中
    // C# 编译器在编译的时候仍会将各个部分的局部类型合并成一个完整的类
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // 初始化组件
            InitializeComponent();

            // 获取 Grid 对象
            // var grid1 = this.Content as Grid;转换失败时为 null
            // var grid2 = (Grid)this.Content; 转换失败时会抛出异常
            if (this.Content is not Grid grid) // null 检查：模式匹配语法
            {
                // is 语法会进行类型转换并赋值
                grid = new Grid();
                this.AddChild(grid);
            }

            // 创建 Button 组件
            Button button = new()
            {
                Height = 50,
                Width = 100,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Content = "点击"
            };

            // 添加组件
            grid.Children.Add(button);
        }
    }
}
