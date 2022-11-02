using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Sat.Recruitment.Api.Responses;
using Sat.Recruitment.Domain.Dtos;
using Sat.Recruitment.Infrastructure.Extensions;

namespace Sat.Recruitment.Api.Helpers
{
    public class ResponseBuilder
    {
        /// <summary>
        /// a URI identifier that categorizes the error
        /// </summary>
        private string _type;

        /// <summary>
        ///
        /// </summary>
        private readonly DateTime _timeStamp;

        /// <summary>
        ///  the HTTP response code (optional)
        /// </summary>
        private int _status;

        /// <summary>
        /// a brief, human-readable detail about the error
        /// </summary>
        private string _title;

        /// <summary>
        /// a human-readable explanation of the error
        /// </summary>
        private string _detail;

        /// <summary>
        /// a URI that identifies the specific occurrence of the error
        /// </summary>
        private string _instance;

        /// <summary>
        /// Constructor.
        /// </summary>
        internal ResponseBuilder()
        {
            _timeStamp = DateTime.Now;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param Name="exception"></param>
        /// <returns></returns>
        internal ResponseBuilder FromException(Exception exception)
        {
            _type = GetType(exception);
            _detail = exception.Message;
            _title = exception.Message;

            return this;
        }

        internal ResponseBuilder FromError(Error error)
        {
            _type = error.TargetType.Name;
            _detail = error.Message;
            _title = error.Message;

            return this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param Name="httpContext"></param>
        /// <returns></returns>
        internal ResponseBuilder FromHttpContext(HttpContext httpContext)
        {
            _status = httpContext.Response.StatusCode;
            _instance = httpContext.Request.Path;

            return this;
        }

        /// <summary>
        /// Allows to set a http status code for the response.
        /// </summary>
        /// <param name="statusCode">Value os http status code.</param>
        /// <returns></returns>
        internal ResponseBuilder AddStatusCode(int statusCode)
        {
            _status = statusCode;

            return this;
        }

        /// <summary>
        /// Allows to set a http status code for the response.
        /// </summary>
        /// <param name="statusCode">Value os http status code.</param>
        /// <returns></returns>
        internal ResponseBuilder AddStatusCode(HttpStatusCode statusCode)
        {
            _status = (int) statusCode;

            return this;
        }

        internal ErrorResponse Build()
            => new ErrorResponse
            {
                Type = _type,
                Title = _title,
                TimeStamp = _timeStamp,
                Detail = _detail,
                Instance = _instance,
                Status = _status,
            };



        private string GetType(Exception exception)
        {
            string type = exception.GetType().Name.FromPascalToKebabCase();
            return  $"error/{type}";
        }

        private string GetType(Error error)
        {
            string type = error.GetType().Name.FromPascalToKebabCase();
            return $"error/{type}";
        }

        public static implicit operator ErrorResponse(ResponseBuilder builder) => builder.Build();
    }
}
