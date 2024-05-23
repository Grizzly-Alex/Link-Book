using MediatR;

namespace Link.Application.Commands.LinkTagCommands;

public record class DeleteLinkCategoryCommand(Guid Id) : IRequest<bool>;