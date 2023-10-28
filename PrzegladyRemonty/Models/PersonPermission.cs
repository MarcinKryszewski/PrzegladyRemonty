namespace PrzegladyRemonty.Models
{
    public class PersonPermission
    {

        public int Id { get; }
        public int Person { get; }
        public int Permission { get; }

        public PersonPermission(int person, int permission)
        {
            Person = person;
            Permission = permission;
        }

        public PersonPermission(int id, int person, int permission)
        {
            Id = id;
            Person = person;
            Permission = permission;
        }
    }
}
