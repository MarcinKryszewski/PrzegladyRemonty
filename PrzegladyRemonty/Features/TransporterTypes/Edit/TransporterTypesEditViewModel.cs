using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.TransporterTypes
{
    public class TransporterTypesEditViewModel : ViewModelBase
    {
        private string _transporterTypeName;
        private int _transporterTypeId;

        public int TransporterTypeId
        {
            get => _transporterTypeId;
            set
            {
                _transporterTypeId = value;
            }
        }
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
        public ICommand EditCommand { get; }

        public TransporterTypesEditViewModel(
            INavigationService<TransporterTypesMainViewModel> transporterTypesMainViewModel,
            SelectedTransporterType selectedTransporterType,
            IHost databaseHost
            )
        {
            NavigateMainCommand = new NavigateCommand<TransporterTypesMainViewModel>(transporterTypesMainViewModel);

            _transporterTypeId = selectedTransporterType.TransporterType.Id;
            _transporterTypeName = selectedTransporterType.TransporterType.Name;

            EditCommand = new TransporterTypesEditCommand(this, databaseHost.Services.GetRequiredService<TransporterTypeProvider>());
        }
    }
}