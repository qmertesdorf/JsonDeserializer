using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace JsonDeserializer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read data from appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            string filepath = null;
            if (config["filepath"] != null && File.Exists(config["filepath"]))
            {
                filepath = config["filepath"];
            }
            else if (args.Length == 2 && File.Exists(args[1]) && args[0] == "-f")
            {
                filepath = args[1];
            } else
            {
                //In the case where user did not pass in the "-f" argument or there is no valid filepath, exit application
                //User-facing error message would go here
                Environment.Exit(1);
            }

            JObject parsedJSON = JObject.Parse(File.ReadAllText(@filepath));
            JArray jsonArray = (JArray)parsedJSON["items"];
            foreach (JToken item in jsonArray)
            {
                Console.WriteLine(item["name"]);
            }
        }
    }
}