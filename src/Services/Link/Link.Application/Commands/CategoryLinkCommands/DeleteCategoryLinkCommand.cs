using MediatR;

namespace Link.Application.Commands.CategoryLinkCommands;

public record class DeleteCategoryLinkCommand(Guid Id) : IRequest<bool>;