using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Lines
{
    public class LinesAddViewModel : ViewModelBase
    {
        private string _lineName;
        public string LineName
        {
            get => _lineName;
            set
            {
                _lineName = value;
                OnPropertyChanged(nameof(LineName));
            }
        }

        public ICommand NavigateMainCommand { get; }
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateDetailsCommand { get; }
        public ICommand AddCommand { get; }

        public LinesAddViewModel(
            INavigationService<LinesMainViewModel> linesMainViewModel,
            INavigationService<LinesEditViewModel> linesEditViewModel,
            INavigationService<LinesDetailsViewModel> linesDetailsViewModel,
            IHost databaseHost
            )
        {
            NavigateMainCommand = new NavigateCommand<LinesMainViewModel>(linesMainViewModel);
            NavigateEditCommand = new NavigateCommand<LinesEditViewModel>(linesEditViewModel);
            NavigateDetailsCommand = new NavigateCommand<LinesDetailsViewModel>(linesDetailsViewModel);

            AddCommand = new LinesAddCommand(
                this,
                databaseHost.Services.GetRequiredService<LineProvider>()
                );
        }
    }
}
