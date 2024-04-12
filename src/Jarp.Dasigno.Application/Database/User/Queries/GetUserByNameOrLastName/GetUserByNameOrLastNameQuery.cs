using AutoMapper;
using Jarp.Dasigno.Application.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Jarp.Dasigno.Application.Database.User.Queries.GetUserByNameOrLastName
{
    public class GetUserByNameOrLastNameQuery : IGetUserByNameOrLastNameQuery
    {
        private readonly IDatabaseService _databaseService;
        public GetUserByNameOrLastNameQuery(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
        }

        public async Task<List<GetUserByNameOrLastNameModel>> Execute(RequestByFirsNameOrLastName requestByFirsNameOrLastName)
        {
            var query = _databaseService.Users.AsQueryable();

            if (!string.IsNullOrEmpty(requestByFirsNameOrLastName.FirstName))
            {
                query = query.Where(u => u.PrimerNombre.Contains(requestByFirsNameOrLastName.FirstName));
            }

            if (!string.IsNullOrEmpty(requestByFirsNameOrLastName.LastName))
            {
                query = query.Where(u => u.PrimerApellido.Contains(requestByFirsNameOrLastName.LastName));
            }

            // se aplican parametros de No. pagina y registros x pagina
            var users = await query.Skip((requestByFirsNameOrLastName.NumberPage - 1) * requestByFirsNameOrLastName.DataxPage).Take(requestByFirsNameOrLastName.DataxPage).ToListAsync();

            // Mapear los usuarios a GetUserByNameOrLastNameModel
            var result = users.Select(u => new GetUserByNameOrLastNameModel
            {
                Id = u.Id,
                PrimerNombre = u.PrimerNombre,
                SegundoNombre = u.SegundoNombre,
                PrimerApellido = u.PrimerApellido,
                SegundoApellido = u.SegundoApellido,
                FechaNacimiento = u.FechaNacimiento,
                Sueldo = u.Sueldo,
                FechaCreacion = u.FechaCreacion,
                FechaModificacion = u.FechaModificacion
            }).ToList();

            return result;
        }
    }
}
