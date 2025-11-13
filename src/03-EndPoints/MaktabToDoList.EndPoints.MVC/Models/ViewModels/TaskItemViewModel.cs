using MaktabToDoList.Domain.Core.Task.Enums;

namespace MaktabToDoList.EndPoints.MVC.Models.ViewModels
{
    public class TaskItemViewModel
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int? CategoryId { get; set; }
        public string? Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TaskItemStatus TaskItemStatus { get; set; }
        public TimeSpan? TimeSpent { get; set; }
    }
}
