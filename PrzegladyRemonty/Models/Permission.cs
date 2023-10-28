namespace PrzegladyRemonty.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PermissionValue { get; set; }

        public Permission(string name, int permissionValue)
        {
            Name = name;
            PermissionValue = permissionValue;
        }
        public Permission(int id, string name, int permissionValue)
        {
            Id = id;
            Name = name;
            PermissionValue = permissionValue;
        }
    }
}
