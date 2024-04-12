﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarp.Dasigno.Application.Database.User.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
        Task<CreateUserModel> Execute(CreateUserModel model);
    }
}
