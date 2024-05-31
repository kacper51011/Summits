using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Utilities
{
    public class Result
    {
        public ErrorType Error { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }

        public bool IsFailure => !IsSuccess;
        public Result(bool isSuccess, ErrorType error, int statusCode)
        {
            IsSuccess = isSuccess;
            Error = error;
            StatusCode = statusCode;
        }

        public static Result Success(int statusCode = 200) => new(true, ErrorType.None, statusCode);
        public static Result Failure(ErrorType error, int statusCode = 400) => new(false, error, statusCode);
        public static Result<T> Success<T>(T data, int statusCode = 200) => new(true, ErrorType.None, statusCode, data);
        public static Result<T> Failure<T>(ErrorType error, int statusCode = 400) => new(false, error, statusCode, default);



    }

    public class Result<T>: Result
    {
        public T? Data { get; set; }

        public Result( bool isSuccess, ErrorType error, int statusCode, T? data = default): base(isSuccess, error, statusCode)
        {
            Data = data;
            
        }
    }
}
