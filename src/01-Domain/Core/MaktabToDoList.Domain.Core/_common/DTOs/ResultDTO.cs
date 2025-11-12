namespace MaktabToDoList.Domain.Core._common.DTOs
{
    public class ResultDTO<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }

        public static ResultDTO<T> Success(string message, T? data = default) =>
             new() { IsSuccess = true, Message = message, Data = data };

        public static ResultDTO<T> Fail(string message, T? data = default) =>
            new() { IsSuccess = false, Message = message, Data = data };
    }
}
