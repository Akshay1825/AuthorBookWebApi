﻿using AuthorBookWebApi.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace AuthorBookWebApi.Exceptions
{
    public class ExceptionHandler:IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
            CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();
            if (exception is AuthorNotFoundException)
            {
                response.ErrorCode = StatusCodes.Status404NotFound;
                response.ExceptionMessage = exception.Message;
                response.Title = "Wrong Input";
            }
            else
            {
                response.ErrorCode = StatusCodes.Status500InternalServerError;
                response.ExceptionMessage = exception.Message;
                response.Title = "Something Went Wrong";
            }
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
