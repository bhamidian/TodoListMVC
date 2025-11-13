using MaktabToDoList.Domain.Core.Task.DTOs;

namespace MaktabToDoList.Domain.Core.Task.Contracts.Services
{
    public interface ITaskItemService
    {
        bool Create(TaskItemDTO dTO, int creatorId);
        bool Delete(int id);
        bool Update(int id, GetTaskItemDTO dTO);
        bool UpdateStatus(int taskId, int statusId);
        bool IsDelayed();

        List<GetTaskItemDTO> GetAll(int creatorId);

        GetTaskItemDTO? GetTaskById(int id);
        List<GetTaskItemDTO> GetAllByFilters(GetTaskByQueryDTO dTO, int creatorId);


    }
}
