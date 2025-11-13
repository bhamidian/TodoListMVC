using MaktabToDoList.Domain.Core.Task.Contracts.Repositories;
using MaktabToDoList.Domain.Core.Task.DTOs;
using MaktabToDoList.Domain.Core.Task.Entities;
using MaktabToDoList.Domain.Core.Task.Enums;
using MaktabToDoList.Infrastructure.EFCore.InMemoryDatabase;
using MaktabToDoList.Infrastructure.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MaktabToDoList.Infrastructure.EFCore.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly AppDbContext _dbContext;

        public TaskItemRepository(AppDbContext dbContext) => _dbContext = dbContext;

        public bool Create(TaskItemDTO dTO, int creatorId)
        {
            try
            {
                var taskItem = new TaskItem(
                    dTO.Title,
                    dTO.Description,
                    creatorId,
                    dTO.CategoryId,
                    dTO.Start,
                    dTO.End
                );

                _dbContext.TaskItems.Add(taskItem);

                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "There was a problem while entering data to database"
                        + ex.InnerException.Message
                );
            }
        }

        public bool Delete(int id)
        {
            var task = _dbContext.TaskItems.FirstOrDefault(t => t.Id == id);

            if (task is null)
                return false;

            _dbContext.TaskItems.Remove(task);

            return _dbContext.SaveChanges() > 0;
        }

        public List<GetTaskItemDTO> GetAll(int creatorId)
        {
            return _dbContext
                .TaskItems.Where(c => c.CreatorId == creatorId)
                .Select(ta => new GetTaskItemDTO(
                    ta.Id,
                    ta.Title,
                    ta.Category.Name,
                    ta.Status,
                    ta.Start,
                    ta.End
                ))
                .ToList();
        }

        public List<GetTaskItemDTO> GetAllByFilters(GetTaskByQueryDTO dTO, int creatorId)
        {
            IQueryable<TaskItem> query = _dbContext.TaskItems.Where(c => c.CreatorId == creatorId);

            if (dTO.StatusId.HasValue)
                query = query.Where(t => (int)t.Status == dTO.StatusId.Value);

            if (dTO.Start.HasValue)
                query = query.Where(t => t.Start >= dTO.Start.Value);

            if (dTO.End.HasValue)
                query = query.Where(t => t.End <= dTO.End.Value);

            if (dTO.CategoryId.HasValue)
                query = query.Where(t => t.CategoryId == dTO.CategoryId.Value);

            if (!string.IsNullOrWhiteSpace(dTO.Title))
                query = query.Where(t => t.Title.Contains(dTO.Title));

            if (!string.IsNullOrWhiteSpace(dTO.CategoryName))
                query = query.Where(t => t.Category.Name.Contains(dTO.CategoryName));

            if (!string.IsNullOrWhiteSpace(dTO.Sort))
            {
                query = dTO.Sort switch
                {
                    "title-asc" => query.OrderBy(t => t.Title),
                    "title-desc" => query.OrderByDescending(t => t.Title),
                    "due-asc" => query.OrderBy(t => t.End),
                    "due-desc" => query.OrderByDescending(t => t.End),
                    "status-done" => query.OrderByDescending(t => t.Status),
                    "status-notdone" => query.OrderBy(t => t.Status),
                    _ => query.OrderBy(t => t.Id),
                };
            }
            else
            {
                query = query.OrderBy(t => t.Id);
            }

            return query
                .Select(t => new GetTaskItemDTO(
                    t.Id,
                    t.Title,
                    t.Category.Name,
                    t.Status,
                    t.Start,
                    t.End
                ))
                .ToList();
        }

        public bool Update(int id, GetTaskItemDTO dTO)
        {
            var task = _dbContext
                .TaskItems.Where(t => t.Id == id && t.CreatorId == InMemory.OnlineUser.Id)
                .ExecuteUpdate(u =>
                    u.SetProperty(t => t.Title, dTO.Title)
                        .SetProperty(t => t.Description, dTO.Description)
                        .SetProperty(t => t.End, dTO.End)
                        .SetProperty(t => t.CategoryId, dTO.CategoryId)
                        .SetProperty(t => t.Status, dTO.TaskItemStatus)
                );

            return task > 0;
        }

        public GetTaskItemDTO? GetTaskById(int id)
        {
            var task = _dbContext
                .TaskItems.Where(c => c.CreatorId == InMemory.OnlineUser.Id)
                .FirstOrDefault(t => t.Id == id);

            return new GetTaskItemDTO
            {
                Id = task.Id,
                CreatorId = task.CreatorId,
                CategoryId = task.CategoryId,
                Title = task.Title,
                TaskItemStatus = task.Status,
                CategoryName = task.Category.Name,
                Description = task.Description,
                End = task.End,
                Start = task.Start,
            };
        }

        public bool UpdateStatus(int taskId, int statusId)
        {
            var task = _dbContext
                .TaskItems.Where(t => t.Id == taskId)
                .ExecuteUpdate(u => u.SetProperty(t => t.Status, t => (TaskItemStatus)statusId));

            return task > 0;
        }

        public bool IsDelayed()
        {
            var tasks = _dbContext
                .TaskItems.Where(t => t.End < DateTime.Now && t.Status == TaskItemStatus.Doing)
                .ExecuteUpdate(u => u.SetProperty(t => t.Status, t => TaskItemStatus.NotDone));

            return tasks > 0;
        }
    }
}
