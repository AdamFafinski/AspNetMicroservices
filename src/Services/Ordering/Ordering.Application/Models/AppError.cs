namespace Ordering.Application.Models;
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
