using Microsoft.AspNetCore.Builder;
using WebApiCore.Middlewares;

namespace WebApiCore
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseAddContentMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AddContentMiddleware>();
        }

        public static IApplicationBuilder UseCheckMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckMiddleware>();
        }

        public static IApplicationBuilder UsePublishMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PublishMiddleware>();
        }

        public static IApplicationBuilder UseTempArticleStorageMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TempArticleStorageMiddleware>();
        }
    }
}