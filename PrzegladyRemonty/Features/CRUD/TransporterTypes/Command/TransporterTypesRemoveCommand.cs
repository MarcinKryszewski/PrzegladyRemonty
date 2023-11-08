using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Features.TransporterTypes
{
    public class TransporterTypesRemoveCommand : AsyncCommandBase
    {
        private readonly TransporterTypeProvider _transporterTypeProvider;
        private readonly TransporterTypesMainViewModel _transporterTypesMainViewModel;
        public TransporterTypesRemoveCommand(TransporterTypesMainViewModel transporterTypesMainViewModel, TransporterTypeProvider transporterTypeProvider)
        {
            _transporterTypeProvider = transporterTypeProvider;
            _transporterTypesMainViewModel = transporterTypesMainViewModel;
            _transporterTypesMainViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _transporterTypesMainViewModel.IsTransporterTypeSelected;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            TransporterType transporterType = _transporterTypesMainViewModel.SelectedTransporterTypeStore.TransporterType;
            await transporterType.Delete(_transporterTypeProvider);
            _transporterTypesMainViewModel.TransporterTypesLoadCommand.Execute(null);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TransporterTypesMainViewModel.IsTransporterTypeSelected))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
