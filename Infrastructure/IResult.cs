using System;

namespace VertSliceOra5.Infrastructure
{
    public interface IResult<T>
    {
        T Payload { get; }
        bool IsSuccess { get; }

        DateTime TimeStampUTC { get; }

        string FailureReason { get; }
    }

    public class Result<T> : IResult<T>
    {
        public Result() { }

        public T Payload { get; protected set; }

        public bool IsSuccess { get; protected set; }

        public DateTime TimeStampUTC { get; protected set; }

        public string FailureReason { get; protected set; }

        public static Result<T> Fail(string reason)
        {
            return new Result<T>
            {
                IsSuccess = false,
                FailureReason = reason,
                TimeStampUTC = DateTime.UtcNow
            };
        }

        public static Result<T> Success(T payload)
        {
            return new Result<T>
            {
                IsSuccess = true,
                Payload = payload,
                TimeStampUTC = DateTime.UtcNow
            };
        }

        public static implicit operator bool(Result<T> result) => result.IsSuccess;

    }
}
