using AutoMapper;
using Jarp.Dasigno.Application.Database.User.Commands.CreateUser;
using Jarp.Dasigno.Application.Database.User.Commands.UpdateUser;
using Jarp.Dasigno.Application.Database.User.Queries.GetAllUser;
using Jarp.Dasigno.Application.Database.User.Queries.GetUserById;
using Jarp.Dasigno.Application.Database.User.Queries.GetUserByNameOrLastName;
using Jarp.Dasigno.Domain.Entities.User;

namespace Jarp.Dasigno.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByNameOrLastNameModel>().ReverseMap();
        }
    }
}
