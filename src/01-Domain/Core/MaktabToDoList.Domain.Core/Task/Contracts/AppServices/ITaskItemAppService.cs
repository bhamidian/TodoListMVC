using MaktabToDoList.Domain.Core._common.DTOs;
using MaktabToDoList.Domain.Core.Task.DTOs;

namespace MaktabToDoList.Domain.Core.Task.Contracts.AppServices
{
    public interface ITaskItemAppService
    {
        ResultDTO<bool> Create(TaskItemDTO dTO);
        ResultDTO<bool> Delete(int id);
        ResultDTO<bool> Update(int id, GetTaskItemDTO dTO);
        ResultDTO<bool> UpdateStatus(int taskId, int statusId);
        List<GetTaskItemDTO> GetAll();
        List<GetTaskItemDTO> GetAllByFilters(int? categoryId, int? statusId, DateTime? start = null, DateTime? end = null);
        ResultDTO<GetTaskItemDTO?> GetTaskById(int id);



    }
}
