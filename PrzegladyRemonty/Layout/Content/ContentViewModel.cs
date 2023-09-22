using PrzegladyRemonty.Layout.SidePanel;
using PrzegladyRemonty.Layout.TopPanel;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Layout.Content
{
    public class ContentViewModel : ViewModelBase
    {
        public SidePanelViewModel SidePanelViewModel { get; }
        public TopPanelViewModel TopPanelViewModel { get; }
        public ViewModelBase Content { get; }
        public ContentViewModel(SidePanelViewModel sidePanelViewModel, TopPanelViewModel topPanelViewModel, ViewModelBase content)
        {
            SidePanelViewModel = sidePanelViewModel;
            TopPanelViewModel = topPanelViewModel;
            Content = content;
        }
    }
}
