using Discount.API.App.Application.Dto;
using Discount.API.App.Application.Exceptions;
using Discount.API.App.Application.Responses;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Discount.API.App.Presentation.Middleware
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
                        AppResponse<AppError> response;

                        var exception = exceptionHandlerPathFeature?.Error;

                        switch (exception)
                        {
                            case AppException ex:
                                httpStatusCode = ex.HttpStatusCode;
                                response = new AppResponse<AppError>(false, new AppError(ex.Errors));
                                break;

                            default:
                                var messageTemplate = "Internal Server Error.";
                                //LOG EXCEPTION
                                //Log.Error(exception, messageTemplate)
                                httpStatusCode = HttpStatusCode.InternalServerError;
                                response = new AppResponse<AppError>(false, new AppError(exception.Message));
                                //response = new AppResponse<AppError>(false, new AppError(messageTemplate));
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
