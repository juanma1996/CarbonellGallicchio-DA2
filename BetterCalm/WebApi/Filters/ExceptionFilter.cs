using AdapterExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebApi.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            try
            {
                throw context.Exception;
            }
            catch (AmountOfProblematicsException ex)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 400,
                    Content = ex.errorMessage
                };
            }
            catch (InvalidAttributeException ex)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 400,
                    Content = ex.errorMessage
                };
            }
            catch (NotFoundException ex)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 404,
                    Content = ex.errorMessage
                };
            }
            catch (EntityAlreadyExistException ex)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 400,
                    Content = ex.errorMessage
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
