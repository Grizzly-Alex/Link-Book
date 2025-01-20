using System.Net;

namespace Link.Core.Entities.Link
{
    public static class LinkErrors
    {
        public static Error NotFound => new(
            HttpStatusCode.NotFound.ToString(),
            "The link was not found");
    }
}
