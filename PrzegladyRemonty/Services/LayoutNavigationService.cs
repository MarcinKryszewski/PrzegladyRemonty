using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Layout.Content;
using PrzegladyRemonty.Layout.SidePanel;
using PrzegladyRemonty.Layout.TopPanel;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Shared.ViewModels;
using PrzegladyRemonty.Stores;
using System;
using System.Reflection;

namespace PrzegladyRemonty.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly Func<SidePanelViewModel> _createSidePanelViewModel;
        private readonly TopPanelViewModel _topPanelViewModel;
        private SelectedPanelStore _selectedPanelStore;

        public LayoutNavigationService(IHost _navigationHost,
            Func<TViewModel> createViewModel,
            Func<SidePanelViewModel> createSidePanelViewModel)
        {
            IServiceProvider services = _navigationHost.Services;
            _navigationStore = services.GetRequiredService<NavigationStore>();
            _topPanelViewModel = services.GetRequiredService<TopPanelViewModel>();

            _createViewModel = createViewModel;
            _createSidePanelViewModel = createSidePanelViewModel;
            _selectedPanelStore = _navigationHost.Services.GetRequiredService<SelectedPanelStore>();
        }

        public void Navigate()
        {
            _selectedPanelStore.PanelName = ExtractName(typeof(TViewModel).FullName);
            _navigationStore.CurrentViewModel = new ContentViewModel(_createSidePanelViewModel(), _topPanelViewModel, _createViewModel());
        }

        private static string ExtractName(string name)
        {
            return name.Split('.')[2];
        }
    }
}