using Link.Core.Entities;
using MediatR;

namespace Link.Application.Commands.AliasLinkCommands;

public sealed class UpdateAliasLinkCommand : IRequest<AliasLink>
{
    public Guid Id { get; set; }
    public string AliasUrl { get; set; }
    public string OriginalUrl { get; set; }
    public bool Favorite { get; set; }
    public Guid TagId { get; set; }
}
