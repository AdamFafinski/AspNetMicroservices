namespace Catalog.API.App.Application.Responses;

public class AppResponse
{
    public bool IsSuccess { get; }
    public string Message { get; }

    public AppResponse(bool isSuccess, string message = "")
    {
        IsSuccess = isSuccess;
        Message = message;
    }
}

public class AppResponse<T> : AppResponse
{
    public T Data { get; }
    public AppResponse(bool isSuccess, T data, string message = "") : base(isSuccess, message)
    {
        Data = data;
    }
}
