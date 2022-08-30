namespace LOGIC.Services.Models;

public class StandardResult
{
    public StandardResult()
    {
        success = false;
        userMessage = string.Empty;
        exception = null;
    }
    public bool success { get; set; }
    public string userMessage { get; set; }
    public Exception exception { get; set; } // As its internal the end user will not see it.
}