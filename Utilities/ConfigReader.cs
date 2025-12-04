using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace BilgeAdamTest.Utilities
{
    internal class ConfigReader
    {
        private static IConfigurationRoot config;

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/configTxt.json", optional: false, reloadOnChange: true);

            config = builder.Build();
        }

        public static string BaseUrl => config["baseUrl"];
        public static string Username => config["username"];
        public static string Password => config["password"];
        public static string Browser => config["browser"];
    }

}

