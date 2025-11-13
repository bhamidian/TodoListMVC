using MaktabToDoList.Domain.Core.Task.Enums;

namespace MaktabToDoList.Domain.Core.Task.Entities
{
    public class TaskHistory
    {
        public TaskHistory() { }

        //public static TaskHistory LogHistory(TaskItem task)
        //{
        //    return new TaskHistory
        //    {
        //        TaskItemId = task.Id,
        //        TimeSpent = task.TimeSpent,
        //        Description = task.Description,
        //        Status = task.Status,
        //        ChangedAt = DateTime.Now
        //    };
        //}
        public int Id { get; set; }
        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }
        public TimeSpan TimeSpent { get; set; }
        public string Description { get; set; }
        public TaskItemStatus Status { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}
