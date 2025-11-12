using MaktabToDoList.Domain.Core.Task.Contracts.Repositories;
using MaktabToDoList.Domain.Core.Task.DTOs;
using MaktabToDoList.Infrastructure.EFCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabToDoList.Infrastructure.EFCore.Repositories
{
    public class TaskCategoryRepository : ITaskCategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public TaskCategoryRepository(AppDbContext dbContext) => _dbContext = dbContext;
        public List<TaskCategoryDTO> GetAll()
        {
            return _dbContext.Categories.Select(c => new TaskCategoryDTO(c.Id, c.Name))
                .ToList();

        }
    }
}
