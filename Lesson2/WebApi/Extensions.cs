using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace WebApi
{
    public static class Extensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICheck, CheckArticle>();
            services.AddTransient<IAddContent, AddContentToArticle>();
            services.AddTransient<IPublish, PublishArticle>();

            /* по заданию трудно понять, сколько времени нужно хранить информацию,
               если нужно хранить в течении одного запроса то можно использовать Scoped*/
            services.AddSingleton<ITempStorage, TempArticleStorage>();

            services.AddScoped<ILogicPublish, LogicPublish>();

            return services;
        }
    }
}