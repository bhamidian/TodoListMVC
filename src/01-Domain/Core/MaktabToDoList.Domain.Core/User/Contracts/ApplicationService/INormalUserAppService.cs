using MaktabToDoList.Domain.Core._common.DTOs;
using MaktabToDoList.Domain.Core.User.DTOs;
using MaktabToDoList.Domain.Core.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabToDoList.Domain.Core.User.Contracts.ApplicationService
{
    public interface INormalUserAppService
    {
        ResultDTO<LoginDTO?> Login(string userName, string password);
        ResultDTO<bool> Register(string userName, string password);
    }
}
