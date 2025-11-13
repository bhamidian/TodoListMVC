using MaktabToDoList.Domain.Core._common.DTOs;
using MaktabToDoList.Domain.Core.Task.DTOs;

namespace MaktabToDoList.Domain.Core.Task.Contracts.AppServices
{
    public interface ITaskItemAppService
    {
        ResultDTO<bool> Create(TaskItemDTO dTO,int creatorId);
        ResultDTO<bool> Delete(int id);
        ResultDTO<bool> Update(int id, GetTaskItemDTO dTO);
        ResultDTO<bool> UpdateStatus(int taskId, int statusId);

        List<GetTaskItemDTO> GetAll(int creatorId);
        List<GetTaskItemDTO> GetAllByFilters(GetTaskByQueryDTO dTO, int creatorId);

        ResultDTO<GetTaskItemDTO?> GetTaskById(int id);



    }
}
