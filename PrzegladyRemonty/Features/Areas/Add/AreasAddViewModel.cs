using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Areas
{
    public class AreasAddViewModel : ViewModelBase
    {
        private string _areaName;
        private Line _line;
        private readonly IHost _databaseHost;
        private readonly IEnumerable<Line> _lines;

        public ICommand NavigateMainCommand { get; }
        public ICommand AddCommand { get; }
        public string Name
        {
            get => _areaName;
            set
            {
                _areaName = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public Line Line
        {
            get => _line;
            set
            {
                _line = value;
                OnPropertyChanged(nameof(Line));
            }
        }
        public IEnumerable<Line> Lines => _lines;

        public AreasAddViewModel(
            INavigationService<AreasMainViewModel> areasMainViewModel,
            IHost databaseHost,
            IEnumerable<Line> lines
            )
        {
            _databaseHost = databaseHost;
            _lines = lines;

            AddCommand = new AreasAddCommand(this, _databaseHost.Services.GetRequiredService<AreaProvider>());
            NavigateMainCommand = new NavigateCommand<AreasMainViewModel>(areasMainViewModel);
        }
    }
}
