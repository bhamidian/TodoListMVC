using MaktabToDoList.Domain.Core.Task.Entities;

namespace MaktabToDoList.Domain.Core.User.Entities
{
    public class NormalUser
    {
        public NormalUser() { }

        public NormalUser(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        public List<TaskComment> Comments { get; set; } = new List<TaskComment>();
    }
}
