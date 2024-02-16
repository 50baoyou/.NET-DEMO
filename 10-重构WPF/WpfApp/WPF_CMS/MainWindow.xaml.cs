using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_CMS.ViewModel;

namespace WPF_CMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _mainViewModel;

        public MainWindow()
        {
            InitializeComponent();

            _mainViewModel = new();
            _mainViewModel.LoadCustomers();

            DataContext = _mainViewModel;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("确定退出吗？"
                , "询问"
                , MessageBoxButton.YesNo
                , MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void ClearSelectedCustomerClickHandler(object sender, RoutedEventArgs e)
        {
            _mainViewModel.ClearSelectedCustomer();

            // 清空选中
            CustomerListBox.SelectedItem = null;
        }

        private void SaveSelectedCustomerClickHandler(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text)
                || string.IsNullOrWhiteSpace(IdNumberTextBox.Text)
                || string.IsNullOrWhiteSpace(AddressTextBox.Text))
            {
                return;
            }

            // 使用 Trim() 移除字符串的开始和结尾处的所有空白字符
            string name = NameTextBox.Text.Trim();
            string idNumber = IdNumberTextBox.Text.Trim();
            string address = AddressTextBox.Text.Trim();

            _mainViewModel.SaveCustomer(name, idNumber, address);

            // 清空输入框
            NameTextBox.Clear();
            IdNumberTextBox.Clear();
            AddressTextBox.Clear();
        }

        private void AddAppointmentClickHandler(object sender, RoutedEventArgs e)
        {
            if (AppointmentCalendar.SelectedDate is null)
            {
                return;
            }

            var selectedDate = AppointmentCalendar.SelectedDate.Value;
            _mainViewModel.AddAppointment(selectedDate);
        }

        private void CustomerSelectionChangedHandler(object sender, SelectionChangedEventArgs e)
        {
            if (AppointmentCalendar.SelectedDate is not null)
            {
                AppointmentCalendar.SelectedDate = null;
            }
        }

        private void AppointmentCalendarSelectedDatesChangedHandler(object sender, SelectionChangedEventArgs e)
        {
            // 若要释放鼠标捕获，请调用 Capture 传递 null 作为要捕获的元素。
            Mouse.Capture(null);
        }
    }
}