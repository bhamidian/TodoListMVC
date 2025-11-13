using MaktabToDoList.Domain.Core.Task.Contracts.Repositories;
using MaktabToDoList.Domain.Core.Task.Contracts.Services;
using MaktabToDoList.Domain.Core.Task.DTOs;

namespace MaktabToDoList.Domain.Services.Services.Services
{
    public class TaskCategoryService : ITaskCategoryService
    {
        private readonly ITaskCategoryRepository _taskCategoryRepository;

        public TaskCategoryService(ITaskCategoryRepository taskCategoryRepository) =>
            _taskCategoryRepository = taskCategoryRepository;

        public List<TaskCategoryDTO> GetAll() => _taskCategoryRepository.GetAll();
    }
}
