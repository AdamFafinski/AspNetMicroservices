using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Behaviours;
using System.Reflection;

namespace Ordering.Application;
public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())

            .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
