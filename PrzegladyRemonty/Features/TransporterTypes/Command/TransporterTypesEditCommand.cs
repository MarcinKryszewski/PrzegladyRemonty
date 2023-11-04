using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.TransporterTypes
{
    public class TransporterTypesEditCommand : CommandBase
    {
        readonly TransporterTypeProvider _transporterTypeProvider;
        readonly TransporterTypesEditViewModel _transporterTypesEditViewModel;
        public TransporterTypesEditCommand(TransporterTypesEditViewModel transporterTypesEditViewModel, TransporterTypeProvider transporterTypeProvider)
        {
            _transporterTypeProvider = transporterTypeProvider;
            _transporterTypesEditViewModel = transporterTypesEditViewModel;
        }

        public override void Execute(object parameter)
        {
            TransporterType transporterType = new(
                _transporterTypesEditViewModel.TransporterTypeId,
                _transporterTypesEditViewModel.Name
                );
            transporterType.Edit(_transporterTypeProvider);
            _transporterTypesEditViewModel.NavigateMainCommand.Execute(null);
        }
    }
}