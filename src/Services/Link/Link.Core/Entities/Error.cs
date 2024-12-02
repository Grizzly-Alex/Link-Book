using System.Text.Json;

namespace Link.Core.Entities;

public sealed class Error
{
    private string _code;
    private string _details;

    public static Error None = new(string.Empty, string.Empty);
    public static Error NullValue = new("error.NullValue", "Null value was provided");

    public Error(string code, string details)
    {
        _code = code;
        _details = details;
    }

    public Error(int code, string details)
    {
        _code = code.ToString();
        _details = details;
    }

    public Error(int code, object details)
    {
        _code = code.ToString();
        _details = JsonSerializer.Serialize(details);
    }
}
