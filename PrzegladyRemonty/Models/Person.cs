namespace PrzegladyRemonty.Models
{
    public class Person
    {
        public int Id { get; }
        public string Login { get; }
        public string Name { get; }
        public string Surname { get; }
        public bool Active { get; }
        public string FullName { get; }

        public Person(int id, string login, string name, string surname, bool active)
        {
            Id = id;
            Login = login;
            Name = name;
            Surname = surname;
            Active = active;
            FullName = string.Format("{0} {1}", name, surname);
        }

        public Person(string login, string name, string surname)
        {
            Login = login;
            Name = name;
            Surname = surname;
            FullName = string.Format("{0} {1}", name, surname);
        }
    }
}
