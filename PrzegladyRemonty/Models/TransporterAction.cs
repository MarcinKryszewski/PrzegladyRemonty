namespace PrzegladyRemonty.Models
{
    public class TransporterAction
    {
        public int Id { get; }
        public int Transporter { get; }
        public int Action { get; }
        public int Frequency { get; }
        public string FrequencyUnit { get; }

        public TransporterAction(int transporter, int action, int frequency, string frequencyUnit)
        {
            Transporter = transporter;
            Action = action;
            Frequency = frequency;
            FrequencyUnit = frequencyUnit;
        }
        public TransporterAction(int id, int transporter, int action, int frequency, string frequencyUnit)
        {
            Id = id;
            Transporter = transporter;
            Action = action;
            Frequency = frequency;
            FrequencyUnit = frequencyUnit;
        }

    }
}
