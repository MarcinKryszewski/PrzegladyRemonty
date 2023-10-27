namespace PrzegladyRemonty.Database.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Active { get; set; }
    }
}