using WPF_CMS.Model;

namespace WPF_CMS.ViewModel
{
    public class CustomerViewModel
    {
        private readonly Customer _customer;

        public int Id
        {
            get { return _customer.Id; }
        }

        public string Name
        {
            get => _customer.Name;
            set
            {
                if (value != _customer.Name)
                {
                    _customer.Name = value;
                }
            }
        }

        public string IdNumber
        {
            get => _customer.IdNumber;
            set
            {
                if (value != _customer.IdNumber)
                {
                    _customer.IdNumber = value;
                }
            }
        }

        public string Address
        {
            get => _customer.Address;
            set
            {
                if (value != _customer.Address)
                {
                    _customer.Address = value;
                }
            }
        }

        public CustomerViewModel(Customer customer)
        {
            _customer = customer;
        }
    }
}
