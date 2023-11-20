using PrzegladyRemonty.Shared.Commands;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class SelectTransporterCommand : CommandBase
    {
        private readonly TransporterStore _selectedTransporter;
        private readonly TransportersListStore _transportersList;
        public SelectTransporterCommand(TransporterStore selectedTransporter, TransportersListStore transportersList)
        {
            _selectedTransporter = selectedTransporter;
            _transportersList = transportersList;
        }

        public override void Execute(object parameter)
        {
            _transportersList.AddTransporter(_selectedTransporter.Transporter);
        }
    }
}
