﻿using Link.Core.Entities;
using MediatR;

namespace Link.Application.Commands.LinkTagCommands;

public sealed class UpdateLinkTagCommand : IRequest<LinkCategory>
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
}
