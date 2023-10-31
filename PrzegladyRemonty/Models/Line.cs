using PrzegladyRemonty.Services.Providers;

namespace PrzegladyRemonty.Models
{
    public class Line
    {
        public int Id { get; }
        public string Name { get; }
        public bool Active { get; }

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

        public void Add(LineProvider lineProvider)
        {
            lineProvider.Create(this);
        }
        public void Edit(LineProvider lineProvider)
        {
            lineProvider.Update(this);
        }
    }
}
