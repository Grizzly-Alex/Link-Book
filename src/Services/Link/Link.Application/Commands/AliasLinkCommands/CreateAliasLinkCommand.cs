using Link.Application.Responses;

namespace Link.Application.Commands.AliasLinkCommands;

public sealed class CreateAliasLinkCommand : ICommand<AliasLinkResponse>
{
    public string UserId { get; set; }
    public string AliasUrl { get; set; }
    public string OriginalUrl { get; set; }
    public bool Favorite { get; set; }
    public Guid? CategoryId { get; set; }
}
