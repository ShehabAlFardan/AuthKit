using AuthKit.Application.Exceptions;
using AuthKit.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace AuthKit.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
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
                await HandleValidationExceptionAsync(context, ex);
            }            
            catch (DomainException ex)
            {
                await HandleDomainExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleGenericExceptionAsync(context, ex);
            }
        }

        private Task HandleValidationExceptionAsync(HttpContext context, ValidationException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var response = new
            {
                ErrorMessage = "Validation failed.",
                Errors = ex.Errors.Select(e => new
                {
                    e.Code,
                    e.Message,
                    e.Path
                })
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private async Task HandleDomainExceptionAsync(HttpContext context, DomainException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var errorResponse = new
            {
                type = "Domain Error",
                title = ex.GetType().Name,
                detail = ex.Message, 
                status = context.Response.StatusCode,
                instance = context.Request.Path
            };

            await context.Response.WriteAsJsonAsync(errorResponse);
        }

        private Task HandleGenericExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                ErrorMessage = ex.Message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
