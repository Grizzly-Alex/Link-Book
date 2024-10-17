namespace Link.Application.Responses;

public record class AliasLinkResponse(
    string Id,
    string AliasUrl,
    string OriginalUrl,
    bool Favorite,
    AliasCategoryResponse Category);
