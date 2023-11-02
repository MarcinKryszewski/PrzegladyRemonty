using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Areas
{
    public class AreasMainViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Area> _areas;
        private readonly IHost _databaseHost;
        private readonly IEnumerable<Line> _lines;
        private Area _selectedArea;
        private readonly SelectedArea _areaStore;

        public IEnumerable<Area> Areas => _areas;
        public ICommand NavigateEditCommand { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDetailsCommand { get; }
        public ICommand LoadCommand { get; }
        public ICommand RemoveCommand { get; }

        public Area SelectedArea
        {
            get => _selectedArea;
            set
            {
                _selectedArea = value;
                _areaStore.Area = value;
                OnPropertyChanged(nameof(SelectedArea));
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public SelectedArea SelectedAreaStore => _areaStore;
        public bool IsSelected => _selectedArea != null;

        public AreasMainViewModel(
            INavigationService<AreasEditViewModel> areasEditViewModel,
            INavigationService<AreasAddViewModel> areasAddViewModel,
            INavigationService<AreasDetailsViewModel> areasDetailsViewModel,
            SelectedArea selectedArea,
            IEnumerable<Line> lines,
            IHost databaseHost)
        {
            NavigateEditCommand = new NavigateCommand<AreasEditViewModel>(areasEditViewModel);
            NavigateAddCommand = new NavigateCommand<AreasAddViewModel>(areasAddViewModel);
            NavigateDetailsCommand = new NavigateCommand<AreasDetailsViewModel>(areasDetailsViewModel);

            _databaseHost = databaseHost;
            _areas = new ObservableCollection<Area>();
            _areaStore = selectedArea;
            _lines = lines;

            LoadCommand = new AreasLoadCommand(this, _databaseHost.Services.GetRequiredService<AreaProvider>());
            RemoveCommand = new AreasRemoveCommand(this, _databaseHost.Services.GetRequiredService<AreaProvider>());

            LoadCommand.Execute(null);
        }

        public void UpdateAreas(IEnumerable<Area> areas)
        {
            _areas.Clear();
            foreach (Area area in areas)
            {
                area.SetLine(_lines.First(l => l.Id == area.LineId));
                _areas.Add(area);
            }
        }
    }
}
