using PrzegladyRemonty.Services.Providers;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Models
{
    public class TransporterType
    {
        public int Id { get; }
        public string Name { get; }

        public TransporterType(string name)
        {
            Name = name;
        }
        public TransporterType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void Add(TransporterTypeProvider provider)
        {
            provider.Create(this);
        }
        public void Edit(TransporterTypeProvider provider)
        {
            provider.Update(this);
        }
        public async Task Delete(TransporterTypeProvider provider)
        {
            await provider.Delete(Id);
        }
    }
}
