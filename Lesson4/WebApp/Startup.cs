using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using WebApp.Extensions;
using WebApp.Providers;

/*Задание с провайдером:
          Cоздать провайдер в который передаем путь к папке, 
          который считывает все файлы 
          ключ - имя файла, 
          значение - количество букв имени*/

/*Извеняюсь, 
    тут смешано домашнее задание + задание с провайдером, 
    чтобы увидеть работу обычного д.з.,
    нужно расскомментировать строчку в конструкторе Startup*/

namespace WebApp
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()/*.AddJsonFile("customConfig.json")*/;      //если раскоментировать, в консоль добавятся ключи и значения с файла json
                                                                                                //а в браузере выведется информация с разными типами данных
            string path = Directory.GetCurrentDirectory();      //здесь можно указать ваш путь

            builder.AddCustomConfiguration(path);

            AppConfiguration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services) { }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var customClass = new CustomClass();
            AppConfiguration.Bind(customClass);
            string str = "";

            try
            {
                str = $"<p>Path: {customClass.Path}</p>"
                    + $"<p>Count: {customClass.Count}</p>"
                    + $"<p>DateCreated: {customClass.DateCreated}</p>"
                    + $"<p>FolderNames: {string.Join(", ", customClass.FolderNames) }</p>";  //строка для вывода конфигурация с разными типами данных
            }
            catch (System.Exception) { str = "CustomProvider info printed in Console!"; }


            foreach (var item in AppConfiguration.AsEnumerable())
            {
                if (int.TryParse(item.Value, out int num)) System.Console.WriteLine($"{item.Key} {item.Value}");
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(str);
            });
        }
    }
}