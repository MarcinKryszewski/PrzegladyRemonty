using PrzegladyRemonty.Services.Providers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Models
{
    public class Area
    {
        private readonly ObservableCollection<Transporter> _transporters;
        private Line _line;

        public int Id { get; }
        public string Name { get; }
        public bool Active { get; }
        public int LineId { get; }
        public Line Line => _line;
        public IEnumerable<Transporter> Transporters => _transporters;

        public Area(int id, string name, bool active, int line)
        {
            Id = id;
            Name = name;
            Active = active;
            LineId = line;
            _transporters = new ObservableCollection<Transporter>();
        }

        public Area(string name, int line)
        {
            Name = name;
            LineId = line;
            _transporters = new ObservableCollection<Transporter>();
        }

        public void AddTransporter(Transporter transporter)
        {
            _transporters.Add(transporter);
        }
        public void SetLine(Line line)
        {
            _line = line;
        }
        public void Add(AreaProvider areaProvider)
        {
            areaProvider.Create(this);
        }
        public void Edit(AreaProvider areaProvider)
        {
            areaProvider.Update(this);
        }
        public async Task Delete(AreaProvider areaProvider)
        {
            await areaProvider.Delete(Id);
        }
    }
}