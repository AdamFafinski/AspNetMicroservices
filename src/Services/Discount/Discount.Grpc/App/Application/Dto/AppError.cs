namespace Discount.Grpc.App.Application.Dto;

public class AppError
{
    public List<string> Errors { get; }

    public void AddError(string error)
    {
        Errors.Add(error);
    }

    public AppError()
    {
        Errors = new();
    }

    public AppError(List<string> errors)
    {
        Errors = errors;
    }

    public AppError(params string[] errors)
    {
        Errors = errors.ToList();
    }
}
