using Link.Core.Entities;
using MediatR;

namespace Link.Application.Commands.LinkTagCommands;

public sealed class DeleteLinkTagCommand : IRequest<LinkTag>
{
    public Guid Id { get; set; }
}
