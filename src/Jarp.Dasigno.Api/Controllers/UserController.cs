using FluentValidation;
using Jarp.Dasigno.Application.Database.User.Commands.CreateUser;
using Jarp.Dasigno.Application.Database.User.Commands.DeleteUser;
using Jarp.Dasigno.Application.Database.User.Commands.UpdateUser;
using Jarp.Dasigno.Application.Database.User.Queries.GetAllUser;
using Jarp.Dasigno.Application.Database.User.Queries.GetUserById;
using Jarp.Dasigno.Application.Database.User.Queries.GetUserByNameOrLastName;
using Jarp.Dasigno.Application.Exceptions;
using Jarp.Dasigno.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Jarp.Dasigno.Api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    [TypeFilter(typeof(ExceptionsManager))]
    public class UserController : ControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserModel model, [FromServices] ICreateUserCommand createUserCommand, [FromServices] IValidator<CreateUserModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiServices.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createUserCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created, ResponseApiServices.Response(StatusCodes.Status201Created, data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserModel model, [FromServices] IUpdateUserCommand updateUserCommand, [FromServices] IValidator<UpdateUserModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiServices.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await updateUserCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiServices.Response(StatusCodes.Status200OK, data));
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> Delete(int userId, [FromServices] IDeleteUserCommand deleteUserCommand)
        {
            if (userId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiServices.Response(StatusCodes.Status400BadRequest));

            var data = await deleteUserCommand.Execute(userId);

            if (!data)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiServices.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiServices.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllUserQuery getAllUserQuery)
        {
            var data = await getAllUserQuery.Execute();

            if (data == null || data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiServices.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiServices.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-id/{userId}")]
        public async Task<IActionResult> GetAllById(int userId, [FromServices] IGetUserByIdQuery getUserByIdQuery)
        {
            if (userId == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiServices.Response(StatusCodes.Status404NotFound));

            var data = await getUserByIdQuery.Execute(userId);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiServices.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiServices.Response(StatusCodes.Status200OK, data));
        }

        [HttpPost("get-by-page-data-name-lastname")]
        public async Task<IActionResult> GetByNameOrLastName([FromBody] RequestByFirsNameOrLastName requestByFirsNameOrLastName,
            [FromServices] IGetUserByNameOrLastNameQuery getUserByNameOrLastNameQuery)
        {
            if (requestByFirsNameOrLastName == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiServices.Response(StatusCodes.Status404NotFound));

            var data = await getUserByNameOrLastNameQuery.Execute(requestByFirsNameOrLastName);

            if (data == null || data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiServices.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiServices.Response(StatusCodes.Status200OK, data));
        }
    }
}
