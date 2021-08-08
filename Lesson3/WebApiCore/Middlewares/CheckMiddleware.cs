using Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApiCore.Middlewares
{
    public class CheckMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICheck checkArticle)
        {
            checkArticle.Check();

            await _next(context);
        }
    }
}