namespace SmartCafe.Menu.Domain.Models;

public class ErrorResult<T>
    where T : struct
{
    public T Status { get; set; }
    public required string Message { get; set; }
}
