using MaktabToDoList.Domain.Core.Task.DTOs;

namespace MaktabToDoList.Domain.Core.Task.Contracts.Services
{
    public interface ITaskItemService
    {
        bool Create(TaskItemDTO dTO);
        bool Delete(int id);
        bool Update(int id, GetTaskItemDTO dTO);
        bool UpdateStatus(int taskId, int statusId);
        List<GetTaskItemDTO> GetAll();
        List<GetTaskItemDTO> GetAllByFilters(int? categoryId,int? statusId,DateTime? start = null,DateTime? end = null);
        GetTaskItemDTO? GetTaskById(int id);


    }
}
