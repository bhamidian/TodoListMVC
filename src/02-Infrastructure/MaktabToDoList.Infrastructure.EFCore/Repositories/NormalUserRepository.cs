using MaktabToDoList.Domain.Core.User.Contracts.Repositories;
using MaktabToDoList.Domain.Core.User.DTOs;
using MaktabToDoList.Domain.Core.User.Entities;
using MaktabToDoList.Infrastructure.EFCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabToDoList.Infrastructure.EFCore.Repositories
{
    public class NormalUserRepository : INormalUserRepository
    {
        private readonly AppDbContext _dbContext;
        public NormalUserRepository(AppDbContext dbContext) => _dbContext = dbContext;

        public LoginDTO? Login(string userName, string password)
        {
            var user = _dbContext.NormalUsers.FirstOrDefault(n => n.UserName == userName && n.Password == password);

            if (user is null)
                return null;

            return new LoginDTO(user.Id,userName, password);
        }

        public bool Register(string userName, string password)
        {
            try
            {
                if (_dbContext.NormalUsers.Any(n => n.UserName == userName))
                {
                    return false;
                }

                var user = new NormalUser(userName, password);

                _dbContext.NormalUsers.Add(user);

                return _dbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                throw new Exception("there was a problem with inserting data" + ex.Message);
            }
            
        }
    }
}
