using MaktabToDoList.Domain.Core.Task.Contracts.Repositories;
using MaktabToDoList.Domain.Core.Task.DTOs;
using MaktabToDoList.Infrastructure.EFCore.Persistence;

namespace MaktabToDoList.Infrastructure.EFCore.Repositories
{
    public class TaskCategoryRepository : ITaskCategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public TaskCategoryRepository(AppDbContext dbContext) => _dbContext = dbContext;

        public List<TaskCategoryDTO> GetAll()
        {
            return _dbContext.Categories.Select(c => new TaskCategoryDTO(c.Id, c.Name)).ToList();
        }
    }
}
