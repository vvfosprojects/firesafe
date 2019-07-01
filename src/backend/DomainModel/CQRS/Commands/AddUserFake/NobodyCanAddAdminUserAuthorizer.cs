using CQRS.Authorization;
using CQRS.Commands.Authorizers;
using System.Collections.Generic;

namespace DomainModel.CQRS.Commands.AddUserFake
{
    public class NobodyCanAddAdminUserAuthorizer : ICommandAuthorizer<AddUserFakeCommand>
    {
        public IEnumerable<AuthorizationResult> Authorize(AddUserFakeCommand command)
        {
            if (command.Username == "admin")
                yield return new AuthorizationResult("Unauthorized to add admin user");
        }
    }
}
