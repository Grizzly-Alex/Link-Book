namespace Link.Application.Responses;

public record class UserLinkResponse(Guid Id, string AliasUrl, string OriginalUrl, bool Favorite, string Category);
