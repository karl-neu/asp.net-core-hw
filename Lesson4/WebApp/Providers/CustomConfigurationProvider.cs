using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace WebApp.Providers
{
    public class CustomConfigurationProvider : ConfigurationProvider
    {
        private readonly string _path;

        public CustomConfigurationProvider(string path) =>
            _path = path;

        public override void Load()
        {
            if (new DirectoryInfo(_path).Exists)
            {
                var files = Directory.EnumerateFiles(_path);
                var dict = new Dictionary<string, string>();

                foreach (var file in files)
                    dict.Add(file.Substring(file.LastIndexOf("\\") + 1),
                             file.Substring(file.LastIndexOf("\\") + 1).Length.ToString());

                Data = dict;
            }
            else Console.WriteLine("Path is not exist");
        }
    }
}
