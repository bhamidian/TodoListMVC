using MaktabToDoList.Domain.Core.Task.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaktabToDoList.Infrastructure.EFCore.Configurations
{
    public class TaskCategoryConfigurations : IEntityTypeConfiguration<TaskCategory>
    {
        public void Configure(EntityTypeBuilder<TaskCategory> builder)
        {
            builder.HasMany(t => t.TaskItems)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new TaskCategory(1,"شخصی"),
                            new TaskCategory(2,"کاری"),
                            new TaskCategory(3,"دانشگاهی"),
                            new TaskCategory(4,"سایر"));
        }
    }
}
