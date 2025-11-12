using MaktabToDoList.Domain.Core.Task.DTOs;

namespace MaktabToDoList.Domain.Core.Task.Contracts.Repositories
{
    public interface ITaskItemRepository
    {
        bool Create(TaskItemDTO dTO);
        bool Delete(int id);
        bool Update(int id, GetTaskItemDTO dTO);
        bool UpdateStatus(int taskId, int statusId);
        GetTaskItemDTO? GetTaskById(int id);
        List<GetTaskItemDTO> GetAll();
        List<GetTaskItemDTO> GetAllByCategory(int categoryId);
        List<GetTaskItemDTO> GetAllByStatus(int statusId);
        List<GetTaskItemDTO> GetAllByDate(DateTime start, DateTime end);
        List<GetTaskItemDTO> GetAllByFilters(int? categoryId,int? statusId,DateTime? start = null, DateTime? end = null);



    }
}
