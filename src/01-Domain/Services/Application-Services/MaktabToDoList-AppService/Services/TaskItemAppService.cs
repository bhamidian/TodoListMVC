using MaktabToDoList.Domain.Core._common.DTOs;
using MaktabToDoList.Domain.Core.Task.Contracts.AppServices;
using MaktabToDoList.Domain.Core.Task.Contracts.Services;
using MaktabToDoList.Domain.Core.Task.DTOs;

namespace MaktabToDoList_AppService.Services
{
    public class TaskItemAppService : ITaskItemAppService
    {
        private readonly ITaskItemService _taskItemService;

        public TaskItemAppService(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        public ResultDTO<bool> Create(TaskItemDTO dTO, int creatorId)
        {
            if (_taskItemService.Create(dTO, creatorId))
            {
                return ResultDTO<bool>.Success("تسک با موفقیت اضافه شد");
            }

            return ResultDTO<bool>.Fail("مشکلی در افزودن تسک به وجود امد");
        }

        public ResultDTO<bool> Delete(int id)
        {
            return _taskItemService.Delete(id)
                ? ResultDTO<bool>.Success("حذف با موفقیت انجام شد")
                : ResultDTO<bool>.Fail("مشکلی در فرایند حذف به وجود امد");
        }

        public List<GetTaskItemDTO> GetAll(int creatorId)
        {
            _taskItemService.IsDelayed();

            return _taskItemService.GetAll(creatorId);
        }

        public List<GetTaskItemDTO> GetAllByFilters(GetTaskByQueryDTO dTO, int creatorId)
        {
            _taskItemService.IsDelayed();

            return _taskItemService.GetAllByFilters(dTO, creatorId);
        }

        public ResultDTO<GetTaskItemDTO?> GetTaskById(int id)
        {
            var task = _taskItemService.GetTaskById(id);

            if (task is null)
                return ResultDTO<GetTaskItemDTO?>.Fail(message: "تسک پیدا نشد");

            return ResultDTO<GetTaskItemDTO?>.Success("", task);
        }

        public ResultDTO<bool> Update(int id, GetTaskItemDTO dTO)
        {
            var task = _taskItemService.Update(id, dTO);

            if (task is false)
                return ResultDTO<bool>.Fail("اپدیت موفقیت امیز نبود");

            return ResultDTO<bool>.Success("تسک با موفقیت تغییر یافت");
        }

        public ResultDTO<bool> UpdateStatus(int taskId, int statusId)
        {
            var status = _taskItemService.UpdateStatus(taskId, statusId);

            if (status)
                return ResultDTO<bool>.Success("وضعیت تغییر کرد");

            return ResultDTO<bool>.Fail("مشکلی در تغییر وضعیت به وجود امد");
        }
    }
}
