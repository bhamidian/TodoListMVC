using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabToDoList.Infrastructure.EFCore.InMemoryDatabase
{
    public static class InMemory
    {
        public static OnlineUser? OnlineUser { get; set; } = new OnlineUser();
    }
}
