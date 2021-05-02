using AdapterExceptions;
using ExceptionInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebApi.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IExceptionLogic exceptionLogic;

        public ExceptionFilter(IExceptionLogic exceptionLogic)
        {
            this.exceptionLogic = exceptionLogic;
        }
        public void OnException(ExceptionContext context)
        {
            exceptionLogic.HandleException(context);
            try
            {
                throw context.Exception;
            }
            catch (ArgumentInvalidMappingException ex)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 400,
                    Content = ex.Message
                };
            }
            catch (NullObjectMappingException ex)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 404,
                    Content = ex.Message
                };
            }
            catch (Exception)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 500,
                    Content = "Server problems, unexpected error"
                };
            }
        }
    }
}
