using Link.Core.Entities;
using MediatR;

namespace Link.Application.Commands;

public sealed class CreateUserLinkCommand : IRequest<UserLink>
{
    public string UserId { get; set; }  
    public string AliasUrl { get; set; }
    public string OriginalUrl { get; set; }
    public bool Favorite { get; set; }
    public Guid TagId { get; set; }
}
