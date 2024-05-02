using MediatR;

namespace Link.Application.Commands.LinkTagCommands;

public record class UpdateLinkCategoryCommand(string Id, string Name) : IRequest<bool>;