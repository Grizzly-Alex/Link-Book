using Link.Core.Entities;
using MediatR;

namespace Link.Application.Commands.LinkTagCommands;

public sealed class CreateLinkTagCommand : IRequest<LinkCategory>
{
    public string UserId { get; set; }
    public string Name { get; set; }
}
