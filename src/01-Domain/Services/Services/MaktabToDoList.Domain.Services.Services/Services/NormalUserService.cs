using MaktabToDoList.Domain.Core.User.Contracts.Repositories;
using MaktabToDoList.Domain.Core.User.Contracts.Services;
using MaktabToDoList.Domain.Core.User.DTOs;

namespace MaktabToDoList.Domain.Services.Services.Services
{
    public class NormalUserService : INormalUserService
    {
        private readonly INormalUserRepository _normalUserRepository;

        public NormalUserService(INormalUserRepository normalUserRepository) =>
            _normalUserRepository = normalUserRepository;

        public LoginDTO? Login(string userName, string password)
        {
            return _normalUserRepository.Login(userName, password);
        }

        public bool Register(string userName, string password)
        {
            return _normalUserRepository.Register(userName, password);
        }
    }
}
