using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_CMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Demo"].ConnectionString;
        //private SqlConnection? _connection;

        public MainWindow()
        {
            InitializeComponent();

            // using 关键字用于处理 IDisposable 接口，它确保在使用完对象后释放其资源。
            // 在 using 声明中进行声明时，局部变量在声明它的作用域末尾释放。
            // IDisposable 接口是指一个对象提供了一个Dispose方法，该方法可以用于释放该对象使用的资源。

            //_connection = new(ConnectionString);
            ShowCustomers();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("确定退出吗？", "询问", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        //protected override void OnClosed(EventArgs e)
        //{
        //    base.OnClosed(e);
        //    // 空值条件运算符 ?. ，当左侧不为 null 时，调用方法。
        //    _connection?.Close(); // 关闭连接
        //    _connection?.Dispose(); // （类似析构方法）注销对象非托管类型的资源
        //    _connection = null;
        //    //MessageBox.Show((_connection == null).ToString());
        //}

        //private void CheckConnection()
        //{
        //    if (_connection == null)
        //    {
        //        _connection = new(ConnectionString);
        //    }

        //    if (_connection.State != ConnectionState.Open)
        //    {
        //        _connection.Close();
        //        _connection.Open();
        //    }
        //}

        private void ShowCustomers()
        {
            /**
             * SqlCommand 是用于执行单个 SQL 命令的。
             * 通常用于执行 INSERT、UPDATE、DELETE 等操作，或者用于检索单行数据。
             * 使用 SqlCommand 时，需要手动打开数据库连接，执行命令，然后关闭连接。
             */
            //using SqlCommand command = connection.CreateCommand();

            /**
             * SqlDataAdapter 是用于填充 DataSet 对象并与数据库进行同步操作的。
             * 它提供了一个桥接器，可以在 DataSet 对象与数据库之间进行数据同步。
             * 当需要执行多个查询并将结果填充到 DataSet 中时，可以使用 SqlDataAdapter。
             * 它会自动打开数据库连接，执行查询并将结果填充到 DataSet 中的 DataTable 中，然后自动关闭连接。
             */
            //using SqlDataAdapter adapter = new();

            /**
             * .NET 中用于处理 SQL 数据库的两种不同的数据读取器
             * SqlDataReader 是一个用于读取从数据库查询结果返回的数据的类。
             * SqlDataAdapter 是一个更加灵活的类，它提供了一个桥接器，可以将 DataSet 对象与数据库的查询结果集进行同步。
             * 
             * 区别：
             * 只需要快速读取查询结果集中的数据，可以使用 SqlDataReader。
             * 如果需要将查询结果集缓存到内存中，并且可以在需要时更新数据库中的数据，那么应该使用 SqlDataAdapter。
             */

            /**
             * DataSet 是一个内存中的数据库，可以用于存储来自数据库的查询结果。
             * 它是一个类似 DataTable 的对象集合，可以包含多个 DataTable 对象，每个 DataTable 对象代表一个数据表。
             */
            // DataSet dataSet = new DataSet("AppDataSet"); // 指定 DataSet 的名称
            // DataTable dataTable = dataSet.Tables.Add("Customers");

            using SqlConnection connection = new(ConnectionString);
            try
            {
                //CheckConnection();
                string sql = "SELECT * FROM Customer";

                using DataTable customerTable = new();
                using SqlDataAdapter adapter = new();

                connection.Open();
                adapter.SelectCommand = new SqlCommand(sql, connection);
                adapter.Fill(customerTable);

                //customerList.DisplayMemberPath = "Name";
                //customerList.SelectedValuePath = "Id";
                customerList.ItemsSource = customerTable.DefaultView;
            }
            catch (Exception error)
            {
                MessageBox.Show("异常：" + error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void CustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (_connection == null)
            //{
            //    _connection = new(ConnectionString);
            //}
            // _connection ??= new(ConnectionString) 复合分配：当连接为空时新建连接
            if (customerList.SelectedValue == null) { return; }

            DataRowView? selectItem = customerList.SelectedItem as DataRowView;
            NameTextBox.Text = selectItem?["Name"] as string;
            IDTextBox.Text = selectItem?["IdNumber"] as string;
            AddressTextBox.Text = selectItem?["Address"] as string;

            using SqlConnection connection = new(ConnectionString);
            try
            {
                //CheckConnection();
                string sql = @"SELECT * FROM Appointments 
                                JOIN Customer 
                                ON Appointments.CustomerId = Customer.Id 
                                WHERE Customer.Id = @CustomerId";
                var CustomerId = customerList.SelectedValue;

                using DataTable appointmentTable = new();
                using SqlDataAdapter adapter = new();

                connection.Open();
                adapter.SelectCommand = new(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@CustomerId", CustomerId);
                adapter.Fill(appointmentTable);

                appointmentList.ItemsSource = appointmentTable.DefaultView;
            }
            catch (Exception error)
            {
                MessageBox.Show("异常：" + error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Remove_Appointment_Click(object sender, RoutedEventArgs e)
        {
            if (appointmentList.SelectedValue == null) { return; }

            using SqlConnection connection = new(ConnectionString);
            try
            {
                //CheckConnection();
                string sql = "DELETE FROM Appointments WHERE Id = @AppointmentId";
                var appointmentId = appointmentList.SelectedValue;

                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                connection.Open();
                command.ExecuteNonQuery();

                CustomerList_SelectionChanged(null, null);
            }
            catch (Exception error)
            {
                MessageBox.Show("异常：" + error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Remove_Customer_Click(object sender, RoutedEventArgs e)
        {
            if (customerList.SelectedValue == null) { return; }

            using SqlConnection connection = new(ConnectionString);
            try
            {
                //CheckConnection();
                connection.Open();

                string removeAppointmentSql = @"DELETE FROM Appointments 
                                        WHERE CustomerId = @CustomerId";
                string removeCustomerSql = @"DELETE FROM Customer
                                        WHERE Id = @CustomerId";
                var CustomerId = customerList.SelectedValue;


                using SqlCommand command1 = new(removeAppointmentSql, connection);
                using SqlCommand command2 = new(removeCustomerSql, connection);
                command1.Parameters.AddWithValue("@CustomerId", CustomerId);
                command2.Parameters.AddWithValue("@CustomerId", CustomerId);

                connection.Open();
                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();

                ShowCustomers();
                CustomerList_SelectionChanged(null, null);
            }
            catch (Exception error)
            {
                MessageBox.Show("异常：" + error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Add_Customer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.ToString()) || string.IsNullOrEmpty(IDTextBox.ToString()) || string.IsNullOrEmpty(AddressTextBox.ToString())) { return; }

            using SqlConnection connection = new(ConnectionString);
            try
            {
                string sql = "INSERT INTO Customer VALUES (@name, @idnumber, @address)";
                var name = NameTextBox.Text;
                var idnumber = IDTextBox.Text;
                var address = AddressTextBox.Text;

                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@idnumber", idnumber);
                command.Parameters.AddWithValue("@address", address);

                connection.Open();
                command.ExecuteNonQuery();

                ShowCustomers();
            }
            catch (Exception error)
            {
                MessageBox.Show("异常：" + error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Add_Appointment_Click(object sender, RoutedEventArgs e)
        {
            using SqlConnection connection = new(ConnectionString);
            try
            {
                string sql = "INSERT INTO Appointments VALUES (@date, @customerId)";
                var date = appointmentDatePicker?.Text;
                var customerId = customerList.SelectedValue;

                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@customerId", customerId);

                connection.Open();
                command.ExecuteNonQuery();

                CustomerList_SelectionChanged(null, null);
            }
            catch (Exception error)
            {
                MessageBox.Show("异常：" + error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Update_Customer_Click(object sender, RoutedEventArgs e)
        {
            using SqlConnection connection = new(ConnectionString);
            try
            {
                string sql = @"UPDATE Customer 
                               SET Name = @name, IdNumber = @idnumber, Address = @address 
                               WHERE Id = @customerId";
                var name = NameTextBox.Text;
                var idnumber = IDTextBox.Text;
                var address = AddressTextBox.Text;
                var customerId = customerList.SelectedValue;

                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@idnumber", idnumber);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@customerId", customerId);

                connection.Open();
                command.ExecuteNonQuery();

                ShowCustomers();
            }
            catch (Exception error)
            {
                MessageBox.Show("异常：" + error);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}