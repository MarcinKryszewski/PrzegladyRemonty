using PrzegladyRemonty.Services.Providers;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Models
{
    public class Part
    {
        public int Id { get; }
        public string Name { get; }
        public string Producent { get; }
        public string ProducentNumber { get; }

        public Part(string name, string producent, string producentNumber)
        {
            Name = name;
            Producent = producent;
            ProducentNumber = producentNumber;
        }

        public Part(int id, string name, string producent, string producentNumber)
        {
            Id = id;
            Name = name;
            Producent = producent;
            ProducentNumber = producentNumber;
        }
        public void Add(PartProvider provider)
        {
            provider.Create(this);
        }
        public void Edit(PartProvider provider)
        {
            provider.Update(this);
        }
        public async Task Delete(PartProvider provider)
        {
            await provider.Delete(Id);
        }
    }
}
