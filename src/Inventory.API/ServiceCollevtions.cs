using FluentValidation;
using Inventory.Application.Behaviors;
using Inventory.Application.Validators;
using Inventory.Domain.AggregatesModel.SupplierAggregate;
using Inventory.Infrastructure;
using Inventory.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Supplier.API;

public static class ServiceCollections
{
    public static void AddRepositories(this IHostApplicationBuilder builder)
    {
        builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();
    }

    public static void AddDatabase(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<InventoryDbContext>((serviceProvider, options) =>
        {
            var mediator = serviceProvider.GetService<IMediator>();
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
    }

    public static void AddBehaviors(this IHostApplicationBuilder builder)
    {
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
    }

    public static void AddMediatR(this IHostApplicationBuilder builder)
    {
        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(Inventory.Application.Commands.CreateSupplierCommand).Assembly));
    }

    public static void AddValidation(this IHostApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssemblyContaining<CreateSupplierValidator>();
    }
}
