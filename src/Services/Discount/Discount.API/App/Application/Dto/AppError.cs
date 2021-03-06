namespace Discount.API.App.Application.Dto;

public class AppError
{
    public string[] Errors { get; }
    public AppError()
    {
        Errors = Array.Empty<string>();
    }

    public AppError(params string[] errors)
    {
        Errors = errors;
    }
}
