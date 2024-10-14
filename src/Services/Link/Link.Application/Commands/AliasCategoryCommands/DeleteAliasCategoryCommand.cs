using Link.Application.Responses;
using MediatR;

namespace Link.Application.Commands.AliasCategoryCommands;

public record class DeleteAliasCategoryCommand(Guid Id) : IRequest<Response>;