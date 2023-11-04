using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Parts
{
    public class PartsAddCommand : CommandBase
    {
        readonly PartProvider _provider;
        readonly PartsAddViewModel _viewModel;
        public PartsAddCommand(PartsAddViewModel viewModel, PartProvider provider)
        {
            _provider = provider;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            string partName = _viewModel.Name;
            string producent = _viewModel.Producent;
            string producentNumber = _viewModel.ProducentNumber;

            Part part = new(partName, producent, producentNumber);
            part.Add(_provider);
            _viewModel.NavigateMainCommand.Execute(null);
        }
    }
}