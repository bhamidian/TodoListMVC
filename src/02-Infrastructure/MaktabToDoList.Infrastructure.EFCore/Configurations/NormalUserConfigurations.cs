using MaktabToDoList.Domain.Core.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabToDoList.Infrastructure.EFCore.Configurations
{
    public class NormalUserConfigurations : IEntityTypeConfiguration<NormalUser>
    {
        public void Configure(EntityTypeBuilder<NormalUser> builder)
        {
            builder.HasMany(t => t.Tasks)
                .WithOne(c => c.Creator)
                .HasForeignKey(c => c.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Comments)
                .WithOne(c => c.NormalUser)
                .HasForeignKey(n => n.NormalUserId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
