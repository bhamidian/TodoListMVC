using MaktabToDoList.Domain.Core.User.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabToDoList.Domain.Core.User.Contracts.Repositories
{
    public interface INormalUserRepository
    {
        LoginDTO? Login(string userName, string password);
        bool Register(string userName, string password);

    }
}
