using CQRS.Commands.Validators;
using CQRS.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.CQRS.Commands.AddUserFake
{
    public class AddUserFakeValidRoleValidator : ICommandValidator<AddUserFakeCommand>
    {
        public IEnumerable<ValidationResult> Validate(AddUserFakeCommand command)
        {
            var validRoles = new[] { "admin", "user" };

            if (!validRoles.Contains(command.Role))
                yield return new ValidationResult("Invalid role.");
        }
    }
}
