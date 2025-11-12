using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabToDoList.Infrastructure.EFCore.InMemoryDatabase
{
    public class OnlineUser
    {
        public OnlineUser() { }

        public OnlineUser(int id, string userName)
        {
            Id = id;
            UserName = userName;
        }

        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        
    }
}
