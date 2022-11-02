using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sat.Recruitment.Api.Helpers;
using Sat.Recruitment.Api.Responses;
using Sat.Recruitment.Domain.Exceptions;

namespace Sat.Recruitment.Api.Filters
{
    public class ExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentException or ArgumentNullException or TechnicalException)
            {
                ProcessContextResponse(context, (int)HttpStatusCode.InternalServerError);
            }
        }

        private void ProcessContextResponse(ExceptionContext context, int statusCode)
        {
            context.HttpContext.Response.StatusCode = statusCode;
            ErrorResponse response = new ResponseBuilder()
                .FromHttpContext(context.HttpContext)
                .FromException(context.Exception);

            context.Result = new ObjectResult(response)
            {
                StatusCode = context.HttpContext.Response.StatusCode,
            };

            context.ExceptionHandled = true;
        }
    }
}
