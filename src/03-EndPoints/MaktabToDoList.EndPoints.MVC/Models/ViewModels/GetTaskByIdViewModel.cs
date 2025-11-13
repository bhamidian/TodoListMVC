using MaktabToDoList.Domain.Core.Task.Enums;

namespace MaktabToDoList.EndPoints.MVC.Models.ViewModels
{
    public class GetTaskByIdViewModel
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string StartDateFa { get; set; }
        public string EndDateFa { get; set; }
        public TaskItemStatus TaskItemStatus { get; set; }
    }
}
