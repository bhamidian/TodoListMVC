using MaktabToDoList.Domain.Core.Task.Enums;
using MaktabToDoList.Domain.Core.User.Entities;

namespace MaktabToDoList.Domain.Core.Task.Entities
{
    public class TaskItem
    {
        public TaskItem(string title, string? description, int creatorId,
            int? categoryId, DateTime start, DateTime? end)
        {
            CreatorId = creatorId;
            CategoryId = categoryId;
            Description = description;
            Title = title;
            Start = start;
            End = end;
        }
        public TaskItem()
        {

        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public TaskCategory Category { get; set; }
        public int? CategoryId { get; set; }
        public int CreatorId { get; set; }
        public NormalUser Creator { get; set; }
        //public int? AssigneeId { get; set; }
        //public NormalUser? Assignee { get; set; }
        public List<TaskComment> Comments { get; set; } = [];
        public TimeSpan? TimeSpent { get; set; }
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime? End { get; set; }
        public TaskItemStatus Status { get; set; } = TaskItemStatus.Doing;
        public List<TaskHistory> TaskHistories { get; set; } = [];
    }
}
