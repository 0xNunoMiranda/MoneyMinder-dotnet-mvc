using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoneyMinder_dotnet_mvc.Communication.Responses;
using MoneyMinder_dotnet_mvc.Exceptions;
using MoneyMinder_dotnet_mvc.Exceptions.ExceptionBase;

namespace MoneyMinder_dotnet_mvc.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is CashFlowException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnkowError(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            if(context.Exception is ErrorOnValidationException)
            {
                var ex = (ErrorOnValidationException)context.Exception;
                var errorResponse = new ResponseError(ex.ErrorsMessages);
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(errorResponse);
            }
            else
            {
                var errorResponse = new ResponseError(context.Exception.Message);

                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }

        private void ThrowUnkowError(ExceptionContext context)
        {
            var errorResponse = new ResponseError(ResourceErrorMessages.UNKOWN_ERROR);
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);


        }

    }
}
