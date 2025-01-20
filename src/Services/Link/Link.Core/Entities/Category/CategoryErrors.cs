using System.Net;

namespace Link.Core.Entities.Category
{
    public static class CategoryErrors
    {
        public static Error NotFound => new(
            HttpStatusCode.NotFound.ToString(),
            "The category not was found");

        public static Error Conflict => new(
            HttpStatusCode.Conflict.ToString(),
            "The сategory already exists in the list");
    }
}
