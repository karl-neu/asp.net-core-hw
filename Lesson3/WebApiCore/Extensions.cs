using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace WebApiCore
{
    public static class Extensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICheck, CheckArticle>();
            services.AddTransient<IAddContent, AddContentToArticle>();
            services.AddTransient<IPublish, PublishArticle>();

            services.AddSingleton<ITempStorage, TempArticleStorage>();

            return services;
        }
    }
}