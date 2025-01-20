using System.Net;

namespace Link.Core.Entities;

public record Error(string Code, string Details)
{
    public static Error None = new(string.Empty, string.Empty);

    public static Error NullValue = new(HttpStatusCode.NoContent.ToString(), "Null value was provided");
}
