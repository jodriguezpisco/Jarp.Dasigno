using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarp.Dasigno.Application.Database.User.Queries.GetUserByNameOrLastName
{
    public interface IGetUserByNameOrLastNameQuery
    {
        Task<List<GetUserByNameOrLastNameModel>> Execute(RequestByFirsNameOrLastName requestByFirsNameOrLastName);
    }
}
