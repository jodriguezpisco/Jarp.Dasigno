using Jarp.Dasigno.Application.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Jarp.Dasigno.Application.Database.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IDatabaseService _databaseService;

        public DeleteUserCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<bool> Execute(int userId)
        {
            var entity = await _databaseService.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (entity == null)
                return false;

            _databaseService.Users.Remove(entity);
            return await _databaseService.SaveAsync();
        }
    }
}
