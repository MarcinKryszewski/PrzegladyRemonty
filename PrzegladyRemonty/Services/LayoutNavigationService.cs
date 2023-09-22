﻿using PrzegladyRemonty.Layout.Content;
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
        private readonly SidePanelViewModel _sidePanelViewModel;
        private readonly TopPanelViewModel _topPanelViewModel;

        public LayoutNavigationService(NavigationStore navigationStore,
            Func<TViewModel> createViewModel,
            SidePanelViewModel sidePanelViewModel,
            TopPanelViewModel topPanelViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _sidePanelViewModel = sidePanelViewModel;
            _topPanelViewModel = topPanelViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new ContentViewModel(_sidePanelViewModel, _topPanelViewModel, _createViewModel());
        }
    }
}
