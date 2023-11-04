using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;
namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersDetailsViewModel : ViewModelBase
    {
        private readonly IHost _database;
        public ICommand NavigateMainCommand { get; }

        public TransportersDetailsViewModel(
            INavigationService<TransportersMainViewModel> transportersMainViewModel,
            IHost database)
        {
            NavigateMainCommand = new NavigateCommand<TransportersMainViewModel>(transportersMainViewModel);
            _database = database;
        }
    }
}
