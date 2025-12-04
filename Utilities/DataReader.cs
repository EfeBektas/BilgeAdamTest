using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace BilgeAdamTest.Utilities
{
    public static class DataReader
    {
        public static TestDataModel LoadProducts()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "TestData", "products.json");

            string json = File.ReadAllText(path);

            return JsonSerializer.Deserialize<TestDataModel>(json,new JsonSerializerOptions{PropertyNameCaseInsensitive = true});
        }
    }
}

