namespace Link.Application.Commands.AliasLinkCommands;

public sealed class UpdateAliasLinkCommand : ICommand
{
    public Guid Id { get; set; }
    public string AliasUrl { get; set; }
    public string OriginalUrl { get; set; }
    public bool Favorite { get; set; }
    public Guid? CategoryId { get; set; }
}
