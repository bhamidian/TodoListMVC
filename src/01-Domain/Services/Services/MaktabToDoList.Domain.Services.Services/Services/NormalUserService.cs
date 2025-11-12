using MaktabToDoList.Domain.Core.User.Contracts.Repositories;
using MaktabToDoList.Domain.Core.User.Contracts.Services;
using MaktabToDoList.Domain.Core.User.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MaktabToDoList.Domain.Services.Services.Services
{
    public class NormalUserService : INormalUserService
    {
        private readonly INormalUserRepository _normalUserRepository;
        public NormalUserService(INormalUserRepository normalUserRepository) => _normalUserRepository = normalUserRepository;
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
