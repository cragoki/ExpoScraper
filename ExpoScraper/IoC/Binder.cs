using ExpoScraper.Constants;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpoScraper.IoC
{
    public static class Binder
    {
        public static T BindSettings<T>(this IConfiguration configuration, SettingsInfo settingsInfo)
            where T : class, new()
        {
            T settings = new T();
            configuration.GetSection(settingsInfo.SectionName).Bind(settings);

            if (!string.IsNullOrEmpty(settingsInfo.EnvironmentPrefix))
            {
                var properties = typeof(T).GetProperties();
                foreach (var property in properties)
                {
                    string envVariable = Environment.GetEnvironmentVariable($"{settingsInfo.EnvironmentPrefix}_{property.Name.ToUpperInvariant()}");

                    if (!string.IsNullOrEmpty(envVariable))
                        property.SetValue(settings, envVariable);
                }
            }
            return settings;
        }
    }
}
