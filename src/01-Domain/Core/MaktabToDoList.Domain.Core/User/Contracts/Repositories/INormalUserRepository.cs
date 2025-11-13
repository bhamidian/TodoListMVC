using MaktabToDoList.Domain.Core.User.DTOs;

namespace MaktabToDoList.Domain.Core.User.Contracts.Repositories
{
    public interface INormalUserRepository
    {
        LoginDTO? Login(string userName, string password);
        bool Register(string userName, string password);
    }
}
