using MaktabToDoList.Domain.Core.Task.Contracts.Repositories;
using MaktabToDoList.Domain.Core.Task.DTOs;
using MaktabToDoList.Domain.Core.Task.Entities;
using MaktabToDoList.Domain.Core.Task.Enums;
using MaktabToDoList.Infrastructure.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabToDoList.Infrastructure.EFCore.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly AppDbContext _dbContext;

        public TaskItemRepository(AppDbContext dbContext) => _dbContext = dbContext;
        public bool Create(TaskItemDTO dTO)
        {
            try
            {
                var taskItem = new TaskItem(dTO.Title,dTO.Description, dTO.CreatorId,
                    dTO.CategoryId,dTO.Start, dTO.End);

                _dbContext.TaskItems.Add(taskItem);

                return _dbContext.SaveChanges() > 0;
            }

            catch (Exception ex)
            {
                throw new Exception("There was a problem while entering data to database" 
                    + ex.InnerException.Message);
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

        public List<GetTaskItemDTO> GetAll()
        {
            return _dbContext.TaskItems
                .Select(ta => new GetTaskItemDTO(ta.Id, ta.Title, ta.Category.Name, ta.Status,
                ta.Start, ta.End)).ToList();

            
        }

        public List<GetTaskItemDTO> GetAllByCategory(int categoryId)
        {
            return _dbContext.TaskItems.Where(c => c.CategoryId == categoryId)
                .Select(c => new GetTaskItemDTO(
                    c.Id,
                    c.Title,
                    c.Category.Name,
                    c.Status,
                    c.Start,
                    c.End
                    
                ))
                .ToList();
        }

        public List<GetTaskItemDTO> GetAllByDate(DateTime start, DateTime end)
        {
            return _dbContext.TaskItems.Where(d => d.Start >= start && d.End <= end )
                .Select(d => new GetTaskItemDTO(
                    d.Id,
                    d.Title,
                    d.Category.Name,
                    d.Status,
                    d.Start,
                    d.End

                ))
                .ToList();
        }

        public List<GetTaskItemDTO> GetAllByStatus(int statusId)
        {
            return _dbContext.TaskItems
                .Where(c => (int)c.Status == statusId)
                .Select(c => new GetTaskItemDTO(
                    c.Id,
                    c.Title,
                    c.Category.Name,
                    c.Status,
                    c.Start,
                    c.End
                ))
                .ToList();
        }

        public List<GetTaskItemDTO> GetAllByFilters
            (int? categoryId,
            int? statusId,
            DateTime? start = null,
            DateTime? end = null)
        {
            IQueryable<TaskItem> query = _dbContext.TaskItems;

            if (statusId.HasValue)
                query = query.Where(t => (int)t.Status == statusId);

            if (start.HasValue)
                query = query.Where(t => t.Start >= start);

            if (end.HasValue)
                query = query.Where(t => t.End <= end);

            if (categoryId.HasValue)
                query = query.Where(t => t.CategoryId == categoryId);

            return query
                .Select(t => new GetTaskItemDTO(
                t.Id,
                t.Title,
                t.Category.Name,
                t.Status,
                t.Start,
                t.End))
                .ToList();







        }


        public bool Update(int id,GetTaskItemDTO dTO)
        {
            var task = _dbContext.TaskItems
                .Where(t => t.Id == id)
                .ExecuteUpdate(u => u
                .SetProperty(t => t.Title, dTO.Title)
                .SetProperty(t => t.Description, dTO.Description)
                .SetProperty(t => t.End, dTO.End)
                .SetProperty(t => t.CategoryId,dTO.CategoryId)
                .SetProperty(t => t.Status, dTO.TaskItemStatus));

            return task > 0;
                
                




        }

        public GetTaskItemDTO? GetTaskById(int id)
        {
            var task = _dbContext.TaskItems.FirstOrDefault(t => t.Id == id);

            return 
                new GetTaskItemDTO
            {
                Id = task.Id,
                CreatorId = task.CreatorId,
                CategoryId = task.CategoryId,
                Title = task.Title,
                TaskItemStatus = task.Status,
                CategoryName = task.Category.Name,
                Description = task.Description,
                End = task.End,
                Start = task.Start

            };



            

                

        }

        public bool UpdateStatus(int taskId, int statusId)
        {
            var task = _dbContext.TaskItems
                .Where(t => t.Id == taskId)
                .ExecuteUpdate(u => u
                .SetProperty(t => t.Status, t => (TaskItemStatus)statusId));

            return task > 0;
        }


    }
}
