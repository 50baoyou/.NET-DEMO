using System.Text;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WPF_CMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Demo"].ConnectionString;

        public MainWindow()
        {
            InitializeComponent();

            // using关键字用于处理 IDisposable 接口，它确保在使用完对象后释放其资源。
            // IDisposable接口是指一个对象提供了一个Dispose方法，该方法可以用于释放该对象使用的资源。
            using SqlConnection connection = new(ConnectionString);
            // 开启数据库连接
            connection.Open();
            ShowCustomers(connection);
        }

        private void ShowCustomers(SqlConnection connection)
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

            string sql = "SELECT * FROM Customer";
            using SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            using DataTable customerTable = new();
            adapter.Fill(customerTable);

            customerList.DisplayMemberPath = "Name";
            customerList.SelectedValuePath = "Id";
            customerList.ItemsSource = customerTable.DefaultView;
        }
    }
}