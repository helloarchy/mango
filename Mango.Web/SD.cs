namespace Mango.Web;

/// <summary>
/// Static details class to hold all constants
/// </summary>
public class SD
{
    public string ProductAPIBase { get; set; }
    public enum ApiType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}