using MaktabToDoList.Domain.Core.User.DTOs;

namespace MaktabToDoList.Domain.Core.User.Contracts.Services
{
    public interface INormalUserService
    {
        LoginDTO? Login(string userName, string password);
        bool Register(string userName, string password);
    }
}
