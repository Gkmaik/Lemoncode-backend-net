﻿using appServiceAbstractions = BookManager.Application.Abstractions.Services;
using appQueryServiceAbstractions = BookManager.Application.Abstractions.Queries;
using AppServices = BookManager.Application.Services;
using AppQueryServices = BookManager.Application.Queries;
using BookManager.Domain.Abstractions.Repositories;
using BookManager.DataAccess.Repositories;
using BookManager.Application.Config;

namespace BookManager.Extensions;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddMappings(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(
            typeof(BookManager.DataAccess.MappingProfiles.AuthorMappingProfile).Assembly);

        return serviceCollection;
    }


    public static IServiceCollection AddInfraServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddScoped<IAuthorRepository, AuthorRepository>();
        return serviceCollection;
    }

    public static IServiceCollection AddConfigurations(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<DapperConfig>(configuration.GetSection(DapperConfig.ConfigurationSection));
        return serviceCollection;
    }


    public static IServiceCollection AddAppServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<appServiceAbstractions.IAuthorService, AppServices.AuthorService>();
        serviceCollection.AddScoped<appQueryServiceAbstractions.IAuthorQueriesService, AppQueryServices.AuthorQueriesService>();

        return serviceCollection;
    }

}