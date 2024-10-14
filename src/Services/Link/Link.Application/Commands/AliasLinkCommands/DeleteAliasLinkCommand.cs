using Link.Application.Responses;
using MediatR;

namespace Link.Application.Commands.AliasLinkCommands;

public record class DeleteAliasLinkCommand(Guid Id) : IRequest<Response>;

