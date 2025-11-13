using MaktabToDoList.Domain.Core.Task.DTOs;

namespace MaktabToDoList.Domain.Core.Task.Contracts.Repositories
{
    public interface ITaskItemRepository
    {
        bool Create(TaskItemDTO dTO,int creatorId);
        bool Delete(int id);
        bool IsDelayed();
        bool Update(int id, GetTaskItemDTO dTO);
        bool UpdateStatus(int taskId, int statusId);
        GetTaskItemDTO? GetTaskById(int id);
        List<GetTaskItemDTO> GetAllByFilters(GetTaskByQueryDTO dTO,int creatorId);
        List<GetTaskItemDTO> GetAll(int creatorId);
        //List<GetTaskItemDTO> GetAllByCategory(int categoryId);
        //List<GetTaskItemDTO> GetAllByStatus(int statusId);
        //List<GetTaskItemDTO> GetAllByDate(DateTime start, DateTime end);



    }
}
