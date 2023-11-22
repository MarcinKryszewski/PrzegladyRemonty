namespace PrzegladyRemonty.Models
{
    public class TransporterAction
    {
        private ActionCategory _action;
        private Transporter _transporter;

        public int Id { get; }
        public int TransporterId { get; }
        public int ActionId { get; }
        public int Frequency { get; }
        public string FrequencyUnit { get; }
        public Transporter Transporter => _transporter;
        public ActionCategory Action => _action;


        public TransporterAction(int transporter, int action, int frequency, string frequencyUnit)
        {
            TransporterId = transporter;
            ActionId = action;
            Frequency = frequency;
            FrequencyUnit = frequencyUnit;
        }
        public TransporterAction(int id, int transporter, int action, int frequency, string frequencyUnit)
        {
            Id = id;
            TransporterId = transporter;
            ActionId = action;
            Frequency = frequency;
            FrequencyUnit = frequencyUnit;
        }

        public void SetTransporter(Transporter transporter)
        {
            _transporter = transporter;
        }

        public void SetAction(ActionCategory action)
        {
            _action = action;
        }
    }
}
