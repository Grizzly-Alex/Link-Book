using Link.Application.Responses;
using MediatR;

namespace Link.Application.Commands.AliasCategoryCommands;

public record class CreateAliasCategoryCommand(string UserId, string Name) : IRequest<Response>;