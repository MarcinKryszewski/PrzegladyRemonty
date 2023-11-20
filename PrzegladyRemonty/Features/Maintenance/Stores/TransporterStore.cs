using PrzegladyRemonty.Models;

namespace PrzegladyRemonty.Features.Maintenance
{
    public class TransporterStore
    {
        public Transporter Transporter { get; set; }

        public TransporterStore()
        {
            Transporter = new Transporter("", 0, 0);
        }
    }
}
