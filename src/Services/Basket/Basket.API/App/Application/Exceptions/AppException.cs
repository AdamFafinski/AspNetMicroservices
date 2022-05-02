using System.Net;

namespace Basket.API.App.Application.Exceptions;

public class AppException : Exception
{
    public HttpStatusCode HttpStatusCode { get; }
    public string[] Errors { get; }

    public AppException(HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest, params string[] errors)
    {
        HttpStatusCode = httpStatusCode;
        Errors = errors;
    }
}
