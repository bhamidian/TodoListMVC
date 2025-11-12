using MaktabToDoList.Domain.Core._common.DTOs;
using MaktabToDoList.Domain.Core.User.Contracts.ApplicationService;
using MaktabToDoList.Domain.Core.User.Contracts.Services;
using MaktabToDoList.Domain.Core.User.DTOs;

namespace MaktabToDoList_AppService.Services
{
    public class NormalUserAppService : INormalUserAppService
    {
        private readonly INormalUserService _normalUserService;
        public NormalUserAppService(INormalUserService normalUserService) => _normalUserService = normalUserService;


        public ResultDTO<LoginDTO?> Login(string userName, string password)
        {
            var normalUser = _normalUserService.Login(userName, password);
            
            if (normalUser is not null)
            {
                return ResultDTO<LoginDTO?>.Success(message: "با موفقیت وارد شدید", data: normalUser);
            }

            return ResultDTO<LoginDTO?>.Fail(message: "رمز عبور یا نام کاربری اشتباه است");
        }


        public ResultDTO<bool> Register(string userName, string password)
        {
            var normalUser = _normalUserService.Register(userName, password);

            if (normalUser is true)
            {
                return ResultDTO<bool>.Success(message: "ثبت نام با موفقیت انجام شد");
            }

            return ResultDTO<bool>.Fail(message: "مشکلی در ثبت نام شما وجود دارد");
        }
    }
}
