using Jarp.Dasigno.Application.DataBase;
using Jarp.Dasigno.Domain.Entities.User;
using Jarp.Dasigno.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarp.Dasigno.Persistence.DataBase
{
    public class DataBaseService : DbContext, IDatabaseService
    {
        public DataBaseService(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserEntity> Users { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }
        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new UserConfiguration(modelBuilder.Entity<UserEntity>());   
        }
    }
}
