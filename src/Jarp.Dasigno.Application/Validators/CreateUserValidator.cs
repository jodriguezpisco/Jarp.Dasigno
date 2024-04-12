using FluentValidation;
using Jarp.Dasigno.Application.Database.User.Commands.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarp.Dasigno.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.PrimerNombre)
                .NotNull()
                .NotEmpty().WithMessage("El campo PrimerNombre es obligatorio")
                .MaximumLength(50).WithMessage("El campo PrimerApellido excede los 50 caracteres")
                .Must(x => !double.TryParse(x, out _)).WithMessage("El campo PrimerNombre no debe ser número");

            RuleFor(x => x.SegundoNombre)
                .MaximumLength(50).Must(x => !double.TryParse(x, out _)).WithMessage("El campo SegundoNombre no debe ser número");

            RuleFor(x => x.PrimerApellido)
                .NotNull()
                .NotEmpty().WithMessage("El campo PrimerApellido es obligatorio")
                .MaximumLength(50).WithMessage("El campo PrimerApellido excede los 50 caracteres")
                .Must(x => !double.TryParse(x, out _)).WithMessage("El campo PrimerApellido no debe ser número");

            RuleFor(x => x.SegundoApellido)
                .MaximumLength(50).WithMessage("El campo PrimerApellido excede los 50 caracteres")
                .Must(x => !double.TryParse(x, out _)).WithMessage("El campo SegundoApellido no debe ser número");

            RuleFor(x => x.FechaNacimiento)
                .NotNull()
                .NotEmpty().WithMessage("El campo FechaNacimiento es Obligatorio");

            RuleFor(x => x.Sueldo)
                .NotNull().WithMessage("El campo Sueldo es obligatorio")
                .NotEmpty().WithMessage("El campo Sueldo es obligatorio")
                .GreaterThan(0).WithMessage("El campo Sueldo debe ser mayor que cero");
        }
    }
}
