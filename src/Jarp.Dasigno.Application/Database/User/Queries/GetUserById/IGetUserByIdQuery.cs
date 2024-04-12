﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarp.Dasigno.Application.Database.User.Queries.GetUserById
{
    public interface IGetUserByIdQuery
    {
        Task<GetUserByIdModel> Execute(int userId);
    }
}
