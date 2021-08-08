using Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApiCore.Middlewares
{
    public class TempArticleStorageMiddleware
    {
        private readonly RequestDelegate _next;

        public TempArticleStorageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITempStorage tempArticleStorage)
        {
            tempArticleStorage.AddArticleInfo();

            await _next(context);
        }
    }
}