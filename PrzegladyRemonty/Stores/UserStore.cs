using PrzegladyRemonty.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrzegladyRemonty.Stores
{
    public class UserStore
    {
        private readonly ObservableCollection<Permission> _permissions;
        public Person User { get; set; }
        public IEnumerable<Permission> Permissions => _permissions;

        public UserStore()
        {
            _permissions = new ObservableCollection<Permission>();
        }

        public void AddPermission(Permission permission)
        {
            _permissions.Add(permission);
        }
    }
}
