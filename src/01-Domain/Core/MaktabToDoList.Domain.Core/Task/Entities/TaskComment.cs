using MaktabToDoList.Domain.Core.User.Entities;

namespace MaktabToDoList.Domain.Core.Task.Entities
{
    public class TaskComment
    {
        public TaskComment() { }

        public TaskComment(string text, DateTime postedAt, int taskid, int userid)
        {
            Text = text;
            PostedAt = postedAt;
            NormalUserId = userid;
            TaskItemId = taskid;
        }

        public int Id { get; set; }
        public int NormalUserId { get; set; }
        public NormalUser NormalUser { get; set; }
        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }
        public string Text { get; set; }
        public DateTime PostedAt { get; set; }
    }
}
