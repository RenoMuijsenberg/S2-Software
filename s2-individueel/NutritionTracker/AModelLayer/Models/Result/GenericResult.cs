namespace LOGIC.Services.Models;

public class GenericResult<T> : StandardResult
{
    public T result { get; set; }
}