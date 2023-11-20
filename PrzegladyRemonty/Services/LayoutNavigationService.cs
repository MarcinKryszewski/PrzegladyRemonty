using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Layout.Content;
using PrzegladyRemonty.Layout.SidePanel;
using PrzegladyRemonty.Layout.TopPanel;
using PrzegladyRemonty.Shared.Services;
using PrzegladyRemonty.Shared.Stores;
using PrzegladyRemonty.Shared.ViewModels;
using System;

namespace PrzegladyRemonty.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly Func<SidePanelViewModel> _createSidePanelViewModel;
        private readonly TopPanelViewModel _topPanelViewModel;

        public LayoutNavigationService(IHost _navigationHost,
            Func<TViewModel> createViewModel,
            Func<SidePanelViewModel> createSidePanelViewModel)
        {
            IServiceProvider services = _navigationHost.Services;
            _navigationStore = services.GetRequiredService<NavigationStore>();
            _topPanelViewModel = services.GetRequiredService<TopPanelViewModel>();

            _createViewModel = createViewModel;
            _createSidePanelViewModel = createSidePanelViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new ContentViewModel(_createSidePanelViewModel(), _topPanelViewModel, _createViewModel());
        }
    }
}