using System;
using System.Collections.Generic;

namespace MaktabToDoList.Domain.Core.Task.Entities
{
    public class TaskCategory
    {
        private TaskCategory() { }
        public TaskCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TaskItem> TaskItems { get; set; } = [];
    }
}
