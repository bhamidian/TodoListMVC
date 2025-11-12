using MaktabToDoList.Domain.Core.Task.DTOs;

namespace MaktabToDoList.EndPoints.MVC.Models.ViewModels
{
    public class GetAllTaskItemsViewModel
    {
        public List<GetTaskItemDTO> GetAllTasks { get; set; }
    }
}
