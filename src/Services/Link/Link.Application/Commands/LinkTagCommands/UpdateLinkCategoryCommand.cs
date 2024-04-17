using MediatR;

namespace Link.Application.Commands.LinkTagCommands;

public sealed class UpdateLinkCategoryCommand(string id, string name) : IRequest<bool>
{
    public string Id { get; set; } = id;
    public string Name { get; set; } = name;
}
