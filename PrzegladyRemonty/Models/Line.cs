using PrzegladyRemonty.Services.Providers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Models
{
    public class Line
    {
        private readonly ObservableCollection<Area> _areas;

        public int Id { get; }
        public string Name { get; }
        public bool Active { get; }
        public IEnumerable<Area> Areas => _areas;

        public Line(int id, string name, bool active)
        {
            Id = id;
            Name = name;
            Active = active;
        }

        public Line(string name)
        {
            Name = name;
        }

        public void AddArea(Area area)
        {
            _areas.Add(area);
        }

        public void Add(LineProvider lineProvider)
        {
            lineProvider.Create(this);
        }
        public void Edit(LineProvider lineProvider)
        {
            lineProvider.Update(this);
        }
        public async Task Delete(LineProvider lineProvider)
        {
            await lineProvider.Delete(Id);
        }
    }
}
