using PrzegladyRemonty.Models;
using PrzegladyRemonty.Services.Providers;
using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.ActionsCategories
{
    public class ActionsCategoriesEditCommand : CommandBase
    {
        readonly ActionCategoryProvider _provider;
        readonly ActionsCategoriesEditViewModel _viewModel;
        public ActionsCategoriesEditCommand(ActionsCategoriesEditViewModel viewModel, ActionCategoryProvider provider)
        {
            _provider = provider;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            ActionCategory part = new(
                _viewModel.Id,
                _viewModel.Name
                );
            part.Edit(_provider);
            _viewModel.NavigateMainCommand.Execute(null);
        }
    }
}