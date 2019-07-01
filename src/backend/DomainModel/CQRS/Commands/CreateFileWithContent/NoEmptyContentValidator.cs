using CQRS.Commands.Validators;
using CQRS.Validation;
using System.Collections.Generic;

namespace DomainModel.CQRS.Commands.CreateFileWithContent
{
    public class NoEmptyContentValidator : ICommandValidator<CreateFileWithContentCommand>
    {
        public IEnumerable<ValidationResult> Validate(CreateFileWithContentCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Content))
                yield return new ValidationResult("Il content non può essere vuoto");
        }
    }
}
