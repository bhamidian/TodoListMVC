using MaktabToDoList.Domain.Core.Task.Enums;

namespace MaktabToDoList.Domain.Core.Task.DTOs
{
    public class GetTaskItemDTO
    {
        public GetTaskItemDTO() { }

        public GetTaskItemDTO(int id, string title, string categoryName,
            TaskItemStatus taskItemStatus, DateTime start, DateTime? end )
        {
            Id = id;
            Title = title;
            CategoryName = categoryName;
            TaskItemStatus = taskItemStatus;
            Start = start;
            End = end;
        }



        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int CreatorId { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public TaskItemStatus TaskItemStatus { get; set; }
    }
}
