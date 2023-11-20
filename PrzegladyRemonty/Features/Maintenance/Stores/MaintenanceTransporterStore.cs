using PrzegladyRemonty.Models;
using System.ComponentModel;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class MaintenanceTransporterStore : INotifyPropertyChanged
    {
        private Transporter _transporter;

        public Transporter Transporter
        {
            get
            {
                return _transporter;
            }
            set
            {
                _transporter = value;
                OnPropertyChanged(nameof(Transporter));
            }
        }

        public MaintenanceTransporterStore()
        {
            _transporter = new Transporter("", 0, 0);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
