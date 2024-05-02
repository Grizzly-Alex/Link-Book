using MediatR;

namespace Link.Application.Commands.LinkTagCommands;

public record class CreateLinkCategoryCommand(string UserId, string Name) : IRequest<bool>;