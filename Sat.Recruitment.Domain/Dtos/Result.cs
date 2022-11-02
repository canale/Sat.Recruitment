using System;

namespace Sat.Recruitment.Domain.Dtos
{
    public class Result<TResult>
    {
        /// <summary>
        /// Allows to create a Succeed result.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Result<TResult> Succeed(TResult result) => new Result<TResult>(result);

        /// <summary>
        /// Allows to create a Failure Result.
        /// </summary>
        /// <param name="errors">List of errors.</param>
        /// <returns></returns>
        public static Result<TResult> Failure(Error[] errors) => new Result<TResult>(errors);


        /// <summary>
        /// Allows to create a Failure Result.
        /// </summary>
        /// <param name="error">List of errors.</param>
        /// <returns></returns>
        public static Result<TResult> Failure(Error error) => new Result<TResult>(new Error[] { error });




        /// <summary>
        /// List of errors
        /// </summary>
        public Error[] Errors { get; }

        /// <summary>
        /// Content of the typedResult if it is successful.
        /// </summary>
        public TResult Value { get; }

        /// <summary>
        /// Indicated if the typedResult es successful or not.
        /// </summary>
        public bool IsSuccess { get; }



        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        public Result(TResult value)
        {
            Value = value;
            IsSuccess = true;
            Errors = Array.Empty<Error>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="errors"></param>
        public Result(Error[] errors)
        {
            Value = default;
            IsSuccess = false;
            Errors = errors;
        }

        public TOutput Transform<TOutput>(Func<Result<TResult>, TOutput> onSuccess,
            Func<Result<TResult>, TOutput> onFail)
            => (IsSuccess) ? onSuccess(this) : onFail(this);
    }
}
