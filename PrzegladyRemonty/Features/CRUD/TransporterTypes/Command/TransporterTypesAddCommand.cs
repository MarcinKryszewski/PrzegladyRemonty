using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.TransporterTypes
{
    public class TransporterTypesAddCommand : CommandBase
    {
        readonly TransporterTypeProvider _transporterTypeProvider;
        readonly TransporterTypesAddViewModel _transporterTypesAddViewModel;
        public TransporterTypesAddCommand(TransporterTypesAddViewModel transporterTypesAddViewModel, TransporterTypeProvider transporterTypeProvider)
        {
            _transporterTypeProvider = transporterTypeProvider;
            _transporterTypesAddViewModel = transporterTypesAddViewModel;
        }

        public override void Execute(object parameter)
        {
            string transporterTypeName = _transporterTypesAddViewModel.Name;

            TransporterType transporterType = new(transporterTypeName);
            transporterType.Add(_transporterTypeProvider);
            _transporterTypesAddViewModel.NavigateMainCommand.Execute(null);
        }
    }
}