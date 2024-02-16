using System.Windows;

namespace Tree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // sender：触发事件的对象，e：路由事件参数
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"按钮：{sender} 被点击了");
        }
    }
}
