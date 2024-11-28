using EmailServices.Communication.Response;
using EmailServices.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmailServices.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is EmailServicesException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThworUnkowError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var emailServicesException = (EmailServicesException)context.Exception;
        var errorMessage = new ResponseErrorJson(emailServicesException.GetErrors());

        context.HttpContext.Response.StatusCode = emailServicesException.StatusCode;
        context.Result = new ObjectResult(errorMessage);

    }

    private void ThworUnkowError(ExceptionContext context)
    {
        var errorMessage = new ResponseErrorJson("UNKNOWN ERROR");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorMessage);
    }
}