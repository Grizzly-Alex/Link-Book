namespace LinkBook.Services.UrlAPI.Models;

public record class LinkDto(
    Guid Id,
    string UserId,
    string AliasUrl,
    string OriginalUrl,
    string Tag,
    bool Favorite);
