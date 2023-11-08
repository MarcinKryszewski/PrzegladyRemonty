using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Parts
{
    public class PartsEditCommand : CommandBase
    {
        readonly PartProvider _provider;
        readonly PartsEditViewModel _viewModel;
        public PartsEditCommand(PartsEditViewModel viewModel, PartProvider provider)
        {
            _provider = provider;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            Part part = new(
                _viewModel.Id,
                _viewModel.Name,
                _viewModel.Producent,
                _viewModel.ProducentNumber
                );
            part.Edit(_provider);
            _viewModel.NavigateMainCommand.Execute(null);
        }
    }
}