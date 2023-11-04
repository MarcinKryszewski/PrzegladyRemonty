using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersRemoveCommand : AsyncCommandBase
    {
        private readonly TransportersMainViewModel _viewModel;
        private readonly TransporterProvider _provider;

        public TransportersRemoveCommand(TransportersMainViewModel viewModel, TransporterProvider provider)
        {
            _viewModel = viewModel;
            _provider = provider;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.IsSelected;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Transporter transporter = _viewModel.SelectedTransporterStore.Transporter;
            await transporter.Delete(_provider);
            _viewModel.LoadCommand.Execute(null);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TransportersMainViewModel.IsSelected))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
