using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace WebApi.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;

        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled && context.Exception is DivideByZeroException)
            {
                context.Result = new ContentResult
                {
                    Content = $"Цей запит не може бути оброблено"
                };

                _logger.LogInformation($"{DateTime.Now}" +                    //Logging
                    $"\n\t{context.ActionDescriptor.DisplayName}" +
                    $"\n\t{context.Exception.Message}");

                context.ExceptionHandled = true;
            }
        }
    }
}