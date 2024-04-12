using Jarp.Dasigno.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarp.Dasigno.Application.DataBase
{
    public interface IDatabaseService
    {
        DbSet<UserEntity> Users { get; set; }
        Task<bool> SaveAsync();
    }
}
