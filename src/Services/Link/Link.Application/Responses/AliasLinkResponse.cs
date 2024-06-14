namespace Link.Application.Responses;

public record class AliasLinkResponse(Guid Id, string AliasUrl, string OriginalUrl, bool Favorite, string Category);
