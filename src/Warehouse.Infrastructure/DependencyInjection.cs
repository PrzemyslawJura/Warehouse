﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Application.Common;
using Warehouse.Infrastructure.Common;
using Warehouse.Infrastructure.Products;

namespace BookYourVisit.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddPersistence(configuration);
    }
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WarehouseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddScoped<ITransactionsRepository, TransactionsRepository>();
        services.AddScoped<IWarehouseRacksRepository, WarehouseRacksRepository>();
        services.AddScoped<IWarehousesSizeRepository, WarehousesSizeRepository>();
        services.AddScoped<IWorkersRepository, WorkersRepository>();

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<WarehouseDbContext>());
        return services;
    }
}