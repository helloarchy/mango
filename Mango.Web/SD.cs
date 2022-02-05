namespace Mango.Web;

/// <summary>
/// Static details class to hold all constants
/// </summary>
public static class Sd
{
    public static string? ProductApiBase { get; set; }
    public enum ApiType
    {
        Get,
        Post,
        Put,
        Delete
    }
}