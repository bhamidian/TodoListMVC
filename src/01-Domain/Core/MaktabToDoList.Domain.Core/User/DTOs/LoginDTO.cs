using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabToDoList.Domain.Core.User.DTOs
{
    public class LoginDTO
    {
        public LoginDTO(int id ,string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }

        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
