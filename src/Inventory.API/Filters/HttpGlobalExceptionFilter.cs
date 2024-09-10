using FluentValidation;
using Inventory.Application.DTOs;
using Inventory.Domain.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Inventory.API.Filters;

public class HttpGlobalExceptionFilter : IExceptionFilter
{
    private readonly IWebHostEnvironment env;

    public HttpGlobalExceptionFilter(IWebHostEnvironment env)
    {
        this.env = env;
    }

    public void OnException(ExceptionContext context)
    {
        var response = new ResponseBase<object>(false);
        switch (context.Exception)
        {
            case ValidationException e:
                {
                    response.Errors = e.Errors.Select(er => $"{er.ErrorCode}: {er.ErrorMessage}").ToArray();
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Result = new ResponseServerErrorObjectResult(response);
                    break;
                }
            case DomainException e:
                {
                    response.Errors = new[] { e.Message };
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Result = new ResponseServerErrorObjectResult(response);
                    break;
                }
            default:
                {
                    response.Errors = new[] { "Internal Error Occurred" };
                    if (env.IsDevelopment() || env.IsStaging())
                    {
                        response.Response = new { context.Exception.Message, context.Exception.StackTrace };
                    }

                    context.Result = new InternalServerErrorObjectResult(response);
                    break;
                }
        }

        context.ExceptionHandled = true;
    }

    public class ResponseServerErrorObjectResult : ObjectResult
    {
        public ResponseServerErrorObjectResult(object error)
            : base(error)
        {
            StatusCode = StatusCodes.Status200OK;
        }
    }

    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object error)
            : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
