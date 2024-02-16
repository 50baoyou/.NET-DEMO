using Microsoft.Data.SqlClient;

namespace 使用IDisposable
{
    internal class DBHelper : IDisposable
    {
        private SqlConnection? _connection;

        private string _connectionStr = $"Data Source=localhost\\SQLEXPRESS;Initial Catalog=demo;Integrated Security=True;Encrypt=False;"
            + $"App=Helloworld;"
            + $"Max Pool Size=100;"
            + $"Pooling=true;";
        private bool disposedValue;

        public string GetData()
        {
            _connection ??= new(_connectionStr);
            Console.WriteLine("数据库连接已开启");
            _connection.Open();
            var command = _connection.CreateCommand();
            command.CommandText = "select getdate()";

            return command.ExecuteScalar().ToString();
        }

        public void CloseDB()
        {
            Console.WriteLine("关闭数据库连接");
            _connection?.Close();
            _connection?.Dispose();
            _connection = null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)
                    Console.WriteLine("关闭数据库连接");
                    _connection?.Close();
                    _connection?.Dispose();
                    _connection = null;
                }

                // TODO: 释放未托管的资源(未托管的对象)并重写终结器
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~DBHelper()
        // {
        //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
