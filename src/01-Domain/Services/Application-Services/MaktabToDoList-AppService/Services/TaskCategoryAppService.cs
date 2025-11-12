using MaktabToDoList.Domain.Core.Task.Contracts.AppServices;
using MaktabToDoList.Domain.Core.Task.Contracts.Services;
using MaktabToDoList.Domain.Core.Task.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabToDoList_AppService.Services
{
    public class TaskCategoryAppService : ITaskCategoryAppService
    {
        private readonly ITaskCategoryService _taskCategoryService;

        public TaskCategoryAppService(ITaskCategoryService taskCategoryService)
        {
            _taskCategoryService = taskCategoryService;
        }
        public List<TaskCategoryDTO> GetAll() => _taskCategoryService.GetAll();


    }
}
