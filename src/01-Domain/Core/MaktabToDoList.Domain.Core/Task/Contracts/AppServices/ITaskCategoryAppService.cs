using MaktabToDoList.Domain.Core.Task.DTOs;

namespace MaktabToDoList.Domain.Core.Task.Contracts.AppServices
{
    public interface ITaskCategoryAppService
    {
       List<TaskCategoryDTO> GetAll();
    }
}
