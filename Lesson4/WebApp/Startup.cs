using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using WebApp.Extensions;
using WebApp.Providers;

/*������� � �����������:
          C������ ��������� � ������� �������� ���� � �����, 
          ������� ��������� ��� ����� 
          ���� - ��� �����, 
          �������� - ���������� ���� �����*/

/*���������, 
    ��� ������� �������� ������� + ������� � �����������, 
    ����� ������� ������ �������� �.�.,
    ����� ������������������ ������� � ������������ Startup*/

namespace WebApp
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()/*.AddJsonFile("customConfig.json")*/;      //���� ����������������, � ������� ��������� ����� � �������� � ����� json
                                                                                                //� � �������� ��������� ���������� � ������� ������ ������
            string path = Directory.GetCurrentDirectory();      //����� ����� ������� ��� ����

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
                    + $"<p>FolderNames: {string.Join(", ", customClass.FolderNames) }</p>";  //������ ��� ������ ������������ � ������� ������ ������
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