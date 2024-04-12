using Jarp.Dasigno.Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarp.Dasigno.Persistence.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.PrimerNombre).HasMaxLength(50);
            entityBuilder.Property(x => x.SegundoNombre).HasMaxLength(50).IsRequired(false);
            entityBuilder.Property(x => x.PrimerApellido).HasMaxLength(50);
            entityBuilder.Property(x => x.SegundoApellido).HasMaxLength(50).IsRequired(false);
            entityBuilder.Property(x => x.FechaNacimiento);
            entityBuilder.Property(x => x.Sueldo);
            entityBuilder.Property(x => x.FechaCreacion);
            entityBuilder.Property(x => x.FechaModificacion);
        }
    }
}
