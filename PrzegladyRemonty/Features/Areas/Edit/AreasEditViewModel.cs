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
    public class AreasEditViewModel : ViewModelBase
    {
        private readonly IEnumerable<Line> _lines;
        //private readonly ObservableCollection<Area> _areas;
        private readonly int _id;

        private string _name;
        private bool _active;
        private readonly int _lineId;
        private Line _line;

        public int Id => _id;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public bool Active
        {
            get => _active;
            set
            {
                _active = value;
                OnPropertyChanged(nameof(Active));
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

        public ICommand NavigateMainCommand { get; }
        public ICommand EditCommand { get; }

        public AreasEditViewModel(
            INavigationService<AreasMainViewModel> areasMainViewModel,
            SelectedArea selectedArea,
            IHost databaseHost,
            ObservableCollection<Line> lines)
        {
            _id = selectedArea.Area.Id;
            _name = selectedArea.Area.Name;
            _active = selectedArea.Area.Active;
            _lineId = selectedArea.Area.LineId;

            _lines = lines;
            _line = lines.First(l => l.Id == _lineId);

            NavigateMainCommand = new NavigateCommand<AreasMainViewModel>(areasMainViewModel);
            EditCommand = new AreasEditCommand(this, databaseHost.Services.GetRequiredService<AreaProvider>());
        }
    }
}
