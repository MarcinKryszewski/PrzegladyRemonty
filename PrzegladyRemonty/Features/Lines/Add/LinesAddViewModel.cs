using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Lines
{
    public class LinesAddViewModel : ViewModelBase
    {
        private string _lineName;
        private readonly IHost _databaseHost;

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
        public ICommand AddCommand { get; }

        public LinesAddViewModel(
            INavigationService<LinesMainViewModel> linesMainViewModel,
            IHost databaseHost
            )
        {
            NavigateMainCommand = new NavigateCommand<LinesMainViewModel>(linesMainViewModel);

            _databaseHost = databaseHost;
            AddCommand = new LinesAddCommand(
                this,
                _databaseHost.Services.GetRequiredService<LineProvider>()
            );
        }
    }
}
