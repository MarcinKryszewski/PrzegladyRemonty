using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Commands.Load;
using PrzegladyRemonty.Interfaces;
using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Shared.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PrzegladyRemonty.Features.Areas
{
    public class AreasViewModel : ViewModelBase, ILineUpdate
    {
        private readonly NavigationStore _navigationStore;
        private readonly IHost _databaseHost;
        private readonly SelectedArea _selectedArea;
        private readonly ObservableCollection<Line> _lines;
        private readonly ICommand _loadLines;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public AreasViewModel(IHost databaseHost)
        {
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _databaseHost = databaseHost;
            _selectedArea = new SelectedArea();

            INavigationService<AreasMainViewModel> areasMainNavigationService = CreateAreasMainNavigationService();
            _loadLines = new LinesLoadCommand(this, _databaseHost.Services.GetRequiredService<LineProvider>());
            _lines = new ObservableCollection<Line>();

            _loadLines.Execute(null);
            areasMainNavigationService.Navigate();
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private INavigationService<AreasMainViewModel> CreateAreasMainNavigationService()
        {
            return new DefaultNavigationService<AreasMainViewModel>
            (
                _navigationStore,
                () => new AreasMainViewModel(
                    CreateAreasEditNavigationService(),
                    CreateAreasAddNavigationService(),
                    CreateAreasDetailsNavigationService(),
                    _selectedArea,
                    _lines,
                    _databaseHost)
            );
        }
        private INavigationService<AreasAddViewModel> CreateAreasAddNavigationService()
        {
            return new DefaultNavigationService<AreasAddViewModel>
            (
                _navigationStore,
                () => new AreasAddViewModel(
                    CreateAreasMainNavigationService(),
                    _databaseHost,
                    _lines)
            );
        }
        private INavigationService<AreasDetailsViewModel> CreateAreasDetailsNavigationService()
        {
            return new DefaultNavigationService<AreasDetailsViewModel>
            (
                _navigationStore,
                () => new AreasDetailsViewModel(CreateAreasMainNavigationService())
            );
        }
        private INavigationService<AreasEditViewModel> CreateAreasEditNavigationService()
        {
            return new DefaultNavigationService<AreasEditViewModel>
            (
                _navigationStore,
                () => new AreasEditViewModel(
                    CreateAreasMainNavigationService(),
                    _selectedArea,
                    _databaseHost,
                    _lines)
            );
        }

        public void UpdateLines(IEnumerable<Line> lines)
        {
            _lines.Clear();
            foreach (Line line in lines)
            {
                _lines.Add(line);
            }
        }
    }
}