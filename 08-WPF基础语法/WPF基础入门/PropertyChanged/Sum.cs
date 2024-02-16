using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChanged
{
    public class Sum : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private string _num1;
        private string _num2;
        private string _result;

        public Sum()
        {
            _num1 = "0";
            _num2 = "0";
            _result = "0";
        }

        public string Num1
        {
            get
            {
                return _num1;
            }
            set
            {
                if (int.TryParse(value, out int result))
                {
                    _num1 = result.ToString();
                    OnPropertyChanged("Num1");
                    OnPropertyChanged("Result");
                }
            }
        }
        public string Num2
        {
            get
            {
                return _num2;
            }
            set
            {
                if (int.TryParse(value, out int result))
                {
                    _num2 = result.ToString();
                    OnPropertyChanged("Num2");
                    OnPropertyChanged("Result");
                }
            }
        }
        public string Result
        {
            get
            {
                _result = GetSum();
                return _result;
            }
            private set
            {
                _result = value;
            }
        }

        private string GetSum()
        {
            return (int.Parse(_num1) + int.Parse(_num2)).ToString();
        }
    }
}
