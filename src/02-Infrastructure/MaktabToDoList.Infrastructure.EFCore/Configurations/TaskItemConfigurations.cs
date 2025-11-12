using MaktabToDoList.Domain.Core.Task.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabToDoList.Infrastructure.EFCore.Configurations
{
    public class TaskItemConfigurations : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasMany(c => c.Comments)
                .WithOne(t => t.TaskItem)
                .HasForeignKey(t => t.TaskItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.TaskHistories)
                .WithOne(i => i.TaskItem)
                .HasForeignKey(i => i.TaskItemId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
