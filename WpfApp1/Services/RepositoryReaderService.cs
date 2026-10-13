using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TemplatePlugin;

namespace WpfApp1.Services
{
    public class RepositoryReaderService(LogService logService)
    {
        private string path = AppContext.BaseDirectory + @"\\Plugins\\";

        private List<MethodInfo> methodInfos = new();

        public List<MethodInfo> ReadDirectory()
        {
            logService.Log("looking for Plugins.");

            Directory.CreateDirectory(path);
            foreach (var file in Directory.GetFiles(path))
            {
                var assembly = Assembly.LoadFrom(file);
                foreach (var type in assembly.GetExportedTypes())
                {
                    var attribute = type.GetCustomAttribute<TemplatePluginAttribute>();

                    if (attribute == null)
                        continue;

                    foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                    {
                        logService.Log($"Method with name {method.Name} found.");
                        methodInfos.Add(method);
                    }
                }
            }

            return methodInfos;
        }
    }
}
