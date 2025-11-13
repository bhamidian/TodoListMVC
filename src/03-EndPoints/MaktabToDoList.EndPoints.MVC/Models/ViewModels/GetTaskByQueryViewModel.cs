namespace MaktabToDoList.EndPoints.MVC.Models.ViewModels
{
    public class GetTaskByQueryViewModel
    {
        public int? CategoryId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? Start { get; set; } = null;
        public DateTime? End { get; set; } = null;
        public string? Title { get; set; } = null;
        public string? Sort { get; set; } = null;
        public string? CategoryName { get; set; } = null;
    }
}
