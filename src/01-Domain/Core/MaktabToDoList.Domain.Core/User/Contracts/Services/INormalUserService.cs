using MaktabToDoList.Domain.Core.User.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabToDoList.Domain.Core.User.Contracts.Services
{
    public interface INormalUserService
    {
        LoginDTO? Login(string userName, string password);
        bool Register(string userName, string password);
    }
}
