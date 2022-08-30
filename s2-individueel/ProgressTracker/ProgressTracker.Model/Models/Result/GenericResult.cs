namespace ProgressTracker.MODEL.Models.Result;

public class GenericResult<T> : StandardResult
{
    public T result { get; set; }
}