using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.TransporterTypes
{
    public class TransporterTypesAddViewModel : ViewModelBase
    {
        private string _transporterTypeName;
        private readonly IHost _databaseHost;

        public string Name
        {
            get => _transporterTypeName;
            set
            {
                _transporterTypeName = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand NavigateMainCommand { get; }
        public ICommand AddCommand { get; }

        public TransporterTypesAddViewModel(
            INavigationService<TransporterTypesMainViewModel> transporterTypesMainViewModel,
            IHost databaseHost
            )
        {
            NavigateMainCommand = new NavigateCommand<TransporterTypesMainViewModel>(transporterTypesMainViewModel);

            _databaseHost = databaseHost;
            AddCommand = new TransporterTypesAddCommand(
                this,
                _databaseHost.Services.GetRequiredService<TransporterTypeProvider>()
            );
        }
    }
}