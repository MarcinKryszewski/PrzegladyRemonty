using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Features.Transporters.Stores;
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
    public class TransportersEditViewModel : ViewModelBase
    {
        #region Fields
        private readonly int _id;
        private readonly ObservableCollection<Area> _areasFiltered;
        private readonly IEnumerable<Line> _lines;
        private readonly IEnumerable<Area> _areas;
        private readonly IEnumerable<TransporterType> _transporterTypes;

        private string _name;
        private bool _active;
        private Line _line;
        private Area _area;
        private TransporterType _transporterType;
        #endregion

        #region FieldsAccess
        public int Id => _id;
        public bool Active
        {
            get => _active;
            set
            {
                _active = value;
                OnPropertyChanged(nameof(Active));
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
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
        public bool IsLineSelected => _line != null;
        public IEnumerable<Line> Lines => _lines;
        public IEnumerable<Area> Areas => _areasFiltered;
        public IEnumerable<TransporterType> TransporterTypes => _transporterTypes;
        #endregion

        #region Commands
        public ICommand NavigateMainCommand { get; }
        public ICommand EditCommand { get; }
        #endregion

        #region Constructors
        public TransportersEditViewModel(
            INavigationService<TransportersMainViewModel> transportersMainViewModel,
            IHost databaseHost,
            IEnumerable<Line> lines,
            IEnumerable<Area> areas,
            IEnumerable<TransporterType> transporterTypes,
            SelectedTransporter selectedTransporter)
        {
            _lines = lines;
            _areas = areas;
            _transporterTypes = transporterTypes;
            _areasFiltered = new ObservableCollection<Area>();

            Transporter transporter = selectedTransporter.Transporter;
            _id = transporter.Id;
            _name = transporter.Name;
            _active = transporter.Active;
            _line = transporter.Area.Line;
            _transporterType = transporter.TransporterType;

            ArasFiltered();
            _area = transporter.Area;

            EditCommand = new TransportersEditCommand(this, databaseHost.Services.GetRequiredService<TransporterProvider>());
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