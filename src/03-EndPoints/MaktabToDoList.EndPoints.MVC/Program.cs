using MaktabToDoList.Domain.Core.Task.Contracts.AppServices;
using MaktabToDoList.Domain.Core.Task.Contracts.Repositories;
using MaktabToDoList.Domain.Core.Task.Contracts.Services;
using MaktabToDoList.Domain.Core.User.Contracts.ApplicationService;
using MaktabToDoList.Domain.Core.User.Contracts.Repositories;
using MaktabToDoList.Domain.Core.User.Contracts.Services;
using MaktabToDoList.Domain.Services.Services.Services;
using MaktabToDoList.Infrastructure.EFCore.Persistence;
using MaktabToDoList.Infrastructure.EFCore.Repositories;
using MaktabToDoList_AppService.Services;

namespace MaktabToDoList.EndPoints.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<INormalUserRepository, NormalUserRepository>();
            builder.Services.AddScoped<INormalUserService, NormalUserService>();
            builder.Services.AddScoped<INormalUserAppService, NormalUserAppService>();
            builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();
            builder.Services.AddScoped<ITaskItemService, TaskItemService>();
            builder.Services.AddScoped<ITaskItemAppService, TaskItemAppService>();
            builder.Services.AddScoped<ITaskCategoryRepository, TaskCategoryRepository>();
            builder.Services.AddScoped<ITaskCategoryService, TaskCategoryService>();
            builder.Services.AddScoped<ITaskCategoryAppService, TaskCategoryAppService>();
            builder.Services.AddScoped<AppDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
