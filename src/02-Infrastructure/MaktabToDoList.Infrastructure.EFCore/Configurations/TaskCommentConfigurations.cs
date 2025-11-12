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
    public class TaskCommentConfigurations : IEntityTypeConfiguration<TaskComment>
    {
        public void Configure(EntityTypeBuilder<TaskComment> builder)
        {
            throw new NotImplementedException();
        }
    }
}
