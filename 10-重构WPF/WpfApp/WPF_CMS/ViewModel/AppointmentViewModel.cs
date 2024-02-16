using WPF_CMS.Model;

namespace WPF_CMS.ViewModel
{
    public class AppointmentViewModel
    {
        private readonly Appointment _appointment;

        public int Id { get => _appointment.Id; }

        public DateTime Time
        {
            get
            {
                return _appointment.Time;
            }
            set
            {
                if (value != _appointment.Time)
                {
                    _appointment.Time = value;
                }
            }
        }

        public AppointmentViewModel(Appointment appointment)
        {
            _appointment = appointment;
        }
    }
}
