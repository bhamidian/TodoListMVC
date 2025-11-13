using MaktabToDoList.Domain.Core._common.DTOs;
using MaktabToDoList.Domain.Core.User.DTOs;

namespace MaktabToDoList.Domain.Core.User.Contracts.ApplicationService
{
    public interface INormalUserAppService
    {
        ResultDTO<LoginDTO?> Login(string userName, string password);
        ResultDTO<bool> Register(string userName, string password);
    }
}
