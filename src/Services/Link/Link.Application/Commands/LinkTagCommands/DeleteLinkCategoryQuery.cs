using MediatR;

namespace Link.Application.Commands.LinkTagCommands;

public class DeleteLinkCategoryQuery(Guid id) : IRequest<bool>
{
    public Guid Id { get; set; } = id;
}
