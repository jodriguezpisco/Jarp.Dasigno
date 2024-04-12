using AutoMapper;
using Jarp.Dasigno.Application.DataBase;
using Jarp.Dasigno.Domain.Entities.User;

namespace Jarp.Dasigno.Application.Database.User.Commands.CreateUser
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public CreateUserCommand(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<CreateUserModel> Execute(CreateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);
            entity.FechaCreacion = DateTime.Now;
            entity.FechaModificacion = DateTime.Now;
            await _databaseService.Users.AddAsync(entity);
            await _databaseService.SaveAsync();
            return model;
        }
    }
}
