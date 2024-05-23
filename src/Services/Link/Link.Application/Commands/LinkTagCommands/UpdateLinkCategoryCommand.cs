using MediatR;

namespace Link.Application.Commands.LinkTagCommands;

public record class UpdateLinkCategoryCommand(Guid Id, string NewName) : IRequest<bool>;