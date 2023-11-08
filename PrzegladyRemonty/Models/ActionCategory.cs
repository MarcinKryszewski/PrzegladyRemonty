using PrzegladyRemonty.Services.Providers;
using System.Threading.Tasks;

namespace PrzegladyRemonty.Models
{
    public class ActionCategory
    {
        public int Id { get; }
        public string Name { get; }

        public ActionCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ActionCategory(string name)
        {
            Name = name;
        }

        public void Add(ActionCategoryProvider provider)
        {
            provider.Create(this);
        }
        public void Edit(ActionCategoryProvider provider)
        {
            provider.Update(this);
        }
        public async Task Delete(ActionCategoryProvider provider)
        {
            await provider.Delete(Id);
        }
    }
}