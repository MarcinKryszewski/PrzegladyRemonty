using PrzegladyRemonty.Shared.Commands;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Features.Maintenance.TransportersChoose.Commands
{
    public class ClearCartCommand : AsyncCommandBase
    {
        private readonly TransportersListStore _transportersCart;

        public ClearCartCommand(TransportersListStore transportersCart)
        {
            _transportersCart = transportersCart;
        }
        public override Task ExecuteAsync(object parameter)
        {
            _transportersCart.Clear();
            return Task.CompletedTask;
        }
    }
}
