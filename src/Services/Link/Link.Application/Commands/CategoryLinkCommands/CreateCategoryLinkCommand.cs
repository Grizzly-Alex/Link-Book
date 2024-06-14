using MediatR;

namespace Link.Application.Commands.CategoryLinkCommands;

public record class CreateCategoryLinkCommand(string UserId, string Name) : IRequest<bool>;