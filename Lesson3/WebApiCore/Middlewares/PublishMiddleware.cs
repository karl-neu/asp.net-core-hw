using Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApiCore.Middlewares
{
    public class PublishMiddleware
    {
        private readonly RequestDelegate _next;

        public PublishMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IPublish publishArticle)
        {
            publishArticle.Publish();

            //await _next(context);
            await context.Response.WriteAsync("Published!");
        }
    }
}