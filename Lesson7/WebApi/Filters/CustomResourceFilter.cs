using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;

namespace WebApi.Filters
{
    public class CustomResourceFilter : Attribute, IResourceFilter
    {
        private readonly CustomValidateOptions _options;

        public CustomResourceFilter(IOptions<CustomValidateOptions> options)
        {
            this._options = options.Value;
        }

        public void OnResourceExecuted(ResourceExecutedContext context) { }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue(_options.HeaderKey, out var headerValue);

            var f = Int32.TryParse(context.HttpContext.Request.Cookies[_options.CookieKey1], out int arg1);
            var f2 = Int32.TryParse(context.HttpContext.Request.Cookies[_options.CookieKey2], out int arg2);
            var f3 = Int32.TryParse(headerValue, out int headerValueNum);

            if (!f || !f2 || !f3 || arg1 + arg2 != headerValueNum)
                context.Result = new ContentResult { Content = "Access denied :-D, you need a key." };
        }
    }
}