using Discount.Grpc.App.Application.Dto;
using Discount.Grpc.App.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Discount.Grpc.App.Presentation.Middleware
{
    public static class ErrorHandlerMiddleware
    {
        public static void AddErrorHandlerMiddleware(this WebApplication app)
        {
            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    if (exceptionHandlerPathFeature != null)
                    {
                        HttpStatusCode httpStatusCode;
                        AppError response;

                        var exception = exceptionHandlerPathFeature?.Error;

                        switch (exception)
                        {
                            case AppException ex:
                                httpStatusCode = ex.HttpStatusCode;
                                response = new AppError(ex.Errors);
                                break;

                            default:
                                var messageTemplate = "Internal Server Error.";
                                //LOG EXCEPTION
                                //Log.Error(exception, messageTemplate)
                                httpStatusCode = HttpStatusCode.InternalServerError;
                                response = new AppError(exception.Message);
                                break;
                        }
                        
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = (int)httpStatusCode;

                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });
        }
    }
}
