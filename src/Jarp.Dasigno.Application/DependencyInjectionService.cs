using AutoMapper;
using FluentValidation;
using Jarp.Dasigno.Application.Configuration;
using Jarp.Dasigno.Application.Database.User.Commands.CreateUser;
using Jarp.Dasigno.Application.Database.User.Commands.DeleteUser;
using Jarp.Dasigno.Application.Database.User.Commands.UpdateUser;
using Jarp.Dasigno.Application.Database.User.Queries.GetAllUser;
using Jarp.Dasigno.Application.Database.User.Queries.GetUserById;
using Jarp.Dasigno.Application.Database.User.Queries.GetUserByNameOrLastName;
using Jarp.Dasigno.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Jarp.Dasigno.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapper.CreateMapper());
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IGetAllUserQuery, GetAllUserQuery>();
            services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>();
            services.AddTransient<IGetUserByNameOrLastNameQuery, GetUserByNameOrLastNameQuery>();

            services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator>();
            services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidator>();

            return services;
        }
    }
}
