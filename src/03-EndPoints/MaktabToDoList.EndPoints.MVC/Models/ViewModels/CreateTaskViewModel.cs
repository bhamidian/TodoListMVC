using MaktabToDoList.Domain.Core.Task.DTOs;

namespace MaktabToDoList.EndPoints.MVC.Models.ViewModels
{
    public class CreateTaskViewModel
    {
        public TaskCategoryViewModel TaskCategoryViewModel { get; set; }
        public TaskItemViewModel TaskItemViewModel { get; set; }

    }
}
