using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class RemoveTransporterCommand : CommandBase
    {
        private readonly TransporterStore _selectedTransporter;
        private readonly TransportersListStore _transportersList;
        public RemoveTransporterCommand(TransporterStore selectedTransporter, TransportersListStore transportersList)
        {
            _selectedTransporter = selectedTransporter;
            _transportersList = transportersList;
        }

        public override void Execute(object parameter)
        {
            _transportersList.RemoveTransporter(_selectedTransporter.Transporter);
        }
    }
}
