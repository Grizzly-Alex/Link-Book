using Link.Application.Responses;
using MediatR;

namespace Link.Application.Commands.AliasCategoryCommands;

public record class UpdateAliasCategoryCommand(Guid Id, string NewName) : IRequest<Response>;