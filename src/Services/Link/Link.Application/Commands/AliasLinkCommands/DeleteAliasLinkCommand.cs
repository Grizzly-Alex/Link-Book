using Link.Core.Entities;
using MediatR;

namespace Link.Application.Commands.AliasLinkCommands;

public sealed class DeleteAliasLinkCommand : IRequest<AliasLink>
{
    public Guid Id { get; set; }
}
