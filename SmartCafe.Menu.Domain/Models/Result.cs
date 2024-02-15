
namespace SmartCafe.Menu.Domain.Models;

public class Result<TResult, TError>
{
    public TResult? Value { get; set; }
    public TError? Error { get; set; }
    public ResultStatus Status { get; set; }

    public bool IsSuccess =>
        Status == ResultStatus.Success;

    public bool IsFailed =>
        Status == ResultStatus.Failed;

    public static Result<TResult, TError> Success(TResult value) =>
        new Result<TResult, TError>
        {
            Status = ResultStatus.Success,
            Value = value
        };

    public static Result<TResult, TError> Fail(TError error) =>
        new Result<TResult, TError>
        {
            Status = ResultStatus.Failed,
            Error = error
        };
}
