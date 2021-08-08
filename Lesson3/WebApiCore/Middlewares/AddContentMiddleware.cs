using Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApiCore.Middlewares
{
    public class AddContentMiddleware
    {
        private readonly RequestDelegate _next;

        public AddContentMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAddContent addContentToArticle)
        {
            addContentToArticle.Add();

            await _next(context);
        }
    }
}