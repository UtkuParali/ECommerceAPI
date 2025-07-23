using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerceAPI.Middleware
{
    public class ValidationExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ValidationExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/problem+json";

                var problemDetails = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Type = "https://httpstatuses.com/400",
                    Title = "Validation Failed",
                    Detail = "One or more validation errors occurred.",
                    Extensions =
                    {
                        {"errors", ex.Errors.Select(e => new{e.PropertyName, e.ErrorMessage}) }
                    }
                };

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/problem+json";

                var problemDetails = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "https://httpstatuses.com/500",
                    Title = "An unhandled error occurred",
                    Detail = ex.Message
                };

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
