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

namespace PrzegladyRemonty.Features.Transporters
{
    public class TransportersAddViewModel : ViewModelBase
    {
        #region Fields
        private string _transportName;
        private Line _line;
        private Area _area;
        private TransporterType _transporterType;
        private readonly ObservableCollection<Area> _areasFiltered;

        private readonly IHost _databaseHost;
        private readonly IEnumerable<Line> _lines;
        private readonly IEnumerable<Area> _areas;
        private readonly IEnumerable<TransporterType> _transporterTypes;
        #endregion

        #region Commands
        public ICommand NavigateMainCommand { get; }
        public ICommand AddCommand { get; }
        #endregion

        #region FieldsAccess
        public string Name
        {
            get => _transportName;
            set
            {
                _transportName = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public Line Line
        {
            get => _line;
            set
            {
                _line = value;
                ArasFiltered();
                OnPropertyChanged(nameof(Line));
                OnPropertyChanged(nameof(Area));
                OnPropertyChanged(nameof(IsLineSelected));
            }
        }
        public Area Area
        {
            get => _area;
            set
            {
                _area = value;
                OnPropertyChanged(nameof(Area));
            }
        }
        public TransporterType TransporterType
        {
            get => _transporterType;
            set
            {
                _transporterType = value;
                OnPropertyChanged(nameof(TransporterType));
            }
        }
        public IEnumerable<Line> Lines => _lines;
        public IEnumerable<Area> Areas => _areasFiltered;
        public IEnumerable<TransporterType> TransporterTypes => _transporterTypes;
        public bool IsLineSelected => _line != null;
        #endregion

        #region Constructors
        public TransportersAddViewModel(
            INavigationService<TransportersMainViewModel> transportersMainViewModel,
            IHost databaseHost,
            IEnumerable<Line> lines,
            IEnumerable<Area> areas,
            IEnumerable<TransporterType> transporterTypes)
        {

            _databaseHost = databaseHost;
            _lines = lines;
            _areas = areas;
            _transporterTypes = transporterTypes;
            _areasFiltered = new ObservableCollection<Area>();

            AddCommand = new TransportersAddCommand(this, _databaseHost.Services.GetRequiredService<TransporterProvider>());
            NavigateMainCommand = new NavigateCommand<TransportersMainViewModel>(transportersMainViewModel);
        }
        #endregion

        private void ArasFiltered()
        {
            _areasFiltered.Clear();

            IEnumerable<Area> filteredAreas = _areas.Where(a => a.LineId == _line.Id);
            foreach (Area area in filteredAreas)
            {
                _areasFiltered.Add(area);
            }
        }
    }
}