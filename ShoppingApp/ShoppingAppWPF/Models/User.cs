using Chevalier.Utility.Authentication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppWPF.Models
{
    internal class User
    {
        public int Id { get; }
        public string Username { get; }
        public HashedPassword Password { get; }
        public string Name { get; }

        public User(string username, HashedPassword password,  string name)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public User() { }
    }
}
