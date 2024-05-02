using MediatR;

namespace Link.Application.Commands.LinkTagCommands;

public record class DeleteLinkCategoryQuery(Guid Id) : IRequest<bool>;