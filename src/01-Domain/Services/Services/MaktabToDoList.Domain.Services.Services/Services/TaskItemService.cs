using MaktabToDoList.Domain.Core.Task.Contracts.Repositories;
using MaktabToDoList.Domain.Core.Task.Contracts.Services;
using MaktabToDoList.Domain.Core.Task.DTOs;
using MaktabToDoList.Framework;

namespace MaktabToDoList.Domain.Services.Services.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public TaskItemService(ITaskItemRepository taskItemRepository) =>
            _taskItemRepository = taskItemRepository;

        public bool Create(TaskItemDTO dTO, int creatorId) => _taskItemRepository.Create(dTO,creatorId);

        public bool Delete(int id) => _taskItemRepository.Delete(id);

        public List<GetTaskItemDTO> GetAll(int creatorId)
        {
            var tasks = _taskItemRepository.GetAll(creatorId).ToList();

            tasks.ForEach(task =>
            {
                if (task.Start > DateTime.MinValue)
                    task.StartDateFa = task.Start.ToPersianString("yyyy/MM/dd");

                if (task.End > DateTime.MinValue)
                    task.EndDateFa = task.End.ToPersianString("yyyy/MM/dd");
            });

            return tasks;
        }

        public List<GetTaskItemDTO> GetAllByFilters( GetTaskByQueryDTO dTO, int creatorId)

        => _taskItemRepository.GetAllByFilters(dTO, creatorId);

        public GetTaskItemDTO? GetTaskById(int id)
        {
            var task = _taskItemRepository.GetTaskById(id);

            if (task is null)
                return null;

            task.StartDateFa = task.Start.ToPersianString(("yyyy/MM/dd"));
            task.EndDateFa = task.End.ToPersianString(("yyyy/MM/dd"));

            return task;
        }

        public bool IsDelayed() => _taskItemRepository.IsDelayed();

        public bool Update(int id, GetTaskItemDTO dTO) => _taskItemRepository.Update(id, dTO);

        public bool UpdateStatus(int taskId, int statusId) =>
            _taskItemRepository.UpdateStatus(taskId, statusId);
    }
}
