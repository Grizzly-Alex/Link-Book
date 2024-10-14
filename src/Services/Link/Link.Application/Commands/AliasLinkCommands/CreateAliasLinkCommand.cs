using Link.Application.Responses;
using MediatR;

namespace Link.Application.Commands.AliasLinkCommands;

public sealed class CreateAliasLinkCommand : IRequest<Response>
{
    public string UserId { get; set; }
    public string AliasUrl { get; set; }
    public string OriginalUrl { get; set; }
    public bool Favorite { get; set; }
    public Guid? CategoryId { get; set; }
}
