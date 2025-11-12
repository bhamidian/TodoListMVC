using MaktabToDoList.Domain.Core.Task.Contracts.Repositories;
using MaktabToDoList.Domain.Core.Task.Contracts.Services;
using MaktabToDoList.Domain.Core.Task.DTOs;

namespace MaktabToDoList.Domain.Services.Services.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public TaskItemService(ITaskItemRepository taskItemRepository)

            => _taskItemRepository = taskItemRepository;

        public bool Create(TaskItemDTO dTO) => _taskItemRepository.Create(dTO);

        public bool Delete(int id) => _taskItemRepository.Delete(id);

        public List<GetTaskItemDTO> GetAll() => _taskItemRepository.GetAll();
        public List<GetTaskItemDTO> GetAllByFilters(int? categoryId, int? statusId, DateTime? start = null, DateTime? end = null)
            => _taskItemRepository.GetAllByFilters(categoryId, statusId, start, end);

        public GetTaskItemDTO? GetTaskById(int id) => _taskItemRepository.GetTaskById(id);

        public bool Update(int id, GetTaskItemDTO dTO) => _taskItemRepository.Update(id, dTO);

        public bool UpdateStatus(int taskId, int statusId) => _taskItemRepository.UpdateStatus(taskId, statusId);

    }
}
