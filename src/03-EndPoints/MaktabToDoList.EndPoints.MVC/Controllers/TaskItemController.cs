using MaktabToDoList.Domain.Core.Task.Contracts.AppServices;
using MaktabToDoList.Domain.Core.Task.DTOs;
using MaktabToDoList.EndPoints.MVC.Models.ViewModels;
using MaktabToDoList.Infrastructure.EFCore.InMemoryDatabase;
using Microsoft.AspNetCore.Mvc;

public class TaskItemController : Controller
{
    private readonly ITaskItemAppService _taskItemAppService;
    private readonly ITaskCategoryAppService _taskCategoryAppService;

    public TaskItemController(
        ITaskItemAppService taskItemAppService,
        ITaskCategoryAppService taskCategoryAppService
    )
    {
        _taskItemAppService = taskItemAppService;
        _taskCategoryAppService = taskCategoryAppService;
    }

    [HttpGet]
    public IActionResult Index(GetAllTaskItemsViewModel model)
    {
        model.GetAllTasks = _taskItemAppService.GetAll(InMemory.OnlineUser.Id);

        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var model = new CreateTaskViewModel
        {
            TaskItemViewModel = new TaskItemViewModel(),

            TaskCategoryViewModel = new TaskCategoryViewModel
            {
                taskCategories = _taskCategoryAppService.GetAll(),
            },
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Create(CreateTaskViewModel model)
    {
        model.TaskItemViewModel.CreatorId = InMemory.OnlineUser.Id;

        var taskItem = new TaskItemDTO(
            model.TaskItemViewModel.Title,
            model.TaskItemViewModel.Id,
            model.TaskItemViewModel.CreatorId,
            model.TaskItemViewModel.CategoryId,
            model.TaskItemViewModel.Description,
            model.TaskItemViewModel.Start,
            model.TaskItemViewModel.End
        );

        var task = _taskItemAppService.Create(taskItem,InMemory.OnlineUser.Id);

        if (task.IsSuccess)
        {
            TempData["Message"] = task.Message;
            return RedirectToAction("Index");
        }

        model.TaskCategoryViewModel = new TaskCategoryViewModel
        {
            taskCategories = _taskCategoryAppService.GetAll(),
        };

        ViewBag.Error = task.Message;
        return View("Index", model);
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var taskDto = _taskItemAppService.GetTaskById(id);

        if (taskDto is null)
            return NotFound();

        var taskVm = new GetTaskByIdViewModel
        {
            Id = taskDto.Data.Id,
            Title = taskDto.Data.Title,
            Description = taskDto.Data.Description,
            EndDateFa = taskDto.Data.EndDateFa,
            CategoryId = taskDto.Data.CategoryId,
            CreatorId = InMemory.OnlineUser.Id,
        };

        var categories = _taskCategoryAppService.GetAll();

        var model = new UpdateTaskViewModel
        {
            GetTaskByIdViewModel = taskVm,
            TaskCategoryViewModel = new TaskCategoryViewModel { taskCategories = categories },
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Update(UpdateTaskViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var dto = new GetTaskItemDTO
        {
            Id = model.GetTaskByIdViewModel.Id,
            Title = model.GetTaskByIdViewModel.Title,
            Description = model.GetTaskByIdViewModel.Description,
            TaskItemStatus = model.GetTaskByIdViewModel.TaskItemStatus,
            StartDateFa = model.GetTaskByIdViewModel.StartDateFa,
            EndDateFa = model.GetTaskByIdViewModel.EndDateFa,
            CategoryId = model.GetTaskByIdViewModel.CategoryId,
        };

        _taskItemAppService.Update(dto.Id, dto);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult UpdateStatus(int taskId, int statusId)
    {
        var taskStatus = _taskItemAppService.UpdateStatus(taskId, statusId);

        if (taskStatus.IsSuccess)
        {
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult GetAllByFilters(GetTaskByQueryViewModel model)
    {

        var dTo = new GetTaskByQueryDTO
        {
            CategoryId = model.CategoryId,
            StatusId = model.StatusId,
            Title = model.Title,
            Sort = model.Sort,
            Start = model.Start,
            End = model.End
        };


        var tasks = _taskItemAppService.GetAllByFilters(dTo, InMemory.OnlineUser.Id);

        var finalModel = new GetAllTaskItemsViewModel { GetAllTasks = tasks };

        return View("Index", finalModel);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var task = _taskItemAppService.Delete(id);

        if (task.IsSuccess)
        {
            TempData["Delete"] = task.Message;
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index");
    }
}
