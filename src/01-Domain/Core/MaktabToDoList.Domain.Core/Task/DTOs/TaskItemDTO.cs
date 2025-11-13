namespace MaktabToDoList.Domain.Core.Task.DTOs
{
    public class TaskItemDTO
    {
        public TaskItemDTO() { }

        public TaskItemDTO(
            string title,
            int id,
            int creatorId,
            int? categoryId,
            string description,
            DateTime start,
            DateTime end
        )
        {
            Id = id;
            CategoryId = categoryId;
            CreatorId = creatorId;
            Description = description;
            Title = title;
            Start = start;
            End = end;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? CategoryId { get; set; }
        public int CreatorId { get; set; }
        public TimeSpan? TimeSpent { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string StartDateFa { get; set; }
        public string EndDateFa { get; set; }
        public string? Description { get; set; }
    }
}
