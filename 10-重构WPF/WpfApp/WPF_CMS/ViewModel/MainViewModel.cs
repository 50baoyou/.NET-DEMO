using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using WPF_CMS.Model;

namespace WPF_CMS.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        /**
         * ObservableCollection<T> 类本身并不实现 INotifyPropertyChanged 接口
         * 因此集合内元素的更改（例如添加、删除元素）会自动引发集合变更事件
         * 但集合本身的更改不会引发属性变更事件
         */
        public ObservableCollection<CustomerViewModel> Customers { get; set; }

        public ObservableCollection<DateTime> Appointments { get; set; }

        private CustomerViewModel? _selectedCustomer;

        public CustomerViewModel? SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                if (value != _selectedCustomer)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged();

                    if (SelectedCustomer is not null)
                    {
                        LoadAppointments(SelectedCustomer.Id);
                    }
                    else
                    {
                        Appointments.Clear();
                    }
                }
            }
        }

        // 事件拥有者：实现 INotifyPropertyChanged 接口的类（MainViewModel）
        // 事件：PropertyChanged（属性变化事件）
        // 事件订阅者：UI元素
        // 事件处理器：OnPropertyChanged
        // 事件订阅：通过属性的 set 方法中的 OnPropertyChanged() 实现

        // 使用委托规范事件处理器，PropertyChangedEventHandler（自带）

        // 字段式事件声明
        public event PropertyChangedEventHandler? PropertyChanged;

        // 跟踪调用方信息 [CallerMemberName]
        // 该特性使调用方法时，若不传递参数，会默认在编译时自动填充调用方的成员名称
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            Customers = new();
            Appointments = new();
        }

        public void LoadCustomers()
        {
            Customers.Clear();

            try
            {
                using AppDbContext dbContext = new();
                var customers = dbContext.Customers.ToList();

                foreach (var customer in customers)
                {
                    Customers.Add(new CustomerViewModel(customer));
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("异常：" + error);
            }
        }

        public void ClearSelectedCustomer()
        {
            SelectedCustomer = null;
        }

        public void SaveCustomer(string name, string idNumber, string address)
        {
            try
            {
                using AppDbContext dbContext = new();

                if (SelectedCustomer is null)
                {
                    // 添加客户
                    Customer customer = new()
                    {
                        Name = name,
                        IdNumber = idNumber,
                        Address = address
                    };

                    dbContext.Customers.Add(customer);
                    dbContext.SaveChanges();

                    // 将元素添加进入集合，触发集合变更事件更新UI
                    Customers.Add(new CustomerViewModel(customer));
                }
                else
                {
                    // 更新客户
                    var item = dbContext.Customers
                        .Where(item => item.Id == SelectedCustomer.Id)
                        .FirstOrDefault();
                    if (item is Customer customer)
                    {
                        customer.Name = name;
                        customer.IdNumber = idNumber;
                        customer.Address = address;
                    }
                    dbContext.SaveChanges();

                    // 如果 Customers 集合包含该对象，则更新 Customers 集合中的对象
                    if (Customers.Contains(SelectedCustomer))
                    {
                        Customer newCustomer = new()
                        {
                            Id = SelectedCustomer.Id,
                            Name = name,
                            IdNumber = idNumber,
                            Address = address,
                        };

                        // 替换数据
                        int index = Customers.IndexOf(SelectedCustomer);
                        Customers[index] = new CustomerViewModel(newCustomer);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("异常：" + error);
            }
        }

        public void LoadAppointments(int customerId)
        {
            Appointments.Clear();

            try
            {
                using AppDbContext dbContext = new();
                var appointments = dbContext.Appointments
                    .Where(item => item.CustomerId == customerId)
                    .ToList();

                foreach (var appointment in appointments)
                {
                    Appointments.Add(appointment.Time);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("异常：" + error);
            }
        }

        public void AddAppointment(DateTime selectedDate)
        {
            if (SelectedCustomer is null)
            {
                return;
            }

            try
            {
                using AppDbContext dbContext = new();

                Appointment appointment = new()
                {
                    Time = selectedDate,
                    CustomerId = SelectedCustomer.Id,
                };

                dbContext.Appointments.Add(appointment);
                dbContext.SaveChanges();

                Appointments.Add(appointment.Time);
            }
            catch (Exception error)
            {
                MessageBox.Show("异常：" + error);
            }
        }
    }
}
