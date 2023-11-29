using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Dashboard
{
    public class DashboardViewModel : ViewModelBase
    {
        private int _openTasks;
        private int _myWorkOrders;

        public int OpenTasks
        {
            get => _openTasks;
            set
            {
                _openTasks = value;
                OnPropertyChanged(nameof(OpenTasks));
            }
        }

        public int MyWorkOrders
        {
            get => _myWorkOrders;
            set
            {
                _myWorkOrders = value;
                OnPropertyChanged(nameof(MyWorkOrders));
            }
        }


        public DashboardViewModel()
        {
            _myWorkOrders = 5;
            _openTasks = 7;
        }


    }
}
