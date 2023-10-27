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
    }
}