using Link.Core.Entities;
using MediatR;

namespace Link.Application.Commands.UserLinkCommands;

public sealed class DeleteUserLinkCommand : IRequest<UserLink>
{
    public Guid Id { get; set; }
}
