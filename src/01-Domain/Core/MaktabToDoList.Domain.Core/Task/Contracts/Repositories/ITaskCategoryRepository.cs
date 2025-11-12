using MaktabToDoList.Domain.Core.Task.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabToDoList.Domain.Core.Task.Contracts.Repositories
{
    public interface ITaskCategoryRepository
    {
        List<TaskCategoryDTO> GetAll();
    }
}
