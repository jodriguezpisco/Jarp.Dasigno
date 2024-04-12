using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Jarp.Dasigno.Application.Database.User.Queries.GetUserByNameOrLastName
{
    public class RequestByFirsNameOrLastName
    {
        public int NumberPage { get; set; }
        public int DataxPage{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
