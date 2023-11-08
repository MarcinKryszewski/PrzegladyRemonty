using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Parts
{
    public class PartsAddViewModel : ViewModelBase
    {
        private string _name;
        private string _producent;
        private string _producentNumber;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Producent
        {
            get => _producent;
            set
            {
                _producent = value;
                OnPropertyChanged(nameof(Producent));
            }
        }
        public string ProducentNumber
        {
            get => _producentNumber;
            set
            {
                _producentNumber = value;
                OnPropertyChanged(nameof(ProducentNumber));
            }
        }

        public ICommand NavigateMainCommand { get; }
        public ICommand AddCommand { get; }

        public PartsAddViewModel(
            INavigationService<PartsMainViewModel> partsMainViewModel,
            IHost databaseHost
            )
        {
            NavigateMainCommand = new NavigateCommand<PartsMainViewModel>(partsMainViewModel);

            AddCommand = new PartsAddCommand(
                this,
                databaseHost.Services.GetRequiredService<PartProvider>()
            );
        }
    }
}