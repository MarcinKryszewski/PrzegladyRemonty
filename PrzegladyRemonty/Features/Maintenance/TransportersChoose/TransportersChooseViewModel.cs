using System;
using PrzegladyRemonty.Shared.ViewModels;

namespace PrzegladyRemonty.Features.Maintenance;

public class TransportersChooseViewModel : ViewModelBase
{
    public ActionsListViewModel ActionsListViewModel { get; }
    public PartsListViewModel PartsListViewModel { get; }
    public ProductionLineListViewModel ProductionLineListViewModel { get; }
    public TransporterCartViewModel TransporterCartViewModel { get; }

    public TransportersChooseViewModel()
    {
        ActionsListViewModel = new();
        PartsListViewModel = new();
        ProductionLineListViewModel = new();
        TransporterCartViewModel = new();
    }
}
