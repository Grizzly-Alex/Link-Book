using Link.Core.Entities;
using MediatR;

namespace Link.Application.Commands.UserLinkCommands;

public sealed class UpdateUserLinkCommand : IRequest<UserLink>
{
    public Guid Id { get; set; }
    public string AliasUrl { get; set; }
    public string OriginalUrl { get; set; }
    public bool Favorite { get; set; }
    public Guid TagId { get; set; }
}
