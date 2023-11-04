using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.TransporterTypes
{
    public class TransporterTypesDetailsViewModel : ViewModelBase
    {
        public ICommand NavigateMainCommand { get; }

        public TransporterTypesDetailsViewModel(
            INavigationService<TransporterTypesMainViewModel> transporterTypesMainViewModel
            )
        {
            NavigateMainCommand = new NavigateCommand<TransporterTypesMainViewModel>(transporterTypesMainViewModel);
        }
    }
}
