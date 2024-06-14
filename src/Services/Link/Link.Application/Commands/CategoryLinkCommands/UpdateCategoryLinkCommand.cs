using MediatR;

namespace Link.Application.Commands.CategoryLinkCommands;

public record class UpdateCategoryLinkCommand(Guid Id, string NewName) : IRequest<bool>;