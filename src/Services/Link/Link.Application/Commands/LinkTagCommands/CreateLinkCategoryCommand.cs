using MediatR;

namespace Link.Application.Commands.LinkTagCommands;

public sealed class CreateLinkCategoryCommand(string userId, string name) : IRequest<bool>
{
    public string UserId { get; set; } = userId;
    public string Name { get; set; } = name;
}
